using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using AppBox.Model;
using FineUI;
using AppBox;
using AppBox.CommonHelper;
using AppBox.Model_View;
namespace AppBox.HAZA
{
    public partial class HAZASearchForm : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindHAZA_droplist();
            }
            else
            {

            }
        }

        #region BindStringListToDropDownList

        /// <summary>
        /// 绑定下拉——
        /// </summary>
        private void BindHAZA_droplist()
        {
            List<DropListClass> DList1 = new List<DropListClass>();
            var hazalvl_dic = EP_TEPEP01.GetDicByCName("危险源等级");
            DList1.Add(new DropListClass("", ""));
            foreach (var a1 in hazalvl_dic)
            {
                DList1.Add(new DropListClass(a1.Key, a1.Value));
            }

            HAZA_lvl_droplist.DataTextField = "Name";
            HAZA_lvl_droplist.DataValueField = "ID";
            HAZA_lvl_droplist.DataSource = DList1;
            HAZA_lvl_droplist.DataBind();

            List<DropListClass> DList2 = new List<DropListClass>();

            var hazacate_dic = EP_TEPEP01.GetDicByCName("危险源数据状态");
            DList2.Add(new DropListClass("", ""));
            foreach (var a1 in hazacate_dic)
            {
                DList2.Add(new DropListClass(a1.Key, a1.Value));
            }
            HAZA_cate_droplist.DataTextField = "Name";
            HAZA_cate_droplist.DataValueField = "ID";
            HAZA_cate_droplist.DataSource = DList2;
            HAZA_cate_droplist.DataBind();
        }
        #endregion

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
            dept_tbxMyBox1_Window.Hidden = false;

        }

        protected void dept_tbxMyBox1_Window_Close(object sender, WindowCloseEventArgs e)
        {
            var deptid = e.CloseArgument;
            this.dept_tbxMyBox1.Text = deptid;
            dept_tbxMyBox1_Window.Hidden = true;
        }
        #endregion
        //protected void dept_tbxMyBox1_TriggerClick(object sender, EventArgs e)
        //{
        //    Window1.Hidden = false;
        //}
        //protected void btnCloseWindow_Click(object sender, EventArgs e)
        //{
        //    Window1.Hidden = true;
        //}

        /// <summary>
        /// 用search提交后的操作，父页面必须继承接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                //查询模块
          
                var start_time = ((DateTime)this.start_time_picker_1.SelectedDate).ToString("yyyyMMdd") + "000000";
                var end_time = ((DateTime)this.end_time_picker_2.SelectedDate).ToString("yyyyMMdd") + "235959";
                var dept = this.dept_tbxMyBox1.Text.Split('_')[0];
                var haza_name = this.HAZA_name.Text;
                var HAZA_lvl = this.HAZA_lvl_droplist.SelectedValue;
                var HAZA_cate = this.HAZA_cate_droplist.SelectedValue;
                var tmpA = this.hazaloca_tbxMyBox1.Text.LastIndexOf('_');//(确实有下划线的话)
                var HAZA_loca = "";
                if (tmpA != -1)
                {
                    HAZA_loca = this.hazaloca_tbxMyBox1.Text.Substring(0, tmpA);
                }

                var db = new SAFEDB();
                var res = (from x in db.TH_THAZA01
                           where x.REC_CREATETIME.CompareTo(start_time) >= 0 && x.REC_CREATETIME.CompareTo(end_time) <= 0
                           select x);
                if (dept != "" && HAZA_lvl != null)
                {
                    res = res.Where(x => x.HAZA_DEPT.Contains(dept));
                }

                if (haza_name != "" && HAZA_lvl != null)
                {
                    res = res.Where(x => x.HAZA_NAME == haza_name);
                }

                if (HAZA_lvl != "" && HAZA_lvl != null)
                {
                    res = res.Where(x => x.HAZA_LVL == HAZA_lvl);
                }

                if (HAZA_cate != "" && HAZA_lvl != null)
                {
                    res = res.Where(x => x.HAZA_CATEGORY == HAZA_cate);
                }
                else
                {
                    res = res.Where(x => x.HAZA_CATEGORY == "01");
                }
                if (HAZA_loca != "" && HAZA_loca != null)
                {
                    res = res.Where(x => x.HAZA_LOCA == HAZA_loca);
                }
                if (res.Count() > 1000)
                {
                    Notify.ShowMessage("查询太多内容，请尝试缩小查询范围");
                    return;
                }

                //20180911————根据需求，查询时直接读取账号的dept信息，按照二级单位信息直接分配读取数据的内容
          //11

                var a = (IHAZASearchPage)this.Page;

                var user_code=a.GetIdentityName();
                if (user_code != "admin")
                {
                    var user_Entity = new Model_View.V_INF_EMPLOYEE_1(user_code);
                    var user_dept = user_Entity.EMPLOYEEList[0].SECCODE;
                    res = res.Where(x => x.HAZA_DEPT.Contains(user_dept));
                }

                a.HAZAColomn(res);

            }
            catch (Exception ex)
            {
                Notify.ShowMessage(ex.Message);
            }
        }
        public int return1()
        {
            return 1;
        }

        #region 区域选择窗口函数
        protected void hazaloca_tbxMyBox1_TriggerClick(object sender, EventArgs e)
        {
            this.hazaloca_tbxMyBox1_Window.Hidden = false;
        }



        protected void hazaloca_tbxMyBox1_Window_Close(object sender, WindowCloseEventArgs e)
        {
            var hazaloca = e.CloseArgument;
            this.hazaloca_tbxMyBox1.Text = hazaloca;
            this.hazaloca_tbxMyBox1_Window.Hidden = true;
        }
        #endregion
    }

}