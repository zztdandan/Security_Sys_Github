namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_PATTERN")]
    public partial class TB_PATTERN
    {
        public decimal ID { get; set; }

        [StringLength(64)]
        public string PATTERN_NAME { get; set; }

        [StringLength(64)]
        public string SYMBOL { get; set; }

        public decimal? ISACTIVE { get; set; }

        public decimal? DANGER_THRESHOLD { get; set; }

        public decimal? WARNING_THRESHOLD { get; set; }

        public decimal? ATTENTION_THRESHOLD { get; set; }

        public decimal? MAX_THRESHOLD { get; set; }

        [StringLength(1000)]
        public string FORMULA { get; set; }

        [StringLength(500)]
        public string DESCRIPTION { get; set; }

        [StringLength(500)]
        public string REMARK { get; set; }

        [StringLength(10)]
        public string SET_PEOPLE { get; set; }

        public DateTime? SET_TIME { get; set; }

        [StringLength(10)]
        public string UPDATE_PEOPLE { get; set; }

        public DateTime? UPDATE_TIME { get; set; }

        public DateTime? ACTIVE_TIME { get; set; }

        public decimal? REPORT_ID { get; set; }

        public decimal? PLUS_MINUS { get; set; }

        [StringLength(64)]
        public string AFFILIATION { get; set; }

        [StringLength(64)]
        public string AFFILIATED_DEPARTMENT { get; set; }

        [StringLength(64)]
        public string AFFILIATED_GROUP { get; set; }

        public decimal? WEIGHT { get; set; }
    }
}
