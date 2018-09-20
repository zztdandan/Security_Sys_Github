using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LGWBVerifySystem
{

    public class AdvWorkFlow
    {
        public string DBContextFullName { get; set; }
        public string TableFullName { get; set; }

        Type TableType { get; set; }
        Type ContextType { get; set; }

        public string WORKFLOW_ID { get; set; }

        public string WORKFLOW_Namespace { get; set; }

        public IWORKFLOW Workflow { get; set; }
        public AdvWorkFlow(IWORKFLOW workflow, string _WORKFLOW_Namespace)
        {
            this.WORKFLOW_Namespace = _WORKFLOW_Namespace;
            this.DBContextFullName = _WORKFLOW_Namespace + workflow.TABLEDBCONTEXT;
            this.TableFullName = _WORKFLOW_Namespace + workflow.TABLENAME;
            this.Workflow = workflow;
            this.WORKFLOW_ID = this.Workflow.WORKFLOW_ID;
        }
        public AdvWorkFlow(IWORKFLOW workflow)
        {

            this.DBContextFullName = workflow.TABLEDBCONTEXT;
            this.ContextType = workflow.ContextType;
            this.TableType = workflow.TableType;
            this.TableFullName = workflow.TABLENAME;
            this.Workflow = workflow;
            this.WORKFLOW_ID = this.Workflow.WORKFLOW_ID;
        }

        protected IWORKFLOW_NODE StartNode { get; set; }
        public IWORKFLOW_NODE GetStartNode(){
            if(this.StartNode!=null){
                return StartNode;
            }
            var node = Workflow.GetWorkFlowNodeList().Where(x => x.NODE_CATEGORY == "00").First();
            return node;
        }
        public IVerifyEntity GetWorkFLowEntityByKey(string[] KeyCollection)
        {
            Type tableType = this.TableType;
            Type contextType = this.ContextType;
            DbContext instDB = (DbContext)Activator.CreateInstance(contextType);
            var table = instDB.Set(tableType);
            var DBEn = (IVerifyEntity)table.Find(KeyCollection);
            return DBEn;
        }

    }
    public interface IWORKFLOW
    {
        /// <summary>
        /// 流程ID
        /// </summary>
        string WORKFLOW_ID { get; set; }
        /// <summary>
        /// 流程
        /// </summary>
        string TABLEDBCONTEXT { get; set; }
        string TABLENAME { get; set; }
        string WORKFLOW_CODE { get; set; }

        Type TableType { get; set; }
        Type ContextType { get; set; }
        IQueryable<IWORKFLOW_NODE> GetWorkFlowNodeList();
        IWORKFLOW Static_GetWORKFLOWByid(string id);
        /// <summary>
        /// 获得该流程最后一个记录
        /// </summary>
        /// <returns></returns>
        IWORKFLOW_INSTSTEP GetLastInststep();
        /// <summary>
        /// 获得该流程所有记录
        /// </summary>
        /// <returns></returns>
        IQueryable<IWORKFLOW_INSTSTEP> GetInststepList();
        /// <summary>
        /// 获得该流程的默认记录作为初始化
        /// </summary>
        /// <returns></returns>
        IWORKFLOW_INSTSTEP GetDefaultInststep();
    }

    public interface IWORKFLOW_LINK
    {

        /// <summary>
        /// 该审核线的注册ID
        /// </summary>
        string WORKFLOWLINK_ID { get; set; }
        /// <summary>
        /// 该审核线所属的流程名称
        /// </summary>
        string WORKFLOW_ID { get; set; }
        /// <summary>
        /// 该审核线的起点
        /// </summary>
        string START_NODE_ID { get; set; }
        /// <summary>
        /// 该审核线的终止点
        /// </summary>
        string END_NODE_ID { get; set; }


        /// <summary>
        /// 这是审核动作字段
        /// </summary>
        string FORMULA { get; set; }

        /// <summary>
        /// 采用该审核link的条件
        /// </summary>
        string LINK_CONDITION { get; set; }

        /// <summary>
        /// 可访问该审核线的权限集
        /// </summary>
        /// <returns></returns>
        object AuthorizeCollection();

        IWORKFLOW_LINK Static_GetWorkFlowLinkByNode(IWORKFLOW_NODE start_node, IWORKFLOW_NODE end_node, IWORKFLOW worflow);
        CSException Static_LinkVerifyableByUser(IAdvanceUserInfo userinfo, IWORKFLOW_LINK link);

        IQueryable<IWORKFLOW_LINK> Static_GetLinkByFomulaEntity(string Formula, IVerifyEntity entity);
        IWORKFLOW_NODE GetStartNode();
        IWORKFLOW_NODE GetEndNode();


        /// <summary>
        /// 审核权限字段，给出该字段的用户可以使用该线
        /// </summary>
        //string AUTH_RIGHT_STRING { get; set; }
    }
    //public static abstract class WORKFLOW_LINKFunc
    //{
    //    public static abstract IWORKFLOW_LINK GetLinkByNode(IWORKFLOW_NODE start_node, IWORKFLOW_NODE end_node, IWORKFLOW worflow);
    //}

    /// <summary>
    /// 审核节点规范接口
    /// </summary>
    public interface IWORKFLOW_NODE
    {
        /// <summary>
        /// 审核节点id
        /// </summary>
        string NODE_ID { get; set; }
        /// <summary>
        /// 审核节点归属流程id
        /// </summary>
        string WORKFLOW_ID { get; set; }

        string NODE_NAME { get; }
        /// <summary>
        /// 归属于此审核节点的权限集
        /// </summary>
        /// <returns></returns>
        object AuthorizeCollection();

        /// <summary>
        /// 该审核节点位于流程中的第几位，或曰该审核节点的流程内编号/序号/编码
        /// </summary>
        string ORDER_ID { get; set; }

        /// <summary>
        /// 该审核节点的类型，根据不同类型做不同应对
        /// </summary>
        string NODE_CATEGORY { get; set; }

        /// <summary>
        /// 审核权限字段，给出该字段的用户可以使用该点
        /// </summary>
        //string AUTH_RIGHT_STRING { get; set; }


        /// <summary>
        ///  根据点id获得点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IWORKFLOW_NODE Static_GetWORKFLOWNodeByid(string id);

        /// <summary>
        /// 根据用户获得该点是否能够审核
        /// </summary>
        /// <param name="userinfo"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        CSException Static_NodeVerifyableByUser(IAdvanceUserInfo userinfo);
        /// <summary>
        /// 获得从此开始的所有线
        /// </summary>
        /// <returns></returns>
        List<IWORKFLOW_LINK> GetLinkListStartedBythis();
        /// <summary>
        /// 获得终结于该点的所有线
        /// </summary>
        /// <returns></returns>
        List<IWORKFLOW_LINK> GetLinkListEndedBythis();
    }

    public interface IWORKFLOW_INSTSTEP
    {
        string INSTEP_CONCLUSION { get; set; }
        string INSTEP_ID { get; set; }
        string INSTEP_USER { get; set; }
        string REC_CREATE_TIME { get; set; }
        string VERIFY_LINK_ID { get; set; }
        string WORKFLOW_EN_FLOW { get; set; }
        string WORKFLOW_ID { get; set; }
        IWORKFLOW_INSTSTEP BuildINSTSTEP(IWORKFLOW workflow, IVerifyEntity entity);
        CSException Static_WORKFLOW_INSTSTEP_InitWorkFlowStep(string conclusion, IWORKFLOW_LINK link, IVerifyEntity entity);
    }

}
