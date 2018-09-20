using System;
using System.Collections.Generic;
using System.Linq;
using AppBox.CommonHelper;
using AppBox.Model;
using AppBox.Verify;
using FineUI;

namespace AppBox.HAZA
{
    public partial class AddHAZA : PageBase
    {
        private void BindHAZA_droplist()
        {
            List<DropListClass> DList1 = new List<DropListClass>();
            var hazalvl_dic = EP_TEPEP01.GetDicByCName("危险源等级");
            DList1.Add(new DropListClass("", ""));
            foreach (var a1 in hazalvl_dic)
            {
                DList1.Add(new DropListClass(a1.Key, a1.Value));
            }

            HAZALVL_DList.DataTextField = "Name";
            HAZALVL_DList.DataValueField = "ID";
            HAZALVL_DList.DataSource = DList1;
            HAZALVL_DList.DataBind();
            this.HAZALVLEdit.Text = "0";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindHAZA_droplist();
                if (Request.QueryString["hazaid"] == null)//添加模式
                {
                    this.HAZA_Add.Hidden = false;
                    this.HAZA_Edit.Hidden = true;
                    this.Btn_AddRISK.Hidden = false;
                    this.Btn_DelRISK.Hidden = false;
                    this.Btn_EditRISK.Hidden = false;
                    this.HAZA_DATE.SelectedDate = DateTime.Now;
                    var user = new AdvUserInfo(GetIdentityName()).USER_NAME;
                    this.HAZA_CREATOR.Text = user;
                }
                else//编辑or浏览模式
                {
                    var this_id = int.Parse(Request.QueryString["hazaid"]);
                    if (Request.QueryString["type"] == null)//浏览模式
                    {
                        this.HAZA_Add.Hidden = true;
                        this.HAZA_Edit.Hidden = true;
                        this.Btn_AddRISK.Hidden = true;
                        this.Btn_DelRISK.Hidden = true;
                        this.Btn_EditRISK.Hidden = true;
                        this.SafeVerify.Visible = false;
                    }
                    else if (Request.QueryString["type"] == "edit")//编辑模式
                    {
                        this.HAZA_Add.Hidden = true;
                        this.HAZA_Edit.Hidden = false;
                        this.Btn_AddRISK.Hidden = false;
                        this.Btn_DelRISK.Hidden = false;
                        this.Btn_EditRISK.Hidden = false;
                        this.SafeVerify.Visible = false;
                    }
                    else if (Request.QueryString["type"] == "verify")//审核模式
                    {
                        this.HAZA_Add.Hidden = true;
                        this.HAZA_Edit.Hidden = true;
                        this.Btn_AddRISK.Hidden = true;
                        this.Btn_DelRISK.Hidden = true;
                        this.Btn_EditRISK.Hidden = true;
                        this.SafeVerify.Visible = true;


                    }

                    var db = new SAFEDB();
                    var this_haza = (from x in db.TH_THAZA01
                                     where x.ID == this_id
                                     select x).FirstOrDefault();
                    string haza02_id;
                    try
                    {
                        haza02_id = (from x in db.TH_THAZA02
                                     where x.THAZA01 == this_id
                                     select x).First().REC_ID;
                        SafeVerify.ENTITY_KEY_ID = haza02_id;
                        SafeVerify.WORKFLOW_ID = "01";

                    }
                    catch
                    {

                    }



                    var risk_list = this_haza.GetRiskList();
                    this.HAZA_DATE.SelectedDate = DateTime.ParseExact(this_haza.REC_CREATETIME, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                    this.HAZA_CREATOR.Text = this_haza.REC_CREATOR_G;
                    this.HAZA_NAME.Text = this_haza.HAZA_NAME;
                    this.HAZALVL_DList.SelectedValue = this_haza.HAZA_LVL;
                    this.hazaloca_tbxMyBox1.Text = this_haza.HAZA_LOCA_G;
                    this.HAZA_D_TEXT.Text = this_haza.HAZA_D.ToString();
                    this.BindGrid(risk_list.AsQueryable());
                    this.RefreshHAZA_LVL(risk_list);
                    this.HAZA_CREATOR.Text = this_haza.REC_CREATOR_G;
                    this.HAZA_ID.Text = this_haza.HAZA_ID.ToString();
                    this.ID_HAZA.Text = this_haza.ID.ToString();

                }
            }
        }

        #region 分页查询功能
        protected void HAZA_RISKGrid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            this.HAZA_RISKGrid.PageIndex = e.NewPageIndex;
            var haza01 = TH_THAZA01.FindByID(int.Parse(this.ID_HAZA.Text));
            var list = haza01.GetRiskList();
            this.BindGrid(list.AsQueryable());
        }

        private void BindGrid(IQueryable<TH_TRISK01> risk_list)
        {
            var newList = risk_list.OrderBy(x => x.RISK_ID);
            var pagehelper = new PageSpreadHelper<TH_TRISK01>(risk_list, this.HAZA_RISKGrid.PageSize);

            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            this.HAZA_RISKGrid.RecordCount = pagehelper.TotalCount;

            // 2.获取当前分页数据

            var paged_source = pagehelper.PagedDataSource(this.HAZA_RISKGrid.PageIndex);
            this.HAZA_RISKGrid.DataSource = paged_source;
            this.HAZA_RISKGrid.DataBind();
            // 3.绑定到Grid

        }


        #endregion
        /// <summary>
        /// 查看风险详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void HAZA_RISKGrid_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            //查看详情
            if (e.CommandName == "ActionDetail")
            {
                var keys = this.HAZA_RISKGrid.Rows[e.RowIndex].DataKeys[0];
                var risk_id = keys;
                string openUrl = String.Format("~/HAZA/RISKDETAIL.aspx?id={0}", risk_id, true);
                PageContext.RegisterStartupScript(this.RISK_DETAIL_Window.GetShowReference(openUrl, "查看风险详细信息", 800, 600));

            }
        }
        #region 危险源改动、新增功能
        protected void HAZA_Add_Click(object sender, System.EventArgs e)
        {
            TH_THAZA01 new_haza01 = new TH_THAZA01("new")
            {
                HAZA_NAME = this.HAZA_NAME.Text,
                HAZA_LOCA = this.hazaloca_tbxMyBox1.Text.Substring(0, this.hazaloca_tbxMyBox1.Text.LastIndexOf('_')),
                HAZA_LVL = this.HAZALVL_DList.SelectedValue,
                HAZA_D = decimal.Parse(this.HAZA_D_TEXT.Text),
                HAZA_DEPT = this.hazaloca_tbxMyBox1.Text.Split('_')[0]
            };
            new_haza01.SetStats("审核");
   
            var advuser = new AdvUserInfo(GetIdentityName());
            this.HAZA_CREATOR.Text = advuser.USER_ID;
            new_haza01.REC_CREATOR = advuser.USER_ID;
            var ds = this.GridGetDataSource();
            new_haza01.RISKLIST = ds;
            var csre = new_haza01.Fill_RiskString();
            var node = new VERI_WORKFLOW_NODE().Static_GetWORKFLOWNodeByid("0101");
            var tmp = new_haza01.CheckNode(node);
            var re0 = new_haza01.AddNew();
            try
            {

                var db = new SAFEDB();
                var haza02 = new TH_THAZA02().SetAddFLOW(new_haza01, node);
                var re = haza02.AddDB();
            }
            catch (Exception ex)
            {
                throw new Exception("添加审核权限失败，该用户没有权利添加这个审核");
            }
            if (re0.Flag)
            {
                Notify.ShowMessage("添加成功，请关闭页面");
            }
            else
            {
                Notify.ShowMessage(re0.Msg);
            }
        }

        protected void HAZA_Edit_Click(object sender, System.EventArgs e)
        {
            var haza = new TH_THAZA01("edit", this.HAZA_ID.Text);
            haza.HAZA_NAME = this.HAZA_NAME.Text;
            haza.HAZA_LOCA = this.hazaloca_tbxMyBox1.Text.Substring(0, this.hazaloca_tbxMyBox1.Text.LastIndexOf('_')); ;
            haza.HAZA_LVL = this.HAZALVL_DList.SelectedValue;
            haza.HAZA_D = decimal.Parse(this.HAZA_D_TEXT.Text);
            haza.SetStats("审核");
            var advuser = new AdvUserInfo(GetIdentityName());
            this.HAZA_CREATOR.Text = advuser.USER_ID;
            haza.REC_CREATOR = advuser.USER_ID;
            var worflow = new VERI_WORKFLOW().Static_GetWORKFLOWByCNAME("危险源修改审核");
            var node = new VERI_WORKFLOW_NODE().Static_GetWORKFLOWNodeByid("0301");
            var haza01old = new TH_THAZA01();


            var haza02 = new TH_THAZA02().SetEditFLOW(haza, haza, node);
            var re1 = haza02.AddDB();
            var ds = this.GridGetDataSource();
            haza.RISKLIST = ds;
            var csre = haza.Fill_RiskString();
            var re = haza.AddNew();
            if (re.Flag)
            {
                Notify.ShowMessage("保存成功，关闭页面");
            }
            else
            {
                Notify.ShowMessage(re.Msg);
            }
        }
        #endregion



        #region 表格改动功能

        protected List<TH_TRISK01> GridGetDataSource()
        {
            var res = new List<string>();
            foreach (var risk in this.HAZA_RISKGrid.Rows)
            {
                var riskid = (string)risk.DataKeys[0];
                res.Add(riskid);

            }
            return TH_TRISK01.FindListByIDList(res);
        }

        protected void Btn_AddRISK_Click(object sender, System.EventArgs e)
        {
            var haza_id = this.HAZA_ID.Text;
            string openUrl = String.Format("~/HAZA/RISKDETAIL.aspx?type=add&hazaid=" + haza_id);
            PageContext.RegisterStartupScript(this.RISK_DETAIL_Window.GetShowReference(openUrl, "新增风险", 800, 600));
            this.RISK_DETAIL_Window.Hidden = false;
        }
        protected void RISK_DETAIL_Window_Close(object sender, WindowCloseEventArgs e)
        {
            if (e.CloseArgument.Contains("add"))
            {
                //将grid的datasource读出来，加一项后赋值回去
                var risk_id = e.CloseArgument.ToString().Split('_')[1];
                var ds = GridGetDataSource();
                var addrisk = TH_TRISK01.FindByID(risk_id);
                ds.Add(addrisk);
                this.HAZA_RISKGrid.DataSource = ds;
                this.HAZA_RISKGrid.DataBind();
                this.RefreshHAZA_LVL(ds);
            }
            else if (e.CloseArgument.Contains("edit"))
            {
                //将grid datasource读出来，替换成数据库中的那一项，赋值回去
                var ds = GridGetDataSource();
                var risk_id = e.CloseArgument.ToString().Split('_')[1];
                var db = new SAFEDB();

                var new_risk = (from x in db.TR_TRISK01
                                where x.RISK_ID == risk_id
                                select x).FirstOrDefault();

                var remove_item = ds.Find(x => x.RISK_ID == risk_id);
                ds.Remove(remove_item);
                ds.Add(new_risk);
                this.HAZA_RISKGrid.DataSource = ds;
                this.HAZA_RISKGrid.DataBind();
                this.RefreshHAZA_LVL(ds);
            }

        }
        protected void Btn_DelRISK_Click(object sender, System.EventArgs e)
        {
            var ds = GridGetDataSource();
            var arr = this.HAZA_RISKGrid.SelectedRowIndexArray;
            foreach (var rowind in arr)
            {
                string key = this.HAZA_RISKGrid.Rows[rowind].DataKeys[0].ToString();
                var remove_item = ds.Find(x => x.RISK_ID.CompareTo((string)key) == 0);
                ds.Remove(remove_item);
            }
            this.HAZA_RISKGrid.DataSource = ds;
            this.HAZA_RISKGrid.DataBind();
        }

        protected void Btn_EditRISK_Click(object sender, System.EventArgs e)
        {
            var arr = this.HAZA_RISKGrid.SelectedRowIndexArray;
            if (arr.Count() != 1)
            {
                Notify.ShowMessage("没有选择单一对象！");
                return;
            }
            var risk_id = this.HAZA_RISKGrid.Rows[arr[0]].DataKeys[0];
            string openUrl = String.Format("~/HAZA/RISKDETAIL.aspx?id=" + risk_id + "&type=edit");
            PageContext.RegisterStartupScript(this.RISK_DETAIL_Window.GetShowReference(openUrl, "修改风险", 800, 600));
            this.RISK_DETAIL_Window.Hidden = false;
        }
        #endregion

        #region 自动填充危险源等级
        protected void RefreshHAZA_LVL(List<TH_TRISK01> risk_list)
        {

            if (risk_list.Count == 0 || risk_list == null)
            {
                this.HAZALVL_DList.SelectedValue = "";
                return;
            }
            decimal haza_d;
            string hazalvl;
            TH_THAZA01.ReCalcHAZA_LVL(risk_list, out haza_d, out hazalvl);
            if (this.HAZALVLEdit.Text == "0")
            {
                this.HAZALVL_DList.SelectedValue = hazalvl;
            }
            this.HAZA_D_TEXT.Text = haza_d.ToString();
        }
        #endregion
        #region 区域选择窗口函数
        protected void hazaloca_tbxMyBox1_TriggerClick(object sender, EventArgs e)
        {
            this.hazaloca_tbxMyBox1_Window.Hidden = false;
        }


        protected void HAZALVL_DList_SelectedIndexChanged(object sender, EventArgs e)
        {

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