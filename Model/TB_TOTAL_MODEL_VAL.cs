namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_TOTAL_MODEL_VAL")]
    public partial class TB_TOTAL_MODEL_VAL
    {
        public decimal ID { get; set; }

        public decimal? PATTERN_ID { get; set; }

        [StringLength(64)]
        public string AFFILIATION { get; set; }

        public decimal? YEAR1 { get; set; }

        public decimal? MONTH1 { get; set; }

        public decimal? VALUE1 { get; set; }

        [StringLength(10)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INPUT_TIME { get; set; }

        public decimal? WEIGHT { get; set; }

        public decimal? PLUS_MINUS { get; set; }
    }
}
