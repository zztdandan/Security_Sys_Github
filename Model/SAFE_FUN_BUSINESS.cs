namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.SAFE_FUN_BUSINESS")]
    public partial class SAFE_FUN_BUSINESS
    {
        public decimal ID { get; set; }

        [StringLength(64)]
        public string FUN_CODE { get; set; }

        public decimal? BUSINESS_ID { get; set; }

        public decimal? MANIPULATION_NODE { get; set; }

        [StringLength(64)]
        public string MANIPULATION_NAME { get; set; }

        public decimal? OPERATION_TYPE { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }
    }
}
