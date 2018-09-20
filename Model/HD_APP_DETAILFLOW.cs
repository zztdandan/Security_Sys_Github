using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Linq;
using AppBox.admin.Hazard.Model;
using LGWBVerifySystem;
namespace AppBox.Model
{

    [Table("SAFE.HD_APP_DETAILFLOW")]
    public class HD_APP_DETAILFLOW : IVerifyEntity
    {


        public HD_APP_DETAILFLOW(HD_APP_DETAIL det)
        {
            this.HD_APP_DETAIL_ID = det.APPLYID;
            this.FLOW_ID = Guid.NewGuid().ToString("N").Substring(0, 8);
        }
        public HD_APP_DETAILFLOW(){}
        [StringLength(50)]
        public string AUDITSTEP_ID
        {
            get;
            set;
        }

        public CSException AddDB(AdvWorkFlow AdvWork)
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
                    db.HD_APP_DETAILFLOW.Add(this);
                    db.SaveChanges();
                }
                catch
                {
                    if (this.REC_ID == null)
                    {
                        this.REC_ID = Guid.NewGuid().ToString("N").Substring(0, 8);
                    }
                    db.HD_APP_DETAILFLOW.Add(this);
                    db.SaveChanges();
                }
                return new CSException();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

          [StringLength(20)]
        public string DEPT { get; set; }
        public CSException AlterStats(string stats, string audistep, string conclusion)
        {
            try
            {
                this.STATS = stats;
                this.AUDITSTEP_ID = audistep;
               
                return new CSException();
            }
            catch (Exception ex)
            {
                var str = "方法名:" + System.Reflection.MethodBase.GetCurrentMethod().Name + " \n 错误信息: ";
                return new CSException(str + ex.Message);
            }
        }

        public IVerifyEntity CreateNewVerifyEntity(IWORKFLOW_NODE endnode)
        {

            var newVE = new HD_APP_DETAILFLOW();
            newVE.REC_ID = Guid.NewGuid().ToString("N").Substring(0, 8);
            var startnode = endnode;
            newVE.STATS = startnode.ORDER_ID;
            newVE.AUDITSTEP_ID = startnode.NODE_ID;
            newVE.AdvWork = this.AdvWork;
            newVE.FLOW_ID = this.FLOW_ID;
            return newVE;
        }

        public CSException DelDB(AdvWorkFlow AdvWork)
        {
            try
            {
                var db = new SAFEDB();
                db.HD_APP_DETAILFLOW.Remove(this);
                db.SaveChanges();
                return new CSException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CSException EntityVeri_Precondition_Comfirmed(IAdvanceUserInfo userinfo)
        {
            throw new System.NotImplementedException();
        }
        [StringLength(8)]
        public string FLOW_ID
        {
            get;
            set;
        }
        protected AdvWorkFlow _AdvWork;
        [NotMapped]
        public AdvWorkFlow AdvWork
        {
            get
            {
                if (this._AdvWork != null) { return this._AdvWork; }
                var db = new SAFEDB();
                var res = (from x in db.VERI_WORKFLOW
                           where x.TABLENAME == "AppBox.Model.HD_APP_DETAILFLOW"
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
                       where x.TABLENAME == "AppBox.Model.HD_APP_DETAILFLOW"
                       select x).First();
            this._AdvWork = new AdvWorkFlow(res);
            return this._AdvWork;
        }

        public IWORKFLOW_NODE GetCurrentNode()
        {
            var this_nodeid = this.AUDITSTEP_ID;
            var node = new VERI_WORKFLOW_NODE().Static_GetWORKFLOWNodeByid(this_nodeid);
            return node;
        }

        public System.Collections.Generic.List<IVerifyEntity> GetListBythisFlowid()
        {
            var db = new SAFEDB();
            var res = ((IQueryable<IVerifyEntity>)(from x in db.TH_THAZA02
                                                   where x.FLOW_ID == this.FLOW_ID
                                                   select x)).ToList();
            return res;
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
        [Key]
        [StringLength(8)]
        public string REC_ID
        {
            get;

            set;
        }

        [StringLength(14)]
        public string HD_APP_DETAIL_ID
        {
            get;

            set;
        }
        [StringLength(10)]
        public string STATS
        {
            get;
            set;
        }

        public IVerifyEntity StaticGetEntityByid(string id)
        {
            var db = new SAFEDB();
            var res = (IVerifyEntity)db.HD_APP_DETAILFLOW.Find(id);
            return res;
        }

        public CSException UpdateDB(AdvWorkFlow AdvWork)
        {

            var db = new SAFEDB();

            var entry = db.Entry(this);
            entry.State = EntityState.Modified;
            db.SaveChanges();

            return new CSException();
        }

        public HD_APP_DETAILFLOW SetAddFLOW(HD_APP_DETAIL det, IWORKFLOW_NODE workflow_node)
        {
            var newdetflow = new HD_APP_DETAILFLOW(det);

            newdetflow.STATS = workflow_node.ORDER_ID;
            newdetflow.AUDITSTEP_ID = workflow_node.NODE_ID;
            return newdetflow;
        }
    }
}