namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_TREE_T_POWER")]
    public partial class TB_TREE_T_POWER
    {
        public decimal ID { get; set; }

        public decimal? NODE_ID { get; set; }

        public decimal? POWER_ID { get; set; }

        [StringLength(64)]
        public string POWER_NAME { get; set; }

        [StringLength(500)]
        public string REMARK { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }
    }
}
