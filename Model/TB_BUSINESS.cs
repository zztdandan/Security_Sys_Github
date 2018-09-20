namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_BUSINESS")]
    public partial class TB_BUSINESS
    {
        [Key]
        public decimal BUSINESS_ID { get; set; }

        [StringLength(60)]
        public string BUSINESS_NAME { get; set; }

        [StringLength(64)]
        public string NODE_CODE { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        public decimal? NODE_ID { get; set; }

        public DateTime? INSERT_DATE { get; set; }

        public decimal? OPERATION_TYPE { get; set; }
    }
}
