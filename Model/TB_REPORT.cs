namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_REPORT")]
    public partial class TB_REPORT
    {
        public decimal ID { get; set; }

        public decimal? PERIOD_VALUE { get; set; }

        [StringLength(10)]
        public string PERIOD_UNIT { get; set; }

        public DateTime? BEGIN_DATE { get; set; }

        [StringLength(64)]
        public string SEC_CODE { get; set; }

        [StringLength(64)]
        public string KS_CODE { get; set; }

        public decimal? REPORT_LAYER { get; set; }

        [StringLength(64)]
        public string REPORT_NAME { get; set; }

        [StringLength(10)]
        public string SET_PEOPLE { get; set; }

        public DateTime? SET_TIME { get; set; }

        [StringLength(10)]
        public string UPDATE_PEOPLE { get; set; }

        public DateTime? UPDATE_TIME { get; set; }

        [StringLength(500)]
        public string DESCRIPTION { get; set; }

        [StringLength(500)]
        public string REMARK { get; set; }

        public decimal? ISACTIVE { get; set; }

        public decimal? CLASS { get; set; }

        [StringLength(64)]
        public string AFFILIATION { get; set; }

        [StringLength(64)]
        public string AFFILIATED_DEPARTMENT { get; set; }

        [StringLength(64)]
        public string AFFILIATED_GROUP { get; set; }
    }
}
