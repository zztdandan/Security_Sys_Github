using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using LGWBVerifySystem;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AppBox.Model
{
    [Table("SAFE.EP_TEPEP02")]
    public class EP_TEPEP02
    {
        [Key]
        [Required]
        
        public int ID { get; set; }
        [Display(Name = "小代码分类创建时间"), Column(TypeName = "NVARCHAR2"), MaxLength(14)]
        public string REC_CREATE_TIME { get; set; }
        [Display(Name = "小代码创建人"), Column(TypeName = "NVARCHAR2"), MaxLength(14)]
        public string REC_CREATOR { get; set; }
        [Display(Name = "小代码分类代号"), Column(TypeName = "NVARCHAR2"), MaxLength(20)]
        public string CODE_CLASS { get; set; }
        [Display(Name = "小代码"), Column(TypeName = "NVARCHAR2"), MaxLength(20)]
        public string CODE { get; set; }
        [Display(Name = "小代码解释1"), Column(TypeName = "NVARCHAR2"), MaxLength(100)]
        public string CODE_DESC_1 { get; set; }
        [Display(Name = "小代码解释2"), Column(TypeName = "NVARCHAR2"), MaxLength(100)]
        public string CODE_DESC_2 { get; set; }


    }
}