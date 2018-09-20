namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_COMPANY_INDEX_ASSIGNMENT")]
    public partial class TB_COMPANY_INDEX_ASSIGNMENT
    {
        public decimal ID { get; set; }

        public decimal? REPORT_INDEX_ID { get; set; }

        [StringLength(1024)]
        public string C_SECCODE { get; set; }

        [StringLength(10)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }
    }
}
