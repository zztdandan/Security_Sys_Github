using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace AppBox.Model
{
    [Table("SAFE.VERI_ROLEAUTH_NODE")]
    public class VERI_ROLEAUTH_NODE
    {
        [Key]
        [Display(Name = "节点权限表ID，手动填写")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        public decimal ROLE_ID { get; set; }
        [StringLength(8)]
        public string WORKFLOW_NODE_ID { get; set; }
    }
}