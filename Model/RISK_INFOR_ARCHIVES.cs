namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.RISK_INFOR_ARCHIVES")]
    public partial class RISK_INFOR_ARCHIVES
    {
        [StringLength(100)]
        public string CREATOR { get; set; }

        public DateTime? CREATE_DATE { get; set; }

        public DateTime? EDIT_DATE { get; set; }

        public int? ID { get; set; }

        [Key]
        [StringLength(32)]
        public string UUID { get; set; }

        public int? VERSION { get; set; }

        [Required]
        [StringLength(100)]
        public string CORP_NAME { get; set; }

        [Required]
        [StringLength(1000)]
        public string RISK_CONTENT { get; set; }

        [StringLength(100)]
        public string RISK_TYPE { get; set; }

        [StringLength(100)]
        public string RISK_RANK { get; set; }

        [StringLength(100)]
        public string RISK_SOURCE { get; set; }

        [StringLength(100)]
        public string RISK_POSITION { get; set; }

        [StringLength(100)]
        public string INVESTIGATION_PERSON { get; set; }

        public DateTime? INVESTIGATION_DATE { get; set; }

        [Required]
        [StringLength(100)]
        public string CHANGE_TYPE { get; set; }

        [StringLength(100)]
        public string CHANGE_SITUATION { get; set; }

        public DateTime CHANGE_DATE { get; set; }

        public DateTime CHANGE_FINISH_DATE { get; set; }

        [StringLength(100)]
        public string CHANGE_DUTY_UNIT { get; set; }

        [StringLength(100)]
        public string CHANGE_DUTY_PERSON { get; set; }

        [StringLength(400)]
        public string CHANGE_BEFORE_SITUATION { get; set; }

        [StringLength(400)]
        public string CHANGE_LATER_SITUATION { get; set; }

        public DateTime? CHECK_DATE { get; set; }

        [StringLength(100)]
        public string CHECK_UNIT { get; set; }

        [StringLength(100)]
        public string CHECK_SITUATION { get; set; }

        [StringLength(400)]
        public string REMARKS { get; set; }

        public decimal? CHANGE_FUND { get; set; }

        [StringLength(100)]
        public string INTO_MANAGE_PLAN_SITUATION { get; set; }

        public DateTime? INTO_MANAGE_PLAN_DATE { get; set; }

        [StringLength(100)]
        public string CHANGE_GOAL_SITUATION { get; set; }

        public DateTime? CHANGE_GOAL_DATE { get; set; }

        [StringLength(100)]
        public string MEASURES_SITUATION { get; set; }

        public DateTime? MEASURES_DATE { get; set; }

        [StringLength(100)]
        public string CHANGE_FUND_SITUATION { get; set; }

        public DateTime? CHANGE_FUND_DATE { get; set; }

        [StringLength(100)]
        public string CHANGE_DUTY_SITUATION { get; set; }

        public DateTime? CHANGE_DUTY_DATE { get; set; }

        [StringLength(100)]
        public string CHANGE_TIME_SITUATION { get; set; }

        public DateTime? CHANGE_TIME_DATE { get; set; }

        [StringLength(100)]
        public string EMERGENCY_PLAN_SITUATION { get; set; }

        public DateTime? EMERGENCY_PLAN_DATE { get; set; }

        [StringLength(100)]
        public string SUP_DUTY_UNIT { get; set; }

        [StringLength(40)]
        public string SUP_DUTY_PERSON { get; set; }

        public DateTime? LISTING_SUP_DATE { get; set; }

        [StringLength(100)]
        public string LISTING_SUP_RANK { get; set; }

        [StringLength(100)]
        public string LISTING_SUP_NUMBER { get; set; }

        [StringLength(100)]
        public string LISTING_SUP_UNIT { get; set; }

        public DateTime? DELIST_DATE { get; set; }

        [StringLength(100)]
        public string DELIST_UNIT { get; set; }

        [Required]
        [StringLength(32)]
        public string CORP_UUID { get; set; }

        [StringLength(100)]
        public string LISTING_SITUATION { get; set; }

        [StringLength(400)]
        public string RISK_SOLUTIONS_SUMMARY { get; set; }

        [StringLength(400)]
        public string MANAGE_GOAL_TASK { get; set; }

        [StringLength(400)]
        public string TAKEN_MEASURES { get; set; }

        [StringLength(400)]
        public string FUNDS_GOODS_PRACTICAL { get; set; }

        [StringLength(400)]
        public string GOVERN_ORGAN_STAFF { get; set; }

        [StringLength(400)]
        public string MANAGE_TIME_CLAIM { get; set; }

        [StringLength(400)]
        public string SAFETY_EMERGENCY_PLAN { get; set; }

        [StringLength(1000)]
        public string RISK_STATUS_REASON { get; set; }

        [StringLength(1000)]
        public string RISK_DAMAGE_DIFFICULTY { get; set; }

        [StringLength(1000)]
        public string CHECK_DESCRIBE { get; set; }

        [StringLength(32)]
        public string FIND_RISK_UNIT_UUID { get; set; }

        [StringLength(400)]
        public string RISK_DESCRIPTION { get; set; }

        [StringLength(50)]
        public string IS_UP_REPORT { get; set; }

        public DateTime? REPORT_TIME { get; set; }

        [StringLength(500)]
        public string FIND_RISK_UNIT_NAME { get; set; }
    }
}
