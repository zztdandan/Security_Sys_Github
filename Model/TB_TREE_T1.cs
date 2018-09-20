namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_TREE_T1")]
    public partial class TB_TREE_T1
    {
        [Key]
        public decimal NODE_ID { get; set; }

        public decimal? PARENT_ID { get; set; }

        [StringLength(60)]
        public string NODE_NAME { get; set; }

        [StringLength(130)]
        public string URL { get; set; }

        [StringLength(10)]
        public string TARGET { get; set; }

        public decimal? EXPANDED { get; set; }

        [StringLength(64)]
        public string NODE_CODE { get; set; }

        public decimal? TREELEVEL { get; set; }

        [StringLength(500)]
        public string REMARK { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }

        [StringLength(130)]
        public string HELP_URL { get; set; }

        [StringLength(130)]
        public string HELP_ZD_URL { get; set; }

        public decimal? ORD { get; set; }

        public decimal? FLAG_MODEL { get; set; }
    }
}
