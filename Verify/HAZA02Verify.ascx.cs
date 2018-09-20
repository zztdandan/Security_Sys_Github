using AppBox.Model;
using LGWBVerifySystem;
using System;
using System.Linq;
using System.Collections.Generic;

namespace AppBox.Verify
{
    public partial class HAZA02Verify : System.Web.UI.UserControl
    {
        public string WORKFLOW_ID { get; set; }
        public string ENTITY_KEY_ID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var advuserinfo = new AdvUserInfo("cookie");
                    var workflow = new VERI_WORKFLOW().Static_GetWORKFLOWByid(this.WORKFLOW_ID);
                    var keyColl = this.ENTITY_KEY_ID.Split(',');
                    var haza02 = new SAFEDB().TH_THAZA02.Find(keyColl);


                    var newVeri = new LGWBVerifyHelper(workflow, haza02, advuserinfo);
                    var operDic = newVeri.VerifyOperAndAction();
                    var operDic1 = new Dictionary<string, string>(operDic);
                    foreach (var in_operDic in operDic1)
                    {
                        //如果是与A级无关的，删除总调相关
                        if (haza02.CLASS_A == "N" && in_operDic.Key.Contains("总调"))
                        {
                            operDic.Remove(in_operDic.Key);
                        }
                          //如果与A级有关，该项又包含通过，则删除
                        else if (haza02.CLASS_A == "Y" && !in_operDic.Key.Contains("总调") && in_operDic.Key.Contains("通过"))
                        {
                            operDic.Remove(in_operDic.Key);
                        }
                    
                    }
                    this.Veri_Status.Text = newVeri.StartNode.NODE_NAME;
                    if (operDic.Count() != 0)
                    {
                        
                      
                        foreach (var in_operDic in operDic)
                        {

                            FineUI.Button newbtn = new FineUI.Button();
                            newbtn.ID = in_operDic.Value;
                            newbtn.Text = in_operDic.Key;                            
                            //newbtn.CssClass = "btn_verify";
                      
                            newbtn.OnClientClick = "VeriClick('" + in_operDic.Key + "','" + this.ENTITY_KEY_ID + "','01')";
                            this.Btn_ToolBar.Items.Add(newbtn);

                        }
                    }
                    else
                    {
                        this.Veri_Status.Text = newVeri.StartNode.NODE_NAME;
                        FineUI.Label newLabel = new FineUI.Label();
                        newLabel.Text = "没有可用的审核";
                        this.Btn_ToolBar.Items.Add(newLabel);
                    }
                   
                }
                catch { }



            }
        }
      

    }
}