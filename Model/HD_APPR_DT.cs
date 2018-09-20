namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.HD_APPR_DT")]
    public partial class HD_APPR_DT
    {
        [Key]
        [StringLength(20)]
        public string APPRNOTE_ID { get; set; }

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
        public string APPR_ID { get; set; }

        [StringLength(50)]
        public string APPR_NOTE { get; set; }

        [StringLength(2)]
        public string NOTE_LEVEL { get; set; }

        [StringLength(30)]
        public string APPR_PEOPLE { get; set; }

        [StringLength(100)]
        public string APPR_UNIT { get; set; }

        [StringLength(14)]
        public string APPR_TIME { get; set; }

        [StringLength(1)]
        public string APPR_RESULT { get; set; }

        [StringLength(200)]
        public string REMARK { get; set; }
    }
}
