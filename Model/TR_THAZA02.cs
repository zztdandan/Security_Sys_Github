namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using LGWBVerifySystem;


    [Table("SAFE.TH_THAZA02")]
    public partial class TH_THAZA02 : IVerifyEntity
    {
        #region 属性
        [Key]
        [StringLength(8)]
        public string REC_ID { get; set; }

        public int THAZA01 { get; set; }

        [StringLength(50)]
        public string STATS { get; set; }

        [StringLength(50)]
        public string AUDITSTEP_ID { get; set; }

        [StringLength(8)]
        public string FLOW_ID { get; set; }

        [StringLength(1)]
        public string CLASS_A { get; set; }


        protected AdvWorkFlow _AdvWork;
        [NotMapped]
        public AdvWorkFlow AdvWork
        {
            get
            {
                if (this._AdvWork != null) { return this._AdvWork; }
                var db = new SAFEDB();
                var res = (from x in db.VERI_WORKFLOW
                           where x.TABLENAME == "TH_THAZA02"
                           select x).First();
                this._AdvWork = new AdvWorkFlow(res);
                return this._AdvWork;
            }
            set
            {
                this._AdvWork = value;
            }
        }
        public AdvWorkFlow GetAdvWorkFlow()
        {
            if (this._AdvWork != null) { return this._AdvWork; }
            var db = new SAFEDB();
            var res = (from x in db.VERI_WORKFLOW
                       where x.TABLENAME == "TH_THAZA02"
                       select x).First();
            this._AdvWork = new AdvWorkFlow(res);
            return this._AdvWork;
        }

        public string[] KeyCollection
        {
            get
            {
                string[] key = { this.REC_ID };
                return key;
            }
            set
            {
                string[] key = value.ToString().Split(',');
                this.REC_ID = key[0];
            }
        }

        [NotMapped]

        protected TH_THAZA01 TH_THAZA01
        {
            get
            {
                var db = new SAFEDB();
                var res = (from x in db.TH_THAZA01
                           where x.ID == this.THAZA01
                           select x).First();
                return res;
            }
        }
 
        #endregion

        #region 构造函数
        public TH_THAZA02() { }
        public TH_THAZA02(TH_THAZA01 haza01)
        {
            this.THAZA01 = haza01.ID;
            this.FLOW_ID = Guid.NewGuid().ToString("N").Substring(0, 8);
        }

        #endregion
        #region 数据库相关
        public CSException AddDB(AdvWorkFlow AdvWork)
        {

            return this.AddDB();
        }
        public CSException AddDB()
        {

            try
            {
                var db = new SAFEDB();
                try
                {
                    var res = (from x in db.TH_THAZA02
                               where x.REC_ID == this.REC_ID
                               select x).First();
                    this.REC_ID = Guid.NewGuid().ToString("N").Substring(0, 8);
                    db.TH_THAZA02.Add(this);
                    db.SaveChanges();
                }
                catch
                {
                    if (this.REC_ID == null)
                    {
                        this.REC_ID = Guid.NewGuid().ToString("N").Substring(0, 8);
                    }
                    db.TH_THAZA02.Add(this);
                    db.SaveChanges();
                }
                return new CSException();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public CSException DelDB(AdvWorkFlow AdvWork)
        {
            try
            {
                var db = new SAFEDB();
                db.TH_THAZA02.Remove(this);
                db.SaveChanges();
                return new CSException();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public CSException UpdateDB(AdvWorkFlow AdvWork)
        {
            var db = new SAFEDB();

            var entry = db.Entry(this);
            entry.State = EntityState.Modified;
            db.SaveChanges();

            return new CSException();
        }
        public IVerifyEntity StaticGetEntityByid(string id)
        {
            var db = new SAFEDB();
            var res = (IVerifyEntity)db.TH_THAZA02.Find(id);
            return res;
        }
        #endregion
        #region 构造特殊类型haza02函数
        public TH_THAZA02 SetAddFLOW(TH_THAZA01 haza01, IWORKFLOW_NODE workflow_node)
        {
            var newhaza02 = new TH_THAZA02(haza01);
            //判断新增项是否与A有关
            if (haza01.HAZA_LVL.CompareTo("4A") >= 0)
            {
                newhaza02.CLASS_A = "Y";
            }
            else
            {
                newhaza02.CLASS_A = "N";
            }
            newhaza02.STATS = workflow_node.ORDER_ID;
            newhaza02.AUDITSTEP_ID = workflow_node.NODE_ID;
            return newhaza02;
        }

        public TH_THAZA02 SetEditFLOW(TH_THAZA01 haza01new, TH_THAZA01 haza01old, IWORKFLOW_NODE workflow_node)
        {
            var newhaza02 = new TH_THAZA02(haza01new);
            if (haza01new.HAZA_LVL.CompareTo("4A") >= 0 || haza01old.HAZA_LVL.CompareTo("4A") >= 0)
            {
                newhaza02.CLASS_A = "Y";
            }
            else
            {
                newhaza02.CLASS_A = "N";
            }
            newhaza02.STATS = workflow_node.ORDER_ID;
            newhaza02.AUDITSTEP_ID = workflow_node.NODE_ID;
            return newhaza02;
        }
        public IVerifyEntity CreateNewVerifyEntity(IWORKFLOW_NODE endnode)
        {
            var newVE = new TH_THAZA02();
            newVE.REC_ID = Guid.NewGuid().ToString("N").Substring(0, 8);
            var startnode = endnode;
            newVE.STATS = startnode.ORDER_ID;
            newVE.AUDITSTEP_ID = startnode.NODE_ID;
            newVE.AdvWork = this.AdvWork;
            newVE.FLOW_ID = this.FLOW_ID;
            return newVE;

        }
        #endregion

        #region 业务相关方法 接口实现等
        public IWORKFLOW_NODE GetCurrentNode()
        {
            var this_nodeid = this.AUDITSTEP_ID;
            var node = new VERI_WORKFLOW_NODE().Static_GetWORKFLOWNodeByid(this_nodeid);
            return node;
        }

        public List<IVerifyEntity> GetListBythisFlowid()
        {
            var db = new SAFEDB();
            var res = ((IQueryable<IVerifyEntity>)(from x in db.TH_THAZA02
                                                   where x.FLOW_ID == this.FLOW_ID
                                                   select x)).ToList();
            return res;
        }


        /// <summary>
        /// 制定审核准入规则。比如说，在该审核节点处于194号node时，需要数据库中同样flow的实体，处于195、196、197号各一个，或者要求同样flow的节点全部处于结束节点
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        public CSException EntityVeri_Precondition_Comfirmed(IAdvanceUserInfo userinfo)
        {
            return new CSException();
        }

     public   CSException AlterStats(string stats, string audistep,string conclusion)
        {
            try
            {
                this.STATS = stats;
                this.AUDITSTEP_ID = audistep;
                var cate = this.TH_THAZA01.CheckNode(this.GetCurrentNode());
                return new CSException();
            }
            catch (Exception ex)
            {
                var str = "方法名:" + System.Reflection.MethodBase.GetCurrentMethod().Name + " \n 错误信息: ";
                return new CSException(str + ex.Message);
            }



        }
        #endregion

    }
}
