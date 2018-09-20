namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.SAFE_ROLEUSERS_T")]
    public partial class SAFE_ROLEUSERS_T
    {
        [Key]
        [Column(Order = 0)]
        public decimal ROLE_ID { get; set; }

        [StringLength(1024)]
        public string C_SECCODE { get; set; }

        [StringLength(1024)]
        public string C_KSCODE { get; set; }

        [StringLength(1024)]
        public string C_UNITCODE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string USER_ID { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }

        public decimal? ID { get; set; }
    }
}
