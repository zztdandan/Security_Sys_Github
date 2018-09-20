using System;
using System.Collections.Generic;
using System.Linq;

namespace LGWBVerifySystem
{
    /// <summary>
    /// 执行一个审核线所需的资料组
    /// </summary>
    public class VerifyInfo : IVerifyInfo
    {
        //该审核所属工作流程信息
        public virtual AdvWorkFlow AdvWORKFLOW { get; set; }
        //起始节点信息
        public virtual IWORKFLOW_NODE StartNodeInfo { get; set; }


        public virtual IVerifyEntity Entity { get; set; }
        public virtual IWORKFLOW_NODE EndNodeInfo { get; set; }
        //单个审核的审核线
        public virtual IWORKFLOW_LINK LinkInfo { get; set; }


        public  VerifyInfo(IWORKFLOW_LINK link, IVerifyEntity entity,AdvWorkFlow advworkflow)
        {
            this.AdvWORKFLOW = advworkflow;
            var res1 = link.GetStartNode();
            var res2 = link.GetEndNode();

            this.StartNodeInfo = res1;
            this.EndNodeInfo = res2;
            this.LinkInfo = link;
            this.Entity = entity;
        }

        /// <summary>
        /// 单线审核
        /// </summary>
        /// <param name="Condition"></param>
        /// <param name="conclusion"></param>
        /// <returns></returns>
        public virtual CSException VerifySingle(string conclusion)
        {
            try
            {
                var _link = this.LinkInfo;
                var _endnodeid = this.EndNodeInfo.NODE_ID;
                var _endnode = this.EndNodeInfo;
                var EntityStats = Entity.STATS;
                //Entity.LAST_ORDER = Entity.AUDITSTEP_ID;//给实体赋值 LAST_ORDER
               var re= Entity.AlterStats(this.EndNodeInfo.ORDER_ID, this.EndNodeInfo.NODE_ID,conclusion);
               if (!re.Flag) { throw new Exception(re.Msg); }
                //给原实体的信息升级
                var re1 = Entity.UpdateDB(this.AdvWORKFLOW);
                //增加一条实体类审核记录
                if (!re1.Flag) { throw new Exception(re.Msg); }
                var re2 = this.AdvWORKFLOW.Workflow.GetDefaultInststep().Static_WORKFLOW_INSTSTEP_InitWorkFlowStep(conclusion, this.LinkInfo, this.Entity);
                if (!re2.Flag) { throw new Exception(re.Msg); }
                return new CSException(true, "审核成功，记录已写入");
                //var dataList = instDB.Set(tableType).SqlQuery("select * from " + tableName + " where ID = :p0 " + tempSql, int.Parse(id)).ToListAsync();
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }
        }

        /// <summary>
        /// 该用户权限下是否能撤回该审核线的审核动作(待编)
        /// </summary>
        /// <param name="userhelper"></param>
        /// <returns></returns>
        //public CSException VerifyRedoable()
        //{


        //}


    }

    /// <summary>
    /// 单个审核操作实体
    /// </summary>
    public class VerifyOper : IVerifyOper
    {
        /// <summary>
        /// 该审核操作涉及的审核操作线实体
        /// </summary>
        public virtual List<IVerifyInfo> VerifyInfoList { get; set; }

        /// <summary>
        /// 审核操作名称
        /// </summary>
        public virtual string VeriName { get; set; }

        /// <summary>
        /// 审核被动实体
        /// </summary>
        public virtual IVerifyEntity Entity { get; set; }

        /// <summary>
        /// 审核的流程节点信息
        /// </summary>
        public virtual AdvWorkFlow Advworkflow { get; set; }

        /// <summary>
        /// 审核操作实例初始化
        /// </summary>
        /// <param name="link">同名操作连线</param>
        /// <param name="advworkflow">审核的实体类的流程</param>
        public  VerifyOper(IWORKFLOW_NODE start_node, List<IWORKFLOW_LINK> link, AdvWorkFlow advworkflow, string[] key)
        {
            try
            {
                if (link.Count() <= 0)
                {
                    throw new Exception("传入0连线");
                }

                this.Entity = advworkflow.GetWorkFLowEntityByKey(key);
                this.VerifyInfoList = new List<IVerifyInfo>();
                var StartNode = start_node;
                foreach (var _link in link)
                {
                    var EndNode = start_node.Static_GetWORKFLOWNodeByid(_link.END_NODE_ID);
                    //注意，这里虽然定制了verifyInfo，但是这个属性是开放的，如果需要扩展类，完全可以在后续操作中填充扩展类替换掉这个verifyinfo，达到效果
                    this.VerifyInfoList.Add(new VerifyInfo(_link, Entity, advworkflow));
                }
                this.VeriName = link[0].FORMULA;
                this.Advworkflow = advworkflow;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  VerifyOper(string FORMULA, AdvWorkFlow advworkflow, IVerifyEntity entity)
        {
            try
            {
                this.Entity = entity;

                var res = entity.GetCurrentNode().GetLinkListStartedBythis();
                
                var LinkList = (from x in res
                                where (x.FORMULA == FORMULA && x.START_NODE_ID == entity.AUDITSTEP_ID)
                                select x).ToList();
                if (LinkList.Count() <= 0)
                {
                    throw new Exception("没有相关连线，错误操作");
                }
                this.VerifyInfoList = new List<IVerifyInfo>();

                foreach (var _link in LinkList)
                {
                    this.VerifyInfoList.Add(new VerifyInfo(_link, Entity, advworkflow));
                }
                this.VeriName = LinkList[0].FORMULA;
                this.Advworkflow = advworkflow;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public VerifyOper(List<IWORKFLOW_LINK> LinkList, AdvWorkFlow advworkflow, IVerifyEntity entity)
        {
            try
            {
                this.Entity = entity;

                this.VerifyInfoList = new List<IVerifyInfo>();

                foreach (var _link in LinkList)
                {
                    this.VerifyInfoList.Add(new VerifyInfo(_link, Entity, advworkflow));
                }
                this.VeriName = LinkList[0].FORMULA;
                this.Advworkflow = advworkflow;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 执行审核过程
        /// </summary>
        /// <param name="condition">审核条件</param>
        /// <param name="conclusion">审核结论</param>
        /// <returns></returns>
        public virtual CSException DoVerify(string[] condition, string conclusion)
        {
            if (condition.Count() == 0)
            {
                condition = new string[] { "", null };
            }
            //条件筛选审核，只做符合条件的审核路线                 
            if (this.VerifyInfoList.Count() <= 0)
            {
                return new CSException("出现错误没有符合条件的审核办法");
            }
            var VeriLink = (from x in this.VerifyInfoList
                            where condition.Contains(x.LinkInfo.LINK_CONDITION)
                            select x).ToList();
            var cnt = VeriLink.Count();
            if (cnt <= 0)
            {
                return new CSException("出现错误没有符合条件的审核办法");
            }
            if (cnt == 1)//只有一条线，走单线程审核程序
            {
                var re = VeriLink[0].VerifySingle(conclusion);
                return re;
            }
            else//审核程序会产生两个审核结果
            {
                try
                {
                    var re = VeriLink[0].VerifySingle(conclusion);
                    //单线审核结束,下面是其他线的审核办法，即创造一个新实例
                    for (var i = 1; i < cnt; i++)
                    {
                        var endnode = this.VerifyInfoList[i].EndNodeInfo;
                        var newentity = this.Entity.CreateNewVerifyEntity(endnode);
                        newentity.AddDB(this.Advworkflow);
                        //创造一个除REC外同名实例，把状态等同于endid
                    }
                    return new CSException(true, "成功审核，记录已经写入");

                }
                catch (Exception ex)
                {
                    return new CSException(ex.Message);
                }
            }
        }


     
    }
    /// <summary>
    /// 审核辅助类——当访问一个审核页面时的交流信息框架，审核系统对外出口类
    /// </summary>
    public class LGWBVerifyHelper : IVerifyHelper
    {

        /// <summary>
        /// 审核页面相关的审核操作列，比如通过、撤回、否决
        /// </summary>
        public virtual Dictionary<string, IVerifyOper> VeriOperList { get; set; }

        /// <summary>
        /// 审核相关工作流信息
        /// </summary>
        protected virtual AdvWorkFlow AdvWorkFlow { get; set; }
        protected virtual IAdvanceUserInfo UserInfo { get; set; }

        public virtual IVerifyEntity Entity { get; set; }

        public virtual IWORKFLOW_NODE StartNode { get; set; }


        public LGWBVerifyHelper() { }
        protected  string VeriConsole = "/Basic/DoVerify";
        /// <summary>
        /// 初始化节点
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="workflow_nodeid_start"></param>
        public  LGWBVerifyHelper(IWORKFLOW workflow, IVerifyEntity entity, IUserInfo userinfo)
        {
            this.AdvWorkFlow = new AdvWorkFlow(workflow);
            this.Entity = entity;
            this.UserInfo = userinfo.AdvanceUserInfo();
            this.VeriOperList = this.GetThisVerifyOperList();
            this.StartNode = this.Entity.GetCurrentNode();
        }

        /// <summary>
        /// 在该实体情况下，是否有进入审核该实体的权力（条件1，该用户可以审核该节点，条件2，该实体满足审核验证前置）
        /// </summary>
        /// <returns></returns>
        public CSException AbleToEnterThisEntityToVerify()
        {
            var re1 = this.UserInfo.User_VerifyAble_Node(this.StartNode);
            var re2 = this.Entity.EntityVeri_Precondition_Comfirmed(this.UserInfo);
            if (re1.Flag && re2.Flag)
            {
                return new CSException();
            }
            else
            {
                return new CSException(re1.Msg + re2.Msg);
            }
        }

        protected virtual Dictionary<string, IVerifyOper> GetThisVerifyOperList()
        {
            var res = new Dictionary<string, IVerifyOper>();

            var startid = this.Entity.AUDITSTEP_ID;
            var linkList = this.Entity.GetCurrentNode().GetLinkListStartedBythis().GroupBy(x=>x.FORMULA);
            foreach (var in_linkList in linkList)
            {

                var newoper = new VerifyOper(in_linkList.ToList(), this.AdvWorkFlow, this.Entity);
                res.Add(in_linkList.First().FORMULA, newoper);
            }
            return res;
        }

        /// <summary>
        /// 针对该节点的审核操作
        /// </summary>
        /// <param name="formula">操作的名称（通过，否决等）</param>
        /// <param name="condition">操作的条件（空或1、2或自定义）</param>
        /// <returns></returns>
        public virtual CSException DoVerify(string formula, string[] condition, string conclusion)
        {
            try
            {
                var verifyoper =this.VeriOperList[formula];
                var re = verifyoper.DoVerify(condition, conclusion);
                return re;
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }
        }

        //斟酌中
        //public CSException DoRedo()
        //{

        //    return re;
        //}

        /// <summary>
        /// 判断该节点是否能够审核了(在进度已经到了这个节点的时候会因为前置条件未全部满足而不能审核),
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual CSException AbleToVerify()
        {

            var re = this.Entity.EntityVeri_Precondition_Comfirmed(this.UserInfo);

            return re;
        }


        /// <summary>
        /// 获得此次审核的对象实体
        /// </summary>
        /// <returns></returns>
        public virtual IVerifyEntity GetVerifyEntity()
        {
            return this.Entity;
        }

        public virtual string produce_condition(object a, string json)
        {
            var res = "";
            return res;

        }

        /// <summary>
        /// 获得执行此次审核的用户
        /// </summary>
        public virtual IUserInfo GetVerifyUser()
        {
            return this.UserInfo;
        }
        /// <summary>
        /// 专门适配现有请求的审核按键创造，主要是创造结果字典包含个随机字串可用于按钮id
        /// </summary>

        /// <returns></returns>
        public virtual Dictionary<string, string> VerifyOperAndAction()
        {
            var list = this.VerifyAbleLink();
            var newDic = new Dictionary<string, string>();
            foreach (var in_list in list)
            {
                var keystr=(in_list.LINK_CONDITION==null)? in_list.FORMULA:(in_list.LINK_CONDITION+"_"+in_list.FORMULA);
                newDic.Add(keystr,"link"+in_list.WORKFLOWLINK_ID);
            }
            return newDic;
        }

        /// <summary>
        /// 筛选出所有可用于审核的线(如果不想设置线权限，可以传入没有线权限审查的userinfo实例)
        /// </summary>
        /// <returns></returns>
        public virtual List<IWORKFLOW_LINK> VerifyAbleLink()
        {
            var k=new List<IWORKFLOW_LINK>();
            foreach (var a in this.VeriOperList)
            {
                foreach (var b in a.Value.VerifyInfoList)
                {
                    var re = this.UserInfo.User_VerifyAble_Link(b.LinkInfo);
                    if (!re.Flag) { continue; }
                    k.Add(b.LinkInfo);
                }
            }
            return k;
        }

    }



    /// <summary>
    /// 审核前置条件判断辅助类
    /// </summary>
    public class Verify_PreCondition_Comfirmed_Judge : IVerifyAbleJudge
    {
        /// <summary>
        /// 申请人用户信息
        /// </summary>
        public virtual IUserInfo VerifyUser { get; set; }

        /// <summary>
        /// 该申请审核节点的所有前置路径集合
        /// </summary>
        public virtual List<IWORKFLOW_LINK> SameEndLink { get; set; }

        /// <summary>
        /// 同样flow_ID的序列
        /// </summary>
        public virtual List<IVerifyEntity> WorkEntityList { get; set; }


        /// <summary>
        /// 审核前置条件查询看是否合格
        /// </summary>
        /// <param name="entity">审核实体</param>
        /// <param name="Userid">用户名</param>
        public  Verify_PreCondition_Comfirmed_Judge(IVerifyEntity entity, string Userid)
        {
            var endid = entity.AUDITSTEP_ID;
            var linklist = entity.GetCurrentNode().GetLinkListEndedBythis();
            var res = (from x in linklist
                       where x.END_NODE_ID == endid
                       select x).ToList();
            this.SameEndLink = res;
            var res2 = entity.GetListBythisFlowid();
            this.WorkEntityList = res2;
            this.VerifyUser = VerifyUser.AdvanceUserInfo().USERINFO_GetUserINFO(Userid);
        }

        /// <summary>
        /// 要求是任一一个结束后这边就通过审核
        /// </summary>
        /// <returns></returns>
        public virtual CSException JudgeCalc_RandomOne()
        {
            //拥有结束点为当前节点的工作流线的审核起点的集合
            var sameEnd_startNode = this.SameEndLink.Select(x => x.START_NODE_ID).ToList();
            //目前进行到要求节点的工作实体集合
            var OnCurrectEndEntityList = this.WorkEntityList.Where(x => sameEnd_startNode.Contains(x.AUDITSTEP_ID));

            //var sh_code = EPEPHelper.GetEPEPCode("工作节点类别", "审核");
            //var js_code = EPEPHelper.GetEPEPCode("工作节点类别", "结束");
            if (OnCurrectEndEntityList.Count() > 0)
            {
                return new CSException();
            }
            else
            {
                return new CSException(false);
            }

        }

        /// <summary>
        /// 要求所有相关节点达到终点则通过审核
        /// </summary>
        /// <returns></returns>
        public virtual CSException JudgeCalc_AllVer()
        {
            //拥有结束点为当前节点的工作流线的审核起点的集合
            var sameEnd_startNode = this.SameEndLink.Select(x => x.START_NODE_ID).ToList();
            //目前进行到要求节点的工作实体集合
            var OnCurrectEndEntityList = this.WorkEntityList.Where(x => sameEnd_startNode.Contains(x.AUDITSTEP_ID));

            //var sh_code = EPEPHelper.GetEPEPCode("工作节点类别", "审核");
            //var js_code = EPEPHelper.GetEPEPCode("工作节点类别", "结束");
            if (OnCurrectEndEntityList.Count() == this.WorkEntityList.Count())
            {
                return new CSException();
            }
            else
            {
                return new CSException(false);
            }
        }
        public virtual CSException JudgeCalc_SelfCfg()
        {
            return new CSException();
        }

    }

    /// <summary>
    /// 判断是否能进入此次审核的接口
    /// </summary>
    public interface IVerifyAbleJudge
    {
        IUserInfo VerifyUser { get; set; }

        /// <summary>
        /// 申请的审核的开始节点，要排查所有前置路径
        /// </summary>
        List<IWORKFLOW_LINK> SameEndLink { get; set; }

        /// <summary>
        /// 同样flow_ID的序列
        /// </summary>
        List<IVerifyEntity> WorkEntityList { get; set; }

        CSException JudgeCalc_SelfCfg();
    }

    /// <summary>
    /// 审核操作总接口
    /// </summary>
    public interface IVerifyHelper
    {

        /// <summary>
        /// 获得执行此次审核的用户
        /// </summary>
        IUserInfo GetVerifyUser();

        /// <summary>
        /// 获得此次审核的对象实体
        /// </summary>
        /// <returns></returns>
        IVerifyEntity GetVerifyEntity();



        /// <summary>
        /// 获取该实例所有可进行审核与对应的操作方式
        /// </summary>

        /// <returns></returns>
        Dictionary<string, string> VerifyOperAndAction();

        /// <summary>
        /// 执行规定的审核操作并返回操作结果
        /// </summary>

        /// <param name="formula">操作名称</param>
        /// <returns></returns>
        CSException DoVerify(string formula, string[] condition, string conclusion);

        /// <summary>
        /// 检查该审核是否能够进入，有什么前置条件需要满足
        /// </summary>

        CSException AbleToVerify();
    }


    /// <summary>
    /// 审核操作接口
    /// </summary>
    public interface IVerifyOper
    {
        /// <summary>
        /// 该审核操作涉及的审核操作线实体
        /// </summary>
        List<IVerifyInfo> VerifyInfoList { get; set; }

        /// <summary>
        /// 审核操作名称
        /// </summary>
        string VeriName { get; set; }

        /// <summary>
        /// 审核被动实体
        /// </summary>
        IVerifyEntity Entity { get; set; }

        /// <summary>
        /// 审核的流程节点信息
        /// </summary>
        AdvWorkFlow Advworkflow { get; set; }

        /// <summary>
        /// 审核操作实例初始化
        /// </summary>
        /// <param name="link">同名操作连线</param>
        /// <param name="advworkflow">审核的实体类的流程</param>

        /// <summary>
        /// 执行审核过程
        /// </summary>
        /// <param name="condition">审核条件</param>
        /// <param name="conclusion">审核结论</param>
        /// <returns></returns>
         CSException DoVerify(string[] condition, string conclusion);
    }

    /// <summary>
    /// 执行一个审核线所需的资料组
    /// </summary>
    public interface IVerifyInfo
    {
        //该审核所属工作流程信息
        AdvWorkFlow AdvWORKFLOW { get; set; }


        /// <summary>
        /// 审核实体类
        /// </summary>
        IVerifyEntity Entity { get; set; }

        //审核线信息
        IWORKFLOW_LINK LinkInfo { get; set; }

        /// <summary>
        /// 起始节点信息
        /// </summary>

         IWORKFLOW_NODE StartNodeInfo { get; set; }
        /// <summary>
        /// 终止接点信息
        /// </summary>
         IWORKFLOW_NODE EndNodeInfo { get; set; }
        /// <summary>
        /// 单线审核
        /// </summary>
        /// <param name="Condition"></param>
        /// <param name="conclusion"></param>
        /// <returns></returns>
        CSException VerifySingle(string conclusion);


        /// <summary>
        /// 该用户权限下是否能撤回该审核线的审核动作(待编)
        /// </summary>
        /// <param name="userhelper"></param>
        /// <returns></returns>
        //public CSException VerifyRedoable()
        //{


        //}

    }
}
