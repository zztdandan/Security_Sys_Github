namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_COMPANY_INDEX_DATA")]
    public partial class TB_COMPANY_INDEX_DATA
    {
        public decimal ID { get; set; }

        public decimal? REPORT_INDEX_ID { get; set; }

        public decimal? INDEX_VALUE { get; set; }

        public decimal? YEAR1 { get; set; }

        public decimal? MONTH1 { get; set; }

        public decimal? WEEK1 { get; set; }

        [StringLength(10)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }

        [StringLength(64)]
        public string C_SECCODE { get; set; }
    }
}
