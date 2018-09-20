using System;
using System.Collections.Generic;
using System.Linq;
using AppBox.CommonHelper;
using AppBox.Model;
using AppBox.Verify;
using FineUI;

namespace AppBox.HAZA
{
    public partial class RISKDETAIL : PageBase
    {

        #region 切换模式
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var _id = Request.QueryString["id"];
                var _type = Request.QueryString["type"];
                var _hazaid = Request.QueryString["hazaid"];
                BindDList();
                if (_type == "add")//添加模式
                {

                    SwitchAddMode(_hazaid);
                }
                else if (_type == "edit")//编辑模式
                {
                    if (_id == null)
                    {
                        throw new Exception("编辑模式没有id");
                    }
                    SwitchEditMode(_id);
                }
                else if (_id != null)//查看模式
                {
                    SwitchViewMode(_id);
                }

            }
        }
        protected void BindDList()
        {
            List<DropListClass> DList1 = new List<DropListClass>();
            var hazalvl_dic = EP_TEPEP01.GetDicByCName("风险状态");
            DList1.Add(new DropListClass("", ""));
            foreach (var a1 in hazalvl_dic)
            {
                DList1.Add(new DropListClass(a1.Key, a1.Value));
            }

            RISK_STATUS.DataTextField = "Name";
            RISK_STATUS.DataValueField = "ID";
            RISK_STATUS.DataSource = DList1;
            RISK_STATUS.DataBind();

        }
        protected void SwitchAddMode(string hazaid)
        {
            this.RISK_Add.Hidden = false;
            this.RISK_Save.Hidden = true;
            this.FEATURE_CODE.Text = hazaid;
            var solist = EP_TEPEP01.GetListByCName("风险处理措施");
            this.RISK_SOL_Grid.DataSource = solist;
            this.REC_CREATE_TIME.SelectedDate = DateTime.Now;
            this.RISK_SOL_Grid.DataBind();
        }
        protected void SwitchEditMode(string id)
        {
            this.RISK_Add.Hidden = true;
            this.RISK_Save.Hidden = false;
            var db = new SAFEDB();
            var risk = (from x in db.TR_TRISK01
                        where x.RISK_ID == id
                        select x).FirstOrDefault();
            this.RISK_ID.Text = risk.RISK_ID;
            this.REC_CREATOR.Text = risk.REC_CREATOR;
            this.REC_CREATE_TIME.SelectedDate = DateTime.ParseExact(risk.REC_CREATE_TIME, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            this.RISK_STATUS.SelectedValue = risk.RISK_STATUS;
            this.RISK_L.Text = risk.RISK_L.ToString();
            this.RISK_E.Text = risk.RISK_E.ToString();
            this.RISK_C.Text = risk.RISK_C.ToString();
            this.RISK_D.Text = risk.RISK_D.ToString();
            this.RISK_LVL.Text = risk.RISK_LVL;
            this.RISK_MOD.Text = risk.RISK_MOD;
            BindSOL_Grid(risk.RISK_SOL);
            this.FEATURE_CODE.Text = risk.FEATURE_CODE;
            this.RISK_DESC.Text = risk.RISK_DECONTENT;
        }



        protected void SwitchViewMode(string id)
        {
            this.RISK_Add.Hidden = true;
            this.RISK_Save.Hidden = true;
            var db = new SAFEDB();
            var risk = (from x in db.TR_TRISK01
                        where x.RISK_ID == id
                        select x).FirstOrDefault();
            this.RISK_ID.Text = risk.RISK_ID;
            this.REC_CREATOR.Text = risk.REC_CREATOR;
            this.REC_CREATE_TIME.SelectedDate = DateTime.ParseExact(risk.REC_CREATE_TIME, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            this.RISK_STATUS.SelectedValue = risk.RISK_STATUS;
            this.RISK_L.Text = risk.RISK_L.ToString();
            this.RISK_E.Text = risk.RISK_E.ToString();
            this.RISK_C.Text = risk.RISK_C.ToString();
            this.RISK_D.Text = risk.RISK_D.ToString();
            this.RISK_MOD.Text = risk.RISK_MOD;
            this.RISK_LVL.Text = risk.RISK_LVL;
            BindSOL_Grid(risk.RISK_SOL);
            this.FEATURE_CODE.Text = risk.FEATURE_CODE;
            this.RISK_DESC.Text = risk.RISK_DECONTENT;
        }

        /// <summary>
        /// 通过字符串绑定
        /// </summary>
        /// <param name="SOL_string"></param>
        protected void BindSOL_Grid(string SOL_string)
        {
            try
            {
                var db = new SAFEDB();
                var sollist = EP_TEPEP01.GetListByCName("风险处理措施");
                this.RISK_SOL_Grid.DataSource = sollist;
                this.RISK_SOL_Grid.DataBind();
                var arr = new List<int>();
                foreach (var row in this.RISK_SOL_Grid.Rows)
                {

                    if (SOL_string.Contains(row.DataKeys[0].ToString()))
                    {
                        arr.Add(row.RowIndex);
                    }
                }
                int[] arr1 = new int[arr.Count()];
                for (var i = 0; i < arr.Count(); i++)
                {
                    arr1[i] = arr[i];
                }
                this.RISK_SOL_Grid.SelectedRowIndexArray = arr1;
            }
            catch { }
          

        }
        #endregion



        #region 风险更改与新增

        protected string ReadSOL_Grid()
        {
            var res = "";
            foreach (var indNum in this.RISK_SOL_Grid.SelectedRowIndexArray)
            {
                res = res + this.RISK_SOL_Grid.Rows[indNum].DataKeys[0];
            }
            return res;
        }
        protected void RISK_Add_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new SAFEDB();
                var risk = new TH_TRISK01("new");
                risk.FEATURE_CODE = this.FEATURE_CODE.Text;
                var parentHAZA = (from x in db.TH_THAZA01
                                  where x.HAZA_ID == risk.FEATURE_CODE
                                  select x).FirstOrDefault();
                var user = new AdvUserInfo(GetIdentityName());
              
                risk.REC_CREATOR = user.USER_ID;
                risk.RISK_DEPT = user.GetDept();
                risk.RISK_STATUS = this.RISK_STATUS.SelectedValue;

                try
                {
                    risk.RISK_L = decimal.Parse(this.RISK_L.Text);
                }
                catch
                {
                    risk.RISK_L = 0;
                }
                try
                {
                    risk.RISK_E = decimal.Parse(this.RISK_E.Text);
                }
                catch
                {
                    risk.RISK_E = 0;
                }
                try
                {
                    risk.RISK_C = decimal.Parse(this.RISK_C.Text);
                }
                catch
                {
                    risk.RISK_C = 0;
                }
                try
                {
                    risk.RISK_D = decimal.Parse(this.RISK_D.Text);
                }
                catch
                {
                    RISKCalc(sender, e);
                    risk.RISK_L = decimal.Parse(this.RISK_D.Text);
                }

                risk.RISK_SOL = ReadSOL_Grid();
                risk.RISK_LVL = this.RISK_LVL.Text;
                risk.RISK_MOD = this.RISK_MOD.Text;
                risk.RISK_DECONTENT = this.RISK_DESC.Text;
                //var re = risk.AddtoDB();
                var a = db.Set<TH_TRISK01>().Add(risk);
                db.SaveChanges();
                db.Dispose();
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("add" + "_" + risk.RISK_ID));
            }
            catch (Exception ex)
            {
                Notify.ShowMessage(ex.Message);
            }


        }

        protected void RISK_Save_Click(object sender, EventArgs e)
        {
            var db = new SAFEDB();
            var risk = (from x in db.TR_TRISK01
                        where x.RISK_ID == this.RISK_ID.Text
                        select x).FirstOrDefault();
            var user = new AdvUserInfo(GetIdentityName());

            risk.REC_CREATOR = user.USER_ID;
            risk.RISK_DEPT = user.GetDept();
            risk.RISK_STATUS = this.RISK_STATUS.SelectedValue;

            try
            {
                risk.RISK_L = decimal.Parse(this.RISK_L.Text);
            }
            catch
            {
                risk.RISK_L = 0;
            }
            try
            {
                risk.RISK_E = decimal.Parse(this.RISK_E.Text);
            }
            catch
            {
                risk.RISK_E = 0;
            }
            try
            {
                risk.RISK_C = decimal.Parse(this.RISK_C.Text);
            }
            catch
            {
                risk.RISK_C = 0;
            }
            try
            {
                risk.RISK_D = decimal.Parse(this.RISK_D.Text);
            }
            catch
            {
                RISKCalc(sender, e);
                risk.RISK_L = decimal.Parse(this.RISK_D.Text);
            }




            risk.RISK_SOL = ReadSOL_Grid();
            risk.RISK_LVL = this.RISK_LVL.Text;
            risk.RISK_MOD = this.RISK_MOD.Text;
            risk.RISK_DECONTENT = this.RISK_DESC.Text;
            risk.SaveRISKChange();
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("edit" + "_" + risk.RISK_ID));

        }

        #endregion

        protected void RISKCalc(object sender, System.EventArgs e)
        {
            try
            {
                var int_L = decimal.Parse(this.RISK_L.Text);
                var int_E = decimal.Parse(this.RISK_E.Text);
                var int_C = decimal.Parse(this.RISK_C.Text);
                decimal int_D;
                string risk_lvl;
                TH_TRISK01.CalcLVL(int_L, int_E, int_C, out int_D, out risk_lvl);
                this.RISK_D.Text = int_D.ToString();
                this.RISK_LVL.Text = risk_lvl;

            }
            catch (Exception ex)
            {
                var int_D = 0;
                this.RISK_D.Text = int_D.ToString();
                this.RISK_LVL.Text = "1D";
                return;
            }

        }

        protected void RISK_L_TextChanged(object sender, System.EventArgs e)
        {

        }

        protected void RISK_E_TextChanged(object sender, System.EventArgs e)
        {

        }

        protected void RISK_C_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}