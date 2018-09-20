namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.SAFE_HIDDEN_BACK")]
    public partial class SAFE_HIDDEN_BACK
    {
        public decimal ID { get; set; }

        [StringLength(64)]
        public string FLOW_ID { get; set; }

        [StringLength(1024)]
        public string BACK_REASON { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }

        [StringLength(400)]
        public string ZGYQ { get; set; }

        public decimal? ZGLX { get; set; }

        public DateTime? ZGQX { get; set; }

        [StringLength(200)]
        public string ZGYQBZ { get; set; }
    }
}
