namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_REPORT_INDEX")]
    public partial class TB_REPORT_INDEX
    {
        public decimal ID { get; set; }

        public decimal? REPORT_ID { get; set; }

        public decimal? INDEX_ID { get; set; }

        [StringLength(10)]
        public string SET_PEOPLE { get; set; }

        public DateTime? SET_TIME { get; set; }

        [StringLength(10)]
        public string UPDATE_PEOPLE { get; set; }

        public DateTime? UPDATE_TIME { get; set; }

        public decimal? ISACTIVE { get; set; }
    }
}
