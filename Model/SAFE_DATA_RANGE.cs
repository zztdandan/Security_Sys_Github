namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.SAFE_DATA_RANGE")]
    public partial class SAFE_DATA_RANGE
    {
        public decimal ID { get; set; }

        [StringLength(64)]
        public string FUN_CODE { get; set; }

        public decimal? BUSINESS_ID { get; set; }

        public decimal? NODE_ID { get; set; }

        public decimal? DATA_RANGE { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }
    }
}
