using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using AppBox.Model;
using FineUI;

namespace AppBox.CommonHelper
{
    public class Notify
    {
        public static void ShowMessage(string str)
        {
            Alert alert = new Alert();
            alert.Message = str;
            alert.Target = Target.Self;
            alert.Title = "通知";
            alert.Show();
        }
        public static void ShowMessageByCode(string code)
        {
            var db = new SAFEDB();
            var res = (from x in db.EP_TEPEP02
                       where x.CODE_CLASS == "HA04" && x.CODE == code
                       select x).First();
            Alert alert = new Alert();
            alert.Message = res.CODE_DESC_2;
            alert.Title = res.CODE_DESC_1;
            alert.Target = Target.Self;
            alert.Title = "通知";
            alert.Show();
        }
    }
}