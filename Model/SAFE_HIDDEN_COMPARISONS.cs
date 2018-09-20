namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.SAFE_HIDDEN_COMPARISONS")]
    public partial class SAFE_HIDDEN_COMPARISONS
    {
        public decimal ID { get; set; }

        public decimal? ROLE_ID { get; set; }

        public decimal? FUNCTION_ID { get; set; }

        public decimal? SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }
    }
}
