namespace AppBox.Model
{
    using LGWBVerifySystem;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("SAFE.VERI_WORKFLOW_NODE")]
    public partial class VERI_WORKFLOW_NODE:IWORKFLOW_NODE
    {
        [Key]
        [StringLength(8)]
        public string NODE_ID { get; set; }

        [StringLength(100)]
        public string WORKFLOW_ID { get; set; }

        [StringLength(10)]
        public string ORDER_ID { get; set; }

        [StringLength(10)]
        public string NODE_CATEGORY { get; set; }

        [StringLength(14)]
        public string REC_CREATE_TIME { get; set; }

        [StringLength(8)]
        public string REC_CREATOR { get; set; }

        [StringLength(1)]
        public string IS_VALID { get; set; }
        [NotMapped]
        public string PAGE_URL { get; set; }


        [StringLength(100)]
        public string NODE_NAME { get; set; }

        public VERI_WORKFLOW_NODE() { }
        public object AuthorizeCollection()
        {
            throw new System.NotImplementedException();
        }

        public List<IWORKFLOW_LINK> GetLinkListEndedBythis()
        {
            var db = new SAFEDB();
            var res = ((IQueryable<IWORKFLOW_LINK>)(from x in db.VERI_WORKFLOW_LINK
                                             where x.END_NODE_ID == this.NODE_ID
                                             select x)).ToList();
            return res;
        }

        public List<IWORKFLOW_LINK> GetLinkListStartedBythis()
        {
            var db = new SAFEDB();
            var res = ((IQueryable<IWORKFLOW_LINK>)(from x in db.VERI_WORKFLOW_LINK
                                                    where x.START_NODE_ID == this.NODE_ID
                                                    select x)).ToList();
            return res;
        }

        public IWORKFLOW_NODE Static_GetWORKFLOWNodeByid(string id)
        {
            var db = new SAFEDB();
            var res = (IWORKFLOW_NODE)(from x in db.VERI_WORKFLOW_NODE where x.NODE_ID == id select x).First();
            return res;
        }



        public CSException Static_NodeVerifyableByUser(IAdvanceUserInfo userinfo)
        {
            return userinfo.User_VerifyAble_Node(this);
        }
    }
}
