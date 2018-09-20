using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AppBox.Model
{
    [Table("SAFE.EP_TEPEP01")]
    public class EP_TEPEP01
    {
        [Key]
        [Required]
        [Display(Name = "小代码主键"), Column(TypeName = "NVARCHAR2"), MaxLength(8)]
        public string ID { get; set; }
        [Display(Name = "小代码分类创建时间"), Column(TypeName = "NVARCHAR2"), MaxLength(14)]
        public string REC_CREATE_TIME { get; set; }
        [Display(Name = "小代码创建人"), Column(TypeName = "NVARCHAR2"), MaxLength(20)]
        public string REC_CREATOR { get; set; }
        [Display(Name = "小代码分类代号"), Column(TypeName = "NVARCHAR2"), MaxLength(20)]
        public string CODE_CLASS { get; set; }
        [Display(Name = "小代码分类中文描述"), Column(TypeName = "NVARCHAR2"), MaxLength(8)]
        public string CODE_NAME { get; set; }
        [Display(Name = "小代码分类中代码字长")]
        public int? CODE_LEN { get; set; }

        public static List<EP_TEPEP02> GetListByCode(string code)
        {
            var db = new SAFEDB();
            var res = (from x in db.EP_TEPEP02
                       where x.CODE_CLASS == code
                       select x).ToList();
            return res;
        }
        public static List<EP_TEPEP02> GetListByCName(string cname)
        {
            var db = new SAFEDB();
            var code = (from x in db.EP_TEPEP01
                        where x.CODE_NAME == cname
                        select x).First().CODE_CLASS;
            var res = (from x in db.EP_TEPEP02
                       where x.CODE_CLASS == code
                       select x).ToList();
            return res;
        }

        public static Dictionary<string, string> GetDicByCode(string code) {
            var list = GetListByCode(code);
            var dic = new Dictionary<string, string>();
            foreach (var a in list)
            {
                dic.Add(a.CODE, a.CODE_DESC_1);
            }
            return dic;
        }

        public static Dictionary<string, string> GetDicByCName(string cname)
        {
            var list = GetListByCName(cname);
            var dic = new Dictionary<string, string>();
            foreach (var a in list)
            {
                dic.Add(a.CODE, a.CODE_DESC_1);
            }
            return dic;
        }
        public static Dictionary<string, string> GetCDicByCName(string cname)
        {
            var list = GetListByCName(cname);
            var dic = new Dictionary<string, string>();
            foreach (var a in list)
            {
                dic.Add(a.CODE_DESC_1, a.CODE);
            }
            return dic;
        }
    }
}