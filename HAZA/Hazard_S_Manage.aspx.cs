using AppBox.CommonHelper;
using AppBox.Model;
using FineUI;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using AppBox;
using AppBox.Model_View;


namespace AppBox.HAZA
{
    public partial class Hazard_S_Manage : PageBase, IHAZASearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                checkbutton();

            }
        }

        private void checkbutton()
        {
            if (GetIdentityName() != "admin")
            {
                CheckPowerWithButton(Btn_AddHAZA, "71", Btn_AddHAZA.ID);
                CheckPowerWithButton(Btn_DelHAZA, "71", Btn_DelHAZA.ID);
                CheckPowerWithButton(Btn_EditHAZA, "71", Btn_EditHAZA.ID);
                CheckPowerWithButton(Btn_VerifyHAZA, "71", Btn_VerifyHAZA.ID);
                CheckPowerWithButton(Btn_ViewHAZA, "71", Btn_ViewHAZA.ID);
            }
        }


        #region 绑定简单控件事件及数据源
        // 关闭弹出窗口

        /// <summary>
        /// 读取下拉列表项
        /// </summary>
        private void BindEnumrableToDropDownList()
        {

            //List<CustomClass> myList = new List<CustomClass>();
            //myList.Add(new CustomClass("1", "可选项1"));
            //myList.Add(new CustomClass("2", "可选项2"));
            //myList.Add(new CustomClass("3", "可选项3"));
            //myList.Add(new CustomClass("4", "可选项4"));
            //myList.A  dd(new CustomClass("5", "可选项5"));
            //myList.Add(new CustomClass("6", "可选项6"));
            //myList.Add(new CustomClass("7", "可选择项7"));
            //myList.Add(new CustomClass("8", "可选择项8"));
            //myList.Add(new CustomClass("9", "可选择项9"));

            //DropDownList1.DataTextField = "Name";
            //DropDownList1.DataValueField = "ID";
            //DropDownList1.DataSource = myList;
            //DropDownList1.DataBind();

        }

        protected void Btn_HAZA_Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {

        }

        /// <summary>
        /// 文件导入函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_AddInRISK_Click(object sender, System.EventArgs e)
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
                var userid = base.GetIdentityName();
                var re0 = TH_THAZA01.BuildListByNPOISheet(sheet, userid);


                if (!re0.Flag)
                {
                    throw new Exception(re0.Msg);
                }

                foreach (var in_hazard in re0.Entity)
                {
                    foreach (var in_risk in in_hazard.RISKLIST)
                    {
                        var re = in_risk.CheckAndSaveRiskinDB();
                        if (!re.Flag)
                        {
                            throw new Exception(re.Msg);
                        }

                    }
                    var re1 = in_hazard.AddSaveEntitytoDB();
                    if (!re1.Flag)
                    {
                        throw new Exception(re1.Msg);
                    }
                }

                Notify.ShowMessage("成功添加所有条目");
                return;

            }
            catch (Exception ex)
            {
                Notify.ShowMessage(ex.Message);
                return;
            }


        }

        #endregion



        protected List<TH_THAZA01> GetGridDataSource()
        {

            var resint = new List<int>();
            foreach (var row in this.HAZAGrid.Rows)
            {
                int ID = int.Parse((string)row.DataKeys[0]);
                resint.Add(ID);

            }
            var res = TH_THAZA01.FindListByIDList(resint);
            return res;


        }

        #region 危险源操作函数 修改、查询、删除、审核、增加等
        //增加函数写在了前台
        /// <summary>
        /// 编辑单个危险源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_EditHAZA_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.HAZAGrid.SelectedRowIndexArray.Length != 1)
                {
                    throw new Exception("没有单选一个危险源");
                }


                var haza_id = this.HAZAGrid.Rows[this.HAZAGrid.SelectedRowIndexArray[0]].DataKeys[0];
                string openUrl = String.Format("~/HAZA/AddEditHAZA.aspx?type=edit&hazaid=" + haza_id);
                PageContext.RegisterStartupScript(String.Format("openTab('{0}');", openUrl));

                //PageContext.RegisterStartupScript(this.Btn_HAZA_Window.GetShowReference(openUrl, "危险源编辑", 800, 600));
                //this.Btn_HAZA_Window.Hidden = false;

            }
            catch (Exception ex)
            {
                Notify.ShowMessage(ex.Message);
            }
        }

        protected void Btn_DelHAZA_Click(object sender, EventArgs e)
        {
            int[] array = this.HAZAGrid.SelectedRowIndexArray;
            foreach (int a in array)
            {
                var ac = HAZAGrid.Rows[a];
                var haza_rec = int.Parse(ac.DataKeys[0].ToString());
                var re = TH_THAZA01.SetStatsAndSave(haza_rec, "删除");
                if (!re.Flag)
                {
                    Notify.ShowMessage(re.Msg);
                    return;
                }

            }
            var searchform = (HAZASearchForm)this.HAZASearchForm;
            searchform.Btn_Search_Click(sender, e);
        }

        //批量审核
        //protected void Btn_PassHAZA_Click(object sender, EventArgs e)
        //{
        //      try
        //    {
        //        if (this.HAZAGrid.SelectedRowIndexArray.Length != 1)
        //        {
        //            throw new Exception("没有单选一个危险源");
        //        }
        //        var selected_index = this.HAZAGrid.SelectedRowIndexArray[0];
        //        string openUrl = String.Format("~/HAZA/RISKDETAIL.aspx?type=add&hazaid=" + haza_id);
        //        PageContext.RegisterStartupScript(this.RISK_DETAIL_Window.GetShowReference(openUrl, "新增风险", 800, 600));
        //        this.RISK_DETAIL_Window.Hidden = false;

        //    }
        //    catch(Exception ex)
        //    {
        //        Notify.ShowMessage(ex.Message);
        //    }
        //}

        protected void Btn_VerifyHAZA_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.HAZAGrid.SelectedRowIndexArray.Length != 1)
                {
                    throw new Exception("没有单选一个危险源");
                }
                var haza_id = int.Parse(this.HAZAGrid.Rows[this.HAZAGrid.SelectedRowIndexArray[0]].DataKeys[0].ToString());
                var selected_index = this.HAZAGrid.SelectedRowIndexArray[0];
                var sh_cate = EP_TEPEP01.GetDicByCName("危险源数据状态").Where(x => x.Value == "审核").FirstOrDefault().Key;

                string openUrl = String.Format("~/HAZA/AddEditHAZA.aspx?type=verify&hazaid=" + haza_id);
                PageContext.RegisterStartupScript(String.Format("openTab('{0}');", openUrl));
            }
            catch (Exception ex)
            {
                Notify.ShowMessage(ex.Message);

            }
        }

        protected void Btn_ViewHAZA_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.HAZAGrid.SelectedRowIndexArray.Length != 1)
                {
                    throw new Exception("没有单选一个危险源");
                }
                var haza_id = this.HAZAGrid.Rows[this.HAZAGrid.SelectedRowIndexArray[0]].DataKeys[0];
                string openUrl = String.Format("~/HAZA/AddEditHAZA.aspx?hazaid=" + haza_id);
                PageContext.RegisterStartupScript(this.Btn_HAZA_Window.GetShowReference(openUrl, "查看危险源", 960, 700));
                this.Btn_HAZA_Window.Hidden = false;

            }
            catch (Exception ex)
            {
                Notify.ShowMessage(ex.Message);
            }
        }

        #endregion

        #region 分页查询相关

        protected void HAZAGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            this.HAZAGrid.PageIndex = e.NewPageIndex;
            this.HAZASearchForm.Btn_Search_Click(sender, e);

        }
        public void HAZAColomn(IQueryable<TH_THAZA01> hazalist)
        {
            var newhazalist = hazalist.OrderBy(x => x.ID);
            var pagehelper = new PageSpreadHelper<TH_THAZA01>(newhazalist, this.HAZAGrid.PageSize);

            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            this.HAZAGrid.RecordCount = pagehelper.TotalCount;

            // 2.获取当前分页数据

            var paged_source = pagehelper.PagedDataSource(this.HAZAGrid.PageIndex);
            // 3.绑定到Grid
            this.HAZAGrid.DataSource = paged_source;
            this.HAZAGrid.DataBind();

        }

        string IHAZASearchPage.GetIdentityName()
        {
          return this.GetIdentityName();
        }


        #endregion
    }

    public interface IHAZASearchPage
    {
        void HAZAColomn(IQueryable<TH_THAZA01> hazalist);
        string GetIdentityName();

    }

}