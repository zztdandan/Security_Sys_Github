namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.SAFE_EFFECT_T")]
    public partial class SAFE_EFFECT_T
    {
        public decimal ID { get; set; }

        public decimal? ASSESS_TYPE { get; set; }

        [StringLength(64)]
        public string ACCOUNTABILITY_UNIT { get; set; }

        [StringLength(64)]
        public string ACCOUNTABILITY_DEPARTMENT { get; set; }

        [StringLength(10)]
        public string ASSESS_PERSON1 { get; set; }

        [StringLength(10)]
        public string ASSESS_PERSON2 { get; set; }

        [StringLength(200)]
        public string REMARK { get; set; }
    }
}
