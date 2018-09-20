namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_FORMULA_ELEMENT")]
    public partial class TB_FORMULA_ELEMENT
    {
        public decimal ID { get; set; }

        public decimal? PATTERN_ID { get; set; }

        public decimal? ARGUMENT_ID { get; set; }

        public decimal? CATELOG { get; set; }

        public decimal? VALUE { get; set; }

        public decimal? PARENT_ID { get; set; }

        public decimal? REPORT_ID { get; set; }

        public decimal? ACTIVE_FLAG { get; set; }

        public decimal? SEC_FLAG { get; set; }
    }
}
