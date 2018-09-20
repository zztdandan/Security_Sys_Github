using AppBox.CommonHelper;
using AppBox.Model;
using FineUI;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;




namespace AppBox.HAZA.selectWindow
{
    public partial class HAZALOCA_Select : PageBase
    {

        #region 模式切换
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkbutton();
                if (Request.QueryString["type"] != null)
                {
                    SwitchEditMode(Request.QueryString["type"]);
                }
                else
                {
                    SwitchSelectMode();
                }
                var db = new SAFEDB();
                var haza_loca = (from x in db.TH_HAZALOCA
                                 where x.STATS != "04"
                                 orderby x.ID
                                 select x);
                this.BindGrid(haza_loca);
            }
        }

        private void checkbutton()
        {
            if (GetIdentityName() != "admin")
            {
                CheckPowerWithButton(Btn_AddLOCA, "72", Btn_AddLOCA.ID);
                CheckPowerWithButton(Btn_DelLOCA, "72" +
                    "", Btn_DelLOCA.ID);
            }
        }

        /// <summary>
        /// 页面切换成编辑地点模式
        /// </summary>
        /// <param name="type"></param>
        private void SwitchEditMode(string type)
        {
            this.Btn_SelectLOCA.Hidden = true;
            this.Btn_AddLOCA.Hidden = false;
            this.Btn_DelLOCA.Hidden = false;
            this.Btn_AddIn.Hidden = false;
        }
        /// <summary>
        /// 页面切换成选择地点模式
        /// </summary>
        /// <param name="type"></param>
        private void SwitchSelectMode()
        {
            this.Btn_AddLOCA.Hidden = true;
            this.Btn_DelLOCA.Hidden = true;
            this.Btn_AddIn.Hidden = true;
            this.Btn_SelectLOCA.Hidden = false;
        }
        #endregion
        #region 分页查询相关

        private void BindGrid(IQueryable<TH_HAZALOCA> haza_loca)
        {

            var pagehelper = new PageSpreadHelper<TH_HAZALOCA>(haza_loca, this.HAZALOCAGrid.PageSize);

            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            this.HAZALOCAGrid.RecordCount = pagehelper.TotalCount;

            // 2.获取当前分页数据

            var paged_source = pagehelper.PagedDataSource(this.HAZALOCAGrid.PageIndex);
            // 3.绑定到Grid
            this.HAZALOCAGrid.DataSource = paged_source;
            this.HAZALOCAGrid.DataBind();
        }

        /// <summary>
        /// 分页反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void HAZALOCAGrid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            this.HAZALOCAGrid.PageIndex = e.NewPageIndex;
            var res = this.SearchResult();
            this.BindGrid(res);
        }



        /// <summary>
        /// 搜索危险源区域反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SearchButton_Click(object sender, System.EventArgs e)
        {
            var res = this.SearchResult();
            this.BindGrid(res);

        }


        protected IQueryable<TH_HAZALOCA> SearchResult(){
            var loca_name = this.HAZALOCA_NAMEText.Text;
            IQueryable<TH_HAZALOCA> res;
            if (loca_name != "")
            {
                var db = new SAFEDB();
                res = (from x in db.TH_HAZALOCA

                       where x.C_NAME.Contains(loca_name) && x.STATS != "04"
                       orderby x.ID
                       select x);
            }
            else
            {
                var db = new SAFEDB();
                res = (from x in db.TH_HAZALOCA

                       where x.STATS != "04"
                       orderby x.ID
                       select x);
            }


            if (this.dept_tbxMyBox1.Text != "")
            {
                var dept_code = this.dept_tbxMyBox1.Text.Split('_')[0];
                res = (from x in res
                       where x.DEPT == dept_code
                       orderby x.ID
                       select x);
            }
            return res;
        }
        #endregion

        //protected void Btn_DelLOCA_Click(object sender, EventArgs e)
        //        {
        //            var arr = this.HAZALOCAGrid.SelectedRowIndexArray;
        //            foreach (var index_num in arr)
        //            {
        //                var id_key = (string)this.HAZALOCAGrid.Rows[index_num].DataKeys[0];
        //                var selected_loca = TH_HAZALOCA.FindbyID(id_key);
        //                selected_loca.SetStats("删除");
        //            }
        //        }
        //protected List<TH_HAZALOCA> GetGridDataSource()
        //{
        //    var res = new List<TH_HAZALOCA>();
        //    foreach (var row in this.HAZALOCAGrid.Rows)
        //    {
        //        var idkey = (string)row.DataKeys[0];
        //        res.Add(TH_HAZALOCA.FindbyID(idkey));
        //    }
        //    return res;
        //}


        protected void Btn_SelectLOCA_Click(object sender, EventArgs e)
        {
            var arr = this.HAZALOCAGrid.SelectedRowIndexArray;
            if (arr.Count() != 1)
            {
                Notify.ShowMessage("没有选择单个地址，选择无效");

            }
            var ac = HAZALOCAGrid.Rows[arr[0]];
            var LOCAID = ac.DataKeys[0].ToString();
            var LOCANAME = ac.Values[2];
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference(LOCAID + "_" + LOCANAME));
        }

        #region 部门选择(主窗口)
        protected void dept_tbxMyBox1_TriggerClick(object sender, EventArgs e)
        {
            dept_tbxMyBox1_Window.Hidden = false;

        }


        protected void dept_tbxMyBox1_Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            var deptid = e.CloseArgument;
            this.dept_tbxMyBox1.Text = deptid;

            dept_tbxMyBox1_Window.Hidden = true;
        }
        #endregion


        #region 危险源区域表格改动 删除、增加等
        protected List<TH_HAZALOCA> GetGridDataSource()
        {
            var res = new List<TH_HAZALOCA>();
            foreach (var row in this.HAZALOCAGrid.Rows)
            {
                var idkey = (string)row.DataKeys[0];
                res.Add(TH_HAZALOCA.FindbyID(idkey));
            }
            return res;
        }

        protected void Btn_DelLOCA_Click(object sender, EventArgs e)
        {
            var arr = this.HAZALOCAGrid.SelectedRowIndexArray;
            foreach (var index_num in arr)
            {
                var id_key = (string)this.HAZALOCAGrid.Rows[index_num].DataKeys[0];
                var selected_loca = TH_HAZALOCA.FindbyID(id_key);
                selected_loca.SetStatsAndSave("删除");
                selected_loca.ThisEntitySaveChanges();
            }
            var db = new SAFEDB();
            var haza_loca = (from x in db.TH_HAZALOCA
                             where x.STATS != "04"
                             orderby x.ID
                             select x);

            this.BindGrid(haza_loca);
        }

        #endregion






        #region 添加危险源区域小窗口
        /// <summary>
        /// 打开添加危险源区域小窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_AddLOCA_Click(object sender, EventArgs e)
        {
            this.AddLOCA_Window.Hidden = false;
        }

        /// <summary>
        /// 小窗口添加危险源区域按钮反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_AddLOCA_Add_Click(object sender, System.EventArgs e)
        {
            var name = this.AddLOCA_NAMEText.Text;
            var dept = this.dept_tbxMyBox2.Text.Split('_')[0];
            if (name == "" || dept == "")
            {
                Notify.ShowMessage("未填名称或地址");
                return;
            }
            var locaentity = new TH_HAZALOCA(name, dept);
            var re = locaentity.AddtoDB();
            this.AddLOCA_Window.Hidden = true;
        }

        /// <summary>
        /// 关闭窗口，刷新危险源区域画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddLOCA_Window_Close(object sender, WindowCloseEventArgs e)
        {
            var db = new SAFEDB();
            var haza_loca = (from x in db.TH_HAZALOCA
                             where x.STATS != "04"
                             orderby x.ID
                             select x);
            this.BindGrid(haza_loca);
        }

        #endregion



        #region 部门选择（添加窗口）
        protected void dept_tbxMyBox2_TriggerClick(object sender, System.EventArgs e)
        {

            dept_tbxMyBox2_Window.Hidden = false;

        }
        protected void dept_tbxMyBox2_Window_Close(object sender, WindowCloseEventArgs e)
        {
            var deptid = e.CloseArgument;
            this.dept_tbxMyBox2.Text = deptid;

            dept_tbxMyBox2_Window.Hidden = true;
        }
        #endregion

        protected void Btn_AddIn_Click(object sender, EventArgs e)
        {
            try
            {

                string strFileName = this.File_Upload.FileName;
                //验证是否选择了文件
                if ("" == strFileName.Trim())
                {
                    throw new Exception("没有选择文件");

                }

                //验证文件类型是不是Excel
                //if (strFileName.Substring(strFileName.LastIndexOf('.')) != ".xlsx" && strFileName.Substring(strFileName.LastIndexOf('.')) != ".xls")
                //{
                //    throw new Exception("文件类型错误");

                //}

                if (strFileName.Substring(strFileName.LastIndexOf('.')) != ".xls")
                {
                    throw new Exception("文件类型错误");

                }

                //获取上载文件内容
                var fileStream = File_Upload.PostedFile.InputStream;
                NPOI.HSSF.UserModel.HSSFWorkbook wb = new NPOI.HSSF.UserModel.HSSFWorkbook(fileStream);

                if (wb == null)
                {
                    throw new Exception("Excel表格数据为空");


                }
                HSSFSheet sheet = wb.GetSheetAt(0) as HSSFSheet;
                var re0 = TH_HAZALOCA.BuildListByNPOISheet(sheet);
                if (!re0.Flag)
                {
                    throw new Exception(re0.Msg);
                }
                if (re0.Flag)
                {
                    Notify.ShowMessage("成功添加条数:" + re0.Msg);
                }
                else
                {
                    throw new Exception(re0.Msg);
                }

            }
            catch (Exception ex)
            {
                Notify.ShowMessage(ex.Message);
                return;
            }


        }


    }
}