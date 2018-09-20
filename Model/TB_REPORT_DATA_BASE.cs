namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_REPORT_DATA_BASE")]
    public partial class TB_REPORT_DATA_BASE
    {
        public decimal ID { get; set; }

        [StringLength(500)]
        public string CONCLUSION { get; set; }

        public decimal? REPORT_ID { get; set; }

        public decimal? YEAR1 { get; set; }

        public decimal? MONTH1 { get; set; }

        public decimal? WEEK1 { get; set; }

        [StringLength(10)]
        public string SET_PEOPLE { get; set; }

        public DateTime? SET_TIME { get; set; }

        [StringLength(10)]
        public string UPDATE_PEOPLE { get; set; }

        public DateTime? UPDATE_TIME { get; set; }

        [StringLength(400)]
        public string APPENDIX1 { get; set; }

        [StringLength(400)]
        public string APPENDIX2 { get; set; }

        [StringLength(400)]
        public string APPENDIX3 { get; set; }

        public decimal? CONFIRM_FLAG { get; set; }

        [StringLength(64)]
        public string AFFILIATION { get; set; }

        [StringLength(64)]
        public string AFFILIATED_DEPARTMENT { get; set; }

        [StringLength(64)]
        public string AFFILIATED_GROUP { get; set; }
    }
}
