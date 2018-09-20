using AppBox.Model;
using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using AppBox.Model_View;
namespace AppBox.HAZA.selectWindow
{
    public partial class DeptSelect1 :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                LoadDLData();
            }
        }
        /// <summary>
        /// 填充下拉列表
        /// </summary>
        protected void LoadDLData()
        {
            var db = new SAFEDB();
            var neworg =new ORG_JOBUNITRELATION_V();
            //var a = dbview.ORG_JOBUNITRELATION_V1.Select(x => x).ToList();
            var corp1 = (from x in neworg.NITList
                         group x by new { x.C_SECCODE } into gr1
                         select gr1).ToList();
            List<DropListClass> DList1 = new List<DropListClass>();
            
            DList1.Add(new DropListClass("", ""));
            foreach (var in_corp1 in corp1)
            {
                var code = in_corp1.First().C_SECCODE;
                var name = in_corp1.First().C_SECNAME;
                DList1.Add(new DropListClass(code, code + "_" + name));
            }
            this.SECID_Select.DataTextField = "Name";
            this.SECID_Select.DataValueField = "ID";
            this.SECID_Select.DataSource = DList1;
            this.SECID_Select.DataBind();
        }

        /// <summary>
        /// 选择部门回传函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSelectUNIT_Click(object sender, EventArgs e)
        {
          
            var name = this.SelectedDept.Text;
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference(name));
        }



        protected void SECID_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sec_selected_code = this.SECID_Select.SelectedValue;
            var db = new SAFEDB();
            var neworg = new ORG_JOBUNITRELATION_V();
            var corp3 = (from x in neworg.NITList
                         where x.C_SECCODE == sec_selected_code
                         group x by new { x.C_KSCODE } into gr1
                         select gr1).ToList();
            List<DropListClass> DList1 = new List<DropListClass>();

            DList1.Add(new DropListClass("", ""));
            foreach (var in_corp3 in corp3)
            {
                var code = in_corp3.First().C_KSCODE;
                var name = in_corp3.First().C_KSNAME;
                DList1.Add(new DropListClass(code, code + "_" + name));
            }
            this.KSID_Select.DataTextField = "Name";
            this.KSID_Select.DataValueField = "ID";
            this.KSID_Select.DataSource = DList1;
            this.KSID_Select.DataBind();
            this.SelectedDept.Text = this.SECID_Select.SelectedText;
        }

        protected void KSID_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ks_selected_code = this.KSID_Select.SelectedValue;
            var db = new SAFEDB();
            var neworg = new ORG_JOBUNITRELATION_V();
            var corp4 = (from x in neworg.NITList
                         where x.C_KSCODE == ks_selected_code
                         group x by new { x.C_UNITCODE } into gr1
                         select gr1).ToList();
            List<DropListClass> DList1 = new List<DropListClass>();

            DList1.Add(new DropListClass("", ""));
            foreach (var in_corp4 in corp4)
            {
                var code = in_corp4.First().C_UNITCODE;
                var name = in_corp4.First().C_UNITNAME;
                DList1.Add(new DropListClass(code, code + "_" + name));
            }
            this.UNITID_Select.DataTextField = "Name";
            this.UNITID_Select.DataValueField = "ID";
            this.UNITID_Select.DataSource = DList1;
            this.UNITID_Select.DataBind();
            this.SelectedDept.Text = this.KSID_Select.SelectedText;
        }

        protected void UNITID_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedDept.Text = this.UNITID_Select.SelectedText;
        }
    }
}