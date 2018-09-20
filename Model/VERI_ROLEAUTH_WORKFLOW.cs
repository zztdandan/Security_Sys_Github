using LGWBVerifySystem;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.UI.WebControls;
namespace AppBox.Model
{
     [Table("SAFE.VERI_ROLEAUTH_WORKFLOW")]
    public class VERI_ROLEAUTH_WORKFLOW
    {
         [Key]
         [Display(Name = "流程权限表ID，手动填写")]
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int ID { get; set; }


         public decimal ROLE_ID { get; set; }
          [StringLength(8)]
         public string WORKFLOW_ID { get; set; }
    }
}