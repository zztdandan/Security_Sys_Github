using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppBox.CommonHelper;
using AppBox.Model;
using LGWBVerifySystem;

namespace AppBox.Verify
{
    /// <summary>
    /// fcHandler 的摘要说明
    /// </summary>
    public class fcHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action;
          
            context.Response.ContentType = "text/plain";
            if (context.Request.RequestType.ToLower() == "get")
            {
                action = context.Request.QueryString["action"];
            }
            else
            {
                action = context.Request.Form["action"];
            }
            if (action == "flowchart") {
                string work_flow_id;
                work_flow_id = context.Request.QueryString["flow_id"];

                var db = new SAFEDB();
                var res = (from x in db.VERI_WORKFLOW
                           where x.WORKFLOW_ID == work_flow_id
                           select x).First().FLOW_PIC;
                context.Response.Write(res);
                context.Response.End();
            
            }

            if (action == "Verify")
            {
                var oper_str = context.Request.Form["oper_str"].ToString();
                var entity_key = context.Request.Form["entity_key"].ToString();
                var workflow_id = context.Request.Form["workflow_id"].ToString();
                var conclusion = context.Request.Form["conclusion"].ToString();
                string formula, condition;
                if (oper_str.IndexOf('_') < 0)//没有条件
                {
                    formula = oper_str;
                    condition =null;

                }
                else
                {
                    formula = oper_str.Split('_')[1];
                    condition = oper_str.Split('_')[0];
                }
                string[] conditionstr={condition};
                var workflow = new VERI_WORKFLOW().Static_GetWORKFLOWByid(workflow_id);
                string[] keycoll=entity_key.Split(',');
                var iverifyentity=new AdvWorkFlow(workflow).GetWorkFLowEntityByKey(keycoll);
                var user=new AdvUserInfo("cookie");
                LGWBVerifyHelper newVeri = new LGWBVerifyHelper(workflow, iverifyentity, user);
                var k=newVeri.DoVerify(formula, conditionstr, conclusion);
                context.Response.Write(k.Msg);
                context.Response.End();
            }
            

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}