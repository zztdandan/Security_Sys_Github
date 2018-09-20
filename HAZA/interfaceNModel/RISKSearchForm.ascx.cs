using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using AppBox.Model;
using FineUI;
using AppBox.CommonHelper;

namespace AppBox.HAZA.interfaceNModel
{
    public partial class RISKSearchForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRISKSearch_DropList();
            }
            else
            {

            }
        }
        #region 绑定下拉菜单
        protected void BindRISKSearch_DropList()
        {
            List<DropListClass> DList1 = new List<DropListClass>();
            var hazalvl_dic = EP_TEPEP01.GetDicByCName("风险等级");
            DList1.Add(new DropListClass("", ""));
            foreach (var a1 in hazalvl_dic)
            {
                DList1.Add(new DropListClass(a1.Key, a1.Value));
            }

            this.RISK_LVL_droplist.DataTextField = "Name";
            RISK_LVL_droplist.DataValueField = "ID";
            RISK_LVL_droplist.DataSource = DList1;
            RISK_LVL_droplist.DataBind();

            List<DropListClass> DList2 = new List<DropListClass>();

            var hazacate_dic = EP_TEPEP01.GetDicByCName("风险数据状态");
            DList2.Add(new DropListClass("", ""));
            foreach (var a1 in hazacate_dic)
            {
                DList2.Add(new DropListClass(a1.Key, a1.Value));
            }
            this.RISK_cate_droplist.DataTextField = "Name";
            RISK_cate_droplist.DataValueField = "ID";
            RISK_cate_droplist.DataSource = DList2;
            RISK_cate_droplist.DataBind();
        }

        #endregion

        /// <summary>
        /// 改变开始时间的改变函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void start_time_picker_1_TextChanged(object sender, EventArgs e)
        {
            if (start_time_picker_1.SelectedDate.HasValue)
            {
                end_time_picker_2.SelectedDate = start_time_picker_1.SelectedDate.Value.AddMonths(1);
            }
        }




        #region 部门窗口选项

        protected void dept_tbxMyBox1_TriggerClick(object sender, EventArgs e)
        {
            this.dept_tbxMyBox1_Window.Hidden = false;
        }

        protected void dept_tbxMyBox1_Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            var deptid = e.CloseArgument;
            this.dept_tbxMyBox1.Text = deptid;
            dept_tbxMyBox1_Window.Hidden = true;
        }
        #endregion

        #region 风险地点选择
        protected void riskloca_tbxMyBox1_TriggerClick(object sender, EventArgs e)
        {
            this.RISKloca_tbxMyBox1_Window.Hidden = false;
        }
        protected void RISKloca_tbxMyBox1_Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {

        }


        #endregion
    }
}