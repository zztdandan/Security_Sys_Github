namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.SAFE_HIDDEN_LOG")]
    public partial class SAFE_HIDDEN_LOG
    {
        public decimal ID { get; set; }

        public decimal? SET_PEOPLE { get; set; }

        [StringLength(64)]
        public string RZ_CZLX { get; set; }

        public DateTime? INSERT_TIME { get; set; }
    }
}
