namespace AppBox.Model
{
    using LGWBVerifySystem;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System;

    [Table("SAFE.VERI_WORKFLOW")]
    public partial class VERI_WORKFLOW:IWORKFLOW
    {
        [Key]
        [StringLength(8)]
        public string WORKFLOW_ID { get; set; }

        [StringLength(100)]
        public string TABLEDBCONTEXT { get; set; }

        [StringLength(100)]
        public string TABLENAME { get; set; }

        [StringLength(10)]
        public string WORKFLOW_CODE { get; set; }

        [StringLength(100)]
        public string WORKFLOW_NAME { get; set; }

        [StringLength(14)]
        public string REC_CREATE_TIME { get; set; }

        [StringLength(8)]
        public string REC_CREATOR { get; set; }

        [StringLength(1)]
        public string IS_VALID { get; set; }
         [Display(Name = "flowchartͼƬ"), Column(TypeName = "NCLOB")]
        public string FLOW_PIC { get; set; }


        public IWORKFLOW_INSTSTEP GetDefaultInststep()
        {
            var newstep = new VERI_WORKFLOW_INSTEP().BuildINSTSTEP(this);
            return newstep;
        }

        public IQueryable<IWORKFLOW_INSTSTEP> GetInststepList()
        {
            var list = ((IQueryable<IWORKFLOW_INSTSTEP>)new VERI_WORKFLOW_INSTEP().GetInstepByWorkflow(this));
            return list;
        }

        public IWORKFLOW_INSTSTEP GetLastInststep()
        {
            var query = (IQueryable<IWORKFLOW_INSTSTEP>)new VERI_WORKFLOW_INSTEP().GetInstepByWorkflow(this);
            var last = query.OrderBy(x => x.REC_CREATE_TIME).Last();
            return last;
        }

      

        public IWORKFLOW Static_GetWORKFLOWByid(string id)
        {
            var db = new SAFEDB();
            var res = (IWORKFLOW)(from x in db.VERI_WORKFLOW where x.WORKFLOW_ID == id select x).First();
            res.TableType = Type.GetType(res.TABLENAME);
            res.ContextType = Type.GetType(res.TABLEDBCONTEXT);
            return res;
        }

        public IWORKFLOW Static_GetWORKFLOWByCNAME(string name)
        {
            var db = new SAFEDB();
            var res = (IWORKFLOW)(from x in db.VERI_WORKFLOW where x.WORKFLOW_NAME == name select x).First();
            res.TableType = Type.GetType(res.TABLENAME);
            res.ContextType = Type.GetType(res.TABLEDBCONTEXT);
            return res;
        }

        public IQueryable<IWORKFLOW_NODE> GetWorkFlowNodeList()
        {
            var db = new SAFEDB();
            var res = ((IQueryable<IWORKFLOW_NODE>)(from x in db.VERI_WORKFLOW_NODE
                       where x.WORKFLOW_ID == this.WORKFLOW_ID
                       select x));
            return res;
        }
        public AdvWorkFlow GetThisAdv()
        {
            return new AdvWorkFlow(this);
        }
        [NotMapped]
        public System.Type ContextType
        {
            get;
            set;
        }
        [NotMapped]
        public System.Type TableType
        {
            get;
            set;
        }
    }
}
