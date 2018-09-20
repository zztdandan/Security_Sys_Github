using AppBox.Model;
using LGWBVerifySystem;
using System;
using System.Collections.Generic;
namespace AppBox.Verify
{
    public partial class SafeVerify : System.Web.UI.UserControl
    {
        public string WORKFLOW_ID { get; set; }
        public string ENTITY_KEY_ID { get; set; }
        /// <summary>
        /// 部分按钮不予显示
        /// </summary>
        public List<string> BanList { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var advuserinfo = new AdvUserInfo("cookie");
                    var workflow = new VERI_WORKFLOW().Static_GetWORKFLOWByid(this.WORKFLOW_ID);
                    var keyColl = this.ENTITY_KEY_ID.Split(',');
                    IVerifyEntity entity = new AdvWorkFlow(workflow).GetWorkFLowEntityByKey(keyColl);
                    var newVeri = new LGWBVerifyHelper(workflow, entity, advuserinfo);
                    var operDic = newVeri.VerifyOperAndAction();
                    foreach (var in_operDic in operDic)
                    {
                        if (BanList.Contains(in_operDic.Key)) { continue; }
                        FineUI.Button newbtn = new FineUI.Button();
                        newbtn.ID = in_operDic.Value;
                        newbtn.Text = in_operDic.Key;
                        newbtn.Click += new EventHandler(btn_Click);
                        this.Btn_ToolBar.Items.Add(newbtn);
                    }
                }
                catch { }


              
            }

        }

        private void btn_Click(object sender, EventArgs e)
        {
            
        }


    }
}