namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.STD_SAFE_HIDDEN_INFOR")]
    public partial class STD_SAFE_HIDDEN_INFOR
    {
        public decimal ID { get; set; }

        [StringLength(64)]
        public string CLASSES_NAME { get; set; }

        [StringLength(64)]
        public string INFORMATION_NAME { get; set; }

        [StringLength(32)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }

        [StringLength(64)]
        public string CZLX { get; set; }

        [StringLength(64)]
        public string STATUS { get; set; }

        [StringLength(64)]
        public string CLASSES_CODE { get; set; }

        [StringLength(1024)]
        public string DESCRIBE { get; set; }
    }
}
