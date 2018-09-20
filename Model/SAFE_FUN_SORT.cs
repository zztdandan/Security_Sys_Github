namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.SAFE_FUN_SORT")]
    public partial class SAFE_FUN_SORT
    {
        public decimal ID { get; set; }

        [StringLength(64)]
        public string FUN_CODE { get; set; }

        [StringLength(64)]
        public string SORT_ID { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }
    }
}
