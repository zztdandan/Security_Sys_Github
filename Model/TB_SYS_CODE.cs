namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_SYS_CODE")]
    public partial class TB_SYS_CODE
    {
        public decimal ID { get; set; }

        [StringLength(64)]
        public string TYPE_CODE { get; set; }

        [StringLength(64)]
        public string TYPE_NAME { get; set; }

        [StringLength(64)]
        public string C_CODE { get; set; }

        [StringLength(128)]
        public string C_NAME { get; set; }

        [StringLength(64)]
        public string ORDERID { get; set; }

        [StringLength(512)]
        public string REMARK { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }
    }
}
