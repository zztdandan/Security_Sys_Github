using System.Collections.Generic;
using System.Data;
using AppBox.Business.Util;

namespace AppBox.Model_View
{


    public class V_INF_EMPLOYEE_1 : IViewEntity
    {
        public List<object> DataList { get; set; }

        public List<V_INF_EMPLOYEE_1_STRUCT> EMPLOYEEList { get; set; }


        public V_INF_EMPLOYEE_1()
        {
            DataSet ds = DbHelperOra.Query("select * from V_INF_EMPLOYEE_1");
            var a = new List<object>();
            this.EMPLOYEEList = new List<V_INF_EMPLOYEE_1_STRUCT>();
            foreach (var in_row in ds.Tables[0].Rows)
            {
                var newitem = new V_INF_EMPLOYEE_1_STRUCT();
                newitem.ID = int.Parse(((DataRow)in_row).ItemArray[0].ToString());
                newitem.CORPCODE = ((DataRow)in_row).ItemArray[1].ToString();
                newitem.CORPNAME = ((DataRow)in_row).ItemArray[2].ToString();
                newitem.SECCODE = ((DataRow)in_row).ItemArray[3].ToString();
                newitem.SECNAME = ((DataRow)in_row).ItemArray[4].ToString();
                newitem.KSCODE = ((DataRow)in_row).ItemArray[5].ToString();
                newitem.KSNAME = ((DataRow)in_row).ItemArray[6].ToString();
                newitem.UNITCODE = ((DataRow)in_row).ItemArray[7].ToString();
                newitem.UNITNAME = ((DataRow)in_row).ItemArray[8].ToString();
                newitem.CODE = ((DataRow)in_row).ItemArray[9].ToString();
                newitem.NAME = ((DataRow)in_row).ItemArray[10].ToString();
                a.Add(newitem);
                this.EMPLOYEEList.Add(newitem);
            }
            this.DataList = a;



        }

        public V_INF_EMPLOYEE_1(string usercode)
        {
            DataSet ds = DbHelperOra.Query("select * from V_INF_EMPLOYEE_1 where CODE='" + usercode + "'");
            var a = new List<object>();
            this.EMPLOYEEList = new List<V_INF_EMPLOYEE_1_STRUCT>();
            foreach (var in_row in ds.Tables[0].Rows)
            {
                var newitem = new V_INF_EMPLOYEE_1_STRUCT();
                newitem.ID = int.Parse(((DataRow)in_row).ItemArray[0].ToString());
                newitem.CORPCODE = ((DataRow)in_row).ItemArray[1].ToString();
                newitem.CORPNAME = ((DataRow)in_row).ItemArray[2].ToString();
                newitem.SECCODE = ((DataRow)in_row).ItemArray[3].ToString();
                newitem.SECNAME = ((DataRow)in_row).ItemArray[4].ToString();
                newitem.KSCODE = ((DataRow)in_row).ItemArray[5].ToString();
                newitem.KSNAME = ((DataRow)in_row).ItemArray[6].ToString();
                newitem.UNITCODE = ((DataRow)in_row).ItemArray[7].ToString();
                newitem.UNITNAME = ((DataRow)in_row).ItemArray[8].ToString();
                newitem.CODE = ((DataRow)in_row).ItemArray[9].ToString();
                newitem.NAME = ((DataRow)in_row).ItemArray[10].ToString();
                a.Add(newitem);
                this.EMPLOYEEList.Add(newitem);
            }
            this.DataList = a;
            var b = new List<ORG_JOBUNITRELATION_V>();


        }


    }

    public partial class V_INF_EMPLOYEE_1_STRUCT
    {
        public decimal? ID { get; set; }


        public string CORPCODE { get; set; }


        public string CORPNAME { get; set; }


        public string SECCODE { get; set; }

        public string SECNAME { get; set; }


        public string KSCODE { get; set; }

        public string KSNAME { get; set; }


        public string UNITCODE { get; set; }


        public string UNITNAME { get; set; }


        public string CODE { get; set; }

        public string NAME { get; set; }
    }
}