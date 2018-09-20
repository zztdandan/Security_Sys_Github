namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.SAFE_HIDDEN_LOGIN")]
    public partial class SAFE_HIDDEN_LOGIN
    {
        public decimal ID { get; set; }

        [StringLength(64)]
        public string C_CODE { get; set; }

        [StringLength(64)]
        public string C_PASS { get; set; }

        public decimal? SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }
    }
}
