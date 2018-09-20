namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.SAFE_HIDDEN_FLOW")]
    public partial class SAFE_HIDDEN_FLOW
    {
        public decimal ID { get; set; }

        public decimal? ENTERING_ID { get; set; }

        [StringLength(64)]
        public string REPORT_ASSIGM { get; set; }

        [StringLength(64)]
        public string REPORT_ASSIGM_PERSON { get; set; }

        public DateTime? REPORT_ASSIGM_TIME { get; set; }

        [StringLength(64)]
        public string ACCOUNTABILITY_UNIT { get; set; }

        [StringLength(64)]
        public string ACCOUNTABILITY_DEPARTMENT { get; set; }

        [StringLength(20)]
        public string ACCOUNTABILITY_GROUP { get; set; }

        [StringLength(500)]
        public string RECEIVE { get; set; }

        [StringLength(64)]
        public string RECEIVE_IDENTIFYING { get; set; }

        public DateTime? RECEIVE_TIME { get; set; }

        [StringLength(400)]
        public string ZGYQ { get; set; }

        [StringLength(64)]
        public string HANDLE_STATUS { get; set; }

        [StringLength(64)]
        public string FATHER_FLOWID { get; set; }

        [StringLength(64)]
        public string BACK_STATUS { get; set; }

        public decimal? OLD_FUN_LEV { get; set; }

        [StringLength(200)]
        public string ZGYQBZ { get; set; }

        public decimal? MANAGE_LEVEL { get; set; }

        [StringLength(64)]
        public string ZGR { get; set; }

        public decimal? ZGLX { get; set; }

        public DateTime? ZGQX { get; set; }

        [StringLength(2)]
        public string ZGXGPG { get; set; }

        [StringLength(512)]
        public string ZGXGPGSM { get; set; }

        public decimal? ROLE_ID { get; set; }

        [StringLength(64)]
        public string ZN_ORDER { get; set; }
    }
}
