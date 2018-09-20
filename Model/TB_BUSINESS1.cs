namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_BUSINESS1")]
    public partial class TB_BUSINESS1
    {
        [Key]
        public decimal ROLE_ID { get; set; }

        public decimal? NODE_ID { get; set; }

        [StringLength(1024)]
        public string MANIPULATION_NODE { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_DATE { get; set; }
    }
}
