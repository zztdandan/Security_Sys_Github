namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.HD_FINITESPACEBOOK")]
    public partial class HD_FINITESPACEBOOK
    {
        [StringLength(20)]
        public string REC_ID { get; set; }

        [StringLength(14)]
        public string CREATE_TIME { get; set; }

        [StringLength(20)]
        public string CREATOR { get; set; }

        [StringLength(14)]
        public string REVISE_TIME { get; set; }

        [StringLength(20)]
        public string REVISER { get; set; }

        [StringLength(1)]
        public string DELETE_FLAG { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string FINITESPACE_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string FINITESPACE_NAME { get; set; }

        [StringLength(200)]
        public string FINITESPACE_LOCATION { get; set; }

        [StringLength(2)]
        public string FINITESPACE_LEVEL { get; set; }

        [StringLength(200)]
        public string HARMFUL_SUBSTANCE { get; set; }

        [StringLength(200)]
        public string RISK_ANALYSIS { get; set; }

        [StringLength(500)]
        public string CONTROL_MEASURES { get; set; }

        [StringLength(500)]
        public string REMARK { get; set; }
    }
}
