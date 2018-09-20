using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AppBox.Business.Util;

namespace AppBox.Model_View
{

    /// <summary>
    /// 带功能的view操作函数
    /// </summary>
    public class ORG_JOBUNITRELATION_V : IViewEntity
    {
        public List<object> DataList { get; set; }

        public List<ORG_JOBUNITRELATION_V_STRUCT> NITList { get; set; }
        public ORG_JOBUNITRELATION_V()
        {
            DataSet ds = DbHelperOra.Query("select * from ORG_JOBUNITRELATION_V");
            var a = new List<object>();
            foreach (var in_row in ds.Tables[0].Rows)
            {
                var newitem = new ORG_JOBUNITRELATION_V_STRUCT();
                newitem.ID = int.Parse(((DataRow)in_row).ItemArray[0].ToString());
                newitem.C_CORPCODE = ((DataRow)in_row).ItemArray[1].ToString();
                newitem.C_CORPNAME = ((DataRow)in_row).ItemArray[2].ToString();
                newitem.C_SECCODE = ((DataRow)in_row).ItemArray[3].ToString();
                newitem.C_SECNAME = ((DataRow)in_row).ItemArray[4].ToString();
                newitem.C_KSCODE = ((DataRow)in_row).ItemArray[5].ToString();
                newitem.C_KSNAME = ((DataRow)in_row).ItemArray[6].ToString();
                newitem.C_UNITCODE = ((DataRow)in_row).ItemArray[7].ToString();
                newitem.C_UNITNAME = ((DataRow)in_row).ItemArray[8].ToString();
                a.Add(newitem);
            }
            this.DataList = a;
            this.NITList = a.AsEnumerable().Select(x =>
            {
                ORG_JOBUNITRELATION_V_STRUCT b = (ORG_JOBUNITRELATION_V_STRUCT)x;
                return b;
            }).ToList();
        }
        public ORG_JOBUNITRELATION_V_STRUCT FindDeptById(string id)
        {
            switch (id.Length)
            {
                case 3: { return this.NITList.Where(x => x.C_SECCODE == id).First(); break; }
                case 6: { return this.NITList.Where(x => x.C_KSCODE == id).First(); break; }
                case 9: { return this.NITList.Where(x => x.C_UNITCODE == id).First(); break; }
                default: { return this.NITList.Where(x => id.Contains(x.C_SECCODE)).First(); break; }
            }
        }


    }

    /// <summary>
    /// ORG_JOBUNITRELATION_V的结构体
    /// </summary>
    public class ORG_JOBUNITRELATION_V_STRUCT
    {

        public int? ID { get; set; }


        public string C_CORPCODE { get; set; }

        public string C_CORPNAME { get; set; }


        public string C_SECCODE { get; set; }


        public string C_SECNAME { get; set; }


        public string C_KSCODE { get; set; }


        public string C_KSNAME { get; set; }


        public string C_UNITCODE { get; set; }


        public string C_UNITNAME { get; set; }
    }

    /// <summary>
    /// 用于限定接口的
    /// </summary>
    public interface IViewEntity
    {
        List<Object> DataList { get; }
    }
}
