namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.HD_APP_DETAIL")]
    public partial class HD_APP_DETAIL
    {
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

        [StringLength(2)]
        public string WORK_TYPE { get; set; }

        [StringLength(2)]
        public string WORK_LEVEL { get; set; }

        [StringLength(20)]
        public string APPLICANT { get; set; }

        [StringLength(50)]
        public string WORK_UNIT { get; set; }

        [StringLength(14)]
        public string APPLY_TIME { get; set; }

        [StringLength(50)]
        public string BELONG_UNIT { get; set; }

        [StringLength(50)]
        public string WORK_PLACE { get; set; }

        [StringLength(14)]
        public string DATETIME_START { get; set; }

        [StringLength(14)]
        public string DATETIME_END { get; set; }

        [StringLength(30)]
        public string WORK_THEME { get; set; }

        [StringLength(200)]
        public string WORK_CONTENT { get; set; }

        [StringLength(200)]
        public string RISK_ANALYSIS { get; set; }

        [StringLength(200)]
        public string SAFETY_MEASURES { get; set; }

        [StringLength(30)]
        public string WORK_LEADER { get; set; }

        [StringLength(100)]
        public string WORK_KEEPER { get; set; }

        [StringLength(30)]
        public string WORKERS { get; set; }

        [StringLength(30)]
        public string ACCEPTER { get; set; }

        [StringLength(14)]
        public string RECEPT_TIME { get; set; }

        public decimal? HOISTING_WEIGHT { get; set; }

        public decimal? MACHINE_WEIGHT { get; set; }

        [StringLength(2)]
        public string SPECIAL_HOISTING_TYPE { get; set; }

        [StringLength(30)]
        public string PROJECT_LEADER { get; set; }

        [StringLength(2)]
        public string WORK_LEVEL2 { get; set; }

        [StringLength(500)]
        public string WORK_STATE { get; set; }

        [StringLength(100)]
        public string WORK_TYPE2 { get; set; }

        [StringLength(200)]
        public string FINITESPACE_MEDIA { get; set; }

        public decimal? WORK_HEIGHT { get; set; }

        [StringLength(200)]
        public string REMARK { get; set; }

        [StringLength(2)]
        public string PROJECT_STATUS { get; set; }

        [StringLength(13)]
        public string TEL_1 { get; set; }

        [StringLength(13)]
        public string TEL_2 { get; set; }

        [StringLength(30)]
        public string BELONG_LEADER { get; set; }

        [StringLength(100)]
        public string OTHER_WORKS { get; set; }

        public decimal? APPLY_ID { get; set; }

        [StringLength(20)]
        public string REC_ID { get; set; }

        [Key]
        [StringLength(14)]
        public string APPLYID { get; set; }
    }
}
