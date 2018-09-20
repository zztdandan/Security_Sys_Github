namespace AppBox.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using LGWBVerifySystem;
    [Table("SAFE.VERI_WORKFLOW_LINK")]
    public partial class VERI_WORKFLOW_LINK : IWORKFLOW_LINK
    {
        [Key]
        [StringLength(8)]
        public string WORKFLOWLINK_ID { get; set; }

        [StringLength(50)]
        public string WORKFLOW_ID { get; set; }

        [StringLength(10)]
        public string START_NODE_ID { get; set; }

        [StringLength(10)]
        public string END_NODE_ID { get; set; }

        [StringLength(50)]
        public string FORMULA { get; set; }

        [StringLength(50)]
        public string LINK_CONDITION { get; set; }

        [StringLength(14)]
        public string REC_CREATE_TIME { get; set; }

        [StringLength(8)]
        public string REC_CREATOR { get; set; }

        [StringLength(1)]
        public string IS_VALID { get; set; }

        [StringLength(100)]
        public string LINK_NAME { get; set; }
        
        public VERI_WORKFLOW_LINK() { }

        public object AuthorizeCollection()
        {
            throw new NotImplementedException();
        }

        public IWORKFLOW_NODE GetEndNode()
        {
            var res = new VERI_WORKFLOW_NODE().Static_GetWORKFLOWNodeByid(this.END_NODE_ID);
            return res;
        }

        public IWORKFLOW_NODE GetStartNode()
        {
            var res = new VERI_WORKFLOW_NODE().Static_GetWORKFLOWNodeByid(this.END_NODE_ID);
            return res;
        }

        public IQueryable<IWORKFLOW_LINK> Static_GetLinkByFomulaEntity(string Formula, IVerifyEntity entity)
        {
            var start_node = entity.AUDITSTEP_ID;
            var db = new SAFEDB();
            var res=((IQueryable<IWORKFLOW_LINK>)(from x in db.VERI_WORKFLOW_LINK where x.START_NODE_ID==start_node && x.FORMULA==Formula select x));
            return res;
        }

        public IWORKFLOW_LINK Static_GetWorkFlowLinkByNode(IWORKFLOW_NODE start_node, IWORKFLOW_NODE end_node, IWORKFLOW workflow)
        {
            var db = new SAFEDB();
            var res=(IWORKFLOW_LINK)((from x in db.VERI_WORKFLOW_LINK where x.START_NODE_ID==start_node.NODE_ID && x.END_NODE_ID==end_node.NODE_ID &&x.WORKFLOW_ID==workflow.WORKFLOW_ID select x).First());
            return res;
        }

        public CSException Static_LinkVerifyableByUser(IAdvanceUserInfo userinfo, IWORKFLOW_LINK link)
        {
            return userinfo.User_VerifyAble_Link(link);
        }



    }
}
