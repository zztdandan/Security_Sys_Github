namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.STD_SAFE_HIDDEN_SORT")]
    public partial class STD_SAFE_HIDDEN_SORT
    {
        public decimal ID { get; set; }

        [StringLength(64)]
        public string NODE_CODE { get; set; }

        [StringLength(64)]
        public string NODE_NAME { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }

        public decimal? TREELEVEL { get; set; }
    }
}
