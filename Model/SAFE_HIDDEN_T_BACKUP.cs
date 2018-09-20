namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.SAFE_HIDDEN_T_BACKUP")]
    public partial class SAFE_HIDDEN_T_BACKUP
    {
        public decimal ID { get; set; }

        public decimal? FUN_LEV { get; set; }

        [StringLength(64)]
        public string C_SECONDUNITID { get; set; }

        [StringLength(64)]
        public string YHLB_ID { get; set; }

        public decimal? YHLY { get; set; }

        [StringLength(400)]
        public string YHBGZY { get; set; }

        [StringLength(400)]
        public string JCQKMS { get; set; }

        [StringLength(64)]
        public string CHECK_NAME { get; set; }

        public decimal? YHJB { get; set; }

        public decimal? YHBW { get; set; }

        public DateTime? PCRQ { get; set; }

        [StringLength(200)]
        public string PHOT01 { get; set; }

        [StringLength(200)]
        public string PHOT02 { get; set; }

        [StringLength(200)]
        public string PHOT03 { get; set; }

        [StringLength(200)]
        public string PHOT04 { get; set; }

        [StringLength(200)]
        public string PHOT05 { get; set; }

        public byte? DIFFERENCE { get; set; }

        [StringLength(2)]
        public string ZGQK { get; set; }

        [StringLength(2)]
        public string ZGXGPG { get; set; }

        public decimal? ZGLX { get; set; }

        public DateTime? ZGQX { get; set; }

        [StringLength(400)]
        public string ZGYQ { get; set; }

        public decimal? ZGZJ { get; set; }

        [StringLength(500)]
        public string YFKZCS { get; set; }

        public DateTime? ZGWCRQ { get; set; }

        [StringLength(64)]
        public string ZRDW { get; set; }

        [StringLength(64)]
        public string ZRBM { get; set; }

        [StringLength(64)]
        public string ZRBZ { get; set; }

        [StringLength(64)]
        public string ZRR { get; set; }

        [StringLength(64)]
        public string HISTORY_ID { get; set; }

        [StringLength(2)]
        public string CXXDZG { get; set; }

        [StringLength(512)]
        public string ZGXGPGSM { get; set; }

        [StringLength(64)]
        public string HANDLE_STATUS { get; set; }

        [StringLength(10)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }

        [StringLength(200)]
        public string AFTER_PHOTO1 { get; set; }

        [StringLength(200)]
        public string AFTER_PHOTO2 { get; set; }

        [StringLength(200)]
        public string AFTER_PHOTO3 { get; set; }

        [StringLength(200)]
        public string AFTER_PHOTO4 { get; set; }

        [StringLength(200)]
        public string AFTER_PHOTO5 { get; set; }

        [StringLength(2)]
        public string RENEW_STATUS { get; set; }

        [StringLength(64)]
        public string YHBM { get; set; }

        [StringLength(500)]
        public string FLOW_DIAGRAM { get; set; }

        [StringLength(400)]
        public string EXAM_SITUATION { get; set; }
    }
}
