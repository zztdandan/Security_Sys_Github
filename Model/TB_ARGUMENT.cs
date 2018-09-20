namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_ARGUMENT")]
    public partial class TB_ARGUMENT
    {
        [Key]
        public decimal ARGUMENT_ID { get; set; }

        [StringLength(64)]
        public string ARGUMENT_NAME { get; set; }

        [StringLength(64)]
        public string SYMBOL { get; set; }

        [StringLength(500)]
        public string FORMULA { get; set; }

        public decimal? ISACTIVE { get; set; }

        [StringLength(500)]
        public string ARGUMENT_REMARK { get; set; }

        [StringLength(500)]
        public string DESCRIPTION { get; set; }

        public decimal? ARGUMENT_VALUE { get; set; }

        public decimal? CATELOG { get; set; }

        public decimal? ARGUMENT_LAYER { get; set; }

        [StringLength(10)]
        public string SET_PEOPLE { get; set; }

        public DateTime? SET_TIME { get; set; }

        [StringLength(10)]
        public string UPDATE_PEOPLE { get; set; }

        public DateTime? UPDATE_TIME { get; set; }

        public DateTime? ACTIVE_TIME { get; set; }

        public decimal? CLASS { get; set; }

        [StringLength(64)]
        public string AFFILIATION { get; set; }

        [StringLength(64)]
        public string AFFILIATED_DEPARTMENT { get; set; }

        [StringLength(64)]
        public string AFFILIATED_GROUP { get; set; }
    }
}
