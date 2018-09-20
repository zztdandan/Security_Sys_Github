namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TB_PROBLEM")]
    public partial class TB_PROBLEM
    {
        public decimal ID { get; set; }

        public decimal? REPORT_BASE_ID { get; set; }

        [StringLength(500)]
        public string PROBLEM_CONTENT { get; set; }

        [StringLength(500)]
        public string SOLUTION { get; set; }

        [StringLength(400)]
        public string APPENDIX1 { get; set; }

        [StringLength(400)]
        public string APPENDIX2 { get; set; }

        [StringLength(400)]
        public string APPENDIX3 { get; set; }

        [StringLength(500)]
        public string REMARK { get; set; }
    }
}
