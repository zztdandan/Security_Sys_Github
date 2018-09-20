namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.SAFE_HIDDEN_DELAY")]
    public partial class SAFE_HIDDEN_DELAY
    {
        public decimal ID { get; set; }

        public decimal? ENTERING_ID { get; set; }

        public DateTime? ZGQX_OLD { get; set; }

        public DateTime? ZGQX2_NEW { get; set; }

        [StringLength(1024)]
        public string EXTENSION_CAUSE { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }
    }
}
