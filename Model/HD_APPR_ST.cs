namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.HD_APPR_ST")]
    public partial class HD_APPR_ST
    {
        [Key]
        [StringLength(20)]
        public string APPR_ID { get; set; }

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

        [StringLength(20)]
        public string APPLY_ID { get; set; }

        [StringLength(2)]
        public string APPR_STATUS { get; set; }

        [StringLength(50)]
        public string APPR_NOTE { get; set; }
    }
}
