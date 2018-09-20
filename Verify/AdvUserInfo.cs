using AppBox.Model;
using LGWBVerifySystem;
using System.Collections.Generic;
using System.Linq;
using System;
namespace AppBox.Verify
{
    /// <summary>
    /// 这是个没有审核线判定的userinfo版本
    /// </summary>
    public class AdvUserInfo:IAdvanceUserInfo
    {
       
        public string USER_ID
        {
            get;
            set;
        }

        public string USER_NAME
        {
            get;
            set;
        }
        public SAFE_HIDDEN_USER USER_INFO { get; set; }
        public AdvUserInfo() { }

        protected List<decimal> USER_ROLE_LIST
        {
            get;
            set;
        }
        public IAdvanceUserInfo AdvanceUserInfo()
        {
            var a = new AdvUserInfo();
            a.USER_ID = this.USER_ID;
            a.USER_NAME = this.USER_NAME;
           var db= new SAFEDB();
            a.USER_INFO = (from x in db.SAFE_HIDDEN_USER
                           where x.NAME == this.USER_ID
                           select x).First();
            return a;
        }
        public AdvUserInfo(string console)
        {
            var db = new SAFEDB();
            if (console == "cookie")
            {
                var userid = new PageBase().GetCookieUserID();
            
                var user = (from x in db.SAFE_HIDDEN_USER
                            where x.NAME == userid
                            select x).First();
                this.USER_ID = userid;
                this.USER_NAME = user.CHINESENAME;
                this.USER_INFO = user;

            }
            else
            {
           
                var res = (from x in db.SAFE_HIDDEN_USER
                           where x.NAME == console
                           select x).First();
                this.USER_INFO = res;
                this.USER_ID = res.NAME;
                this.USER_NAME = res.CHINESENAME;
            }
          
            this.USER_ROLE_LIST = (from x in db.SAFE_ROLEUSERS_T
                                   where x.USER_ID == this.USER_ID
                                   select x).Select(x => x.ROLE_ID).ToList();
        }
       
        public AdvUserInfo(IUserInfo userinfo){
            this.USER_ID = userinfo.USER_ID;
            this.USER_NAME = userinfo.USER_NAME;
            var db = new SAFEDB();
            var res=(from x in db.SAFE_HIDDEN_USER
                     where x.NAME == userinfo.USER_ID
                            select x).First();
            this.USER_INFO = res;
        
        }
        protected void Fill_USER_ROLE_LIST()
        {
            var db = new SAFEDB();
            if (this.USER_ROLE_LIST.Count() == 0)
            {
                this.USER_ROLE_LIST = (from x in db.SAFE_ROLEUSERS_T
                                       where x.USER_ID == this.USER_ID
                                       select x).Select(x => x.ROLE_ID).ToList();
            }
             
           
        }
        public AdvUserInfo(SAFE_HIDDEN_USER userinfo)
        {
            this.USER_ID = userinfo.USER_ID;
            this.USER_NAME = userinfo.USER_NAME;
            this.USER_INFO = userinfo;
            var db = new SAFEDB();
            this.USER_ROLE_LIST = (from x in db.SAFE_ROLEUSERS_T
                                   where x.USER_ID == this.USER_ID
                                   select x).Select(x => x.ROLE_ID).ToList();
        }
        public IQueryable<IUserRole> ROLEGROUP_GetRoleListForUser()
        {
            var db = new SAFEDB();
            List<decimal> res1 = (from x in db.SAFE_ROLEUSERS_T
                                 where x.USER_ID == this.USER_ID
                                 select x).Select(x => x.ROLE_ID).ToList();
  
            IQueryable<IUserRole> res2 = (IQueryable<IUserRole>)(from x in db.SAFE_HIDDEN_ROLE where res1.Contains(x.ID) select x);

            return res2;
        }

        public IUserInfo USERINFO_GetUserINFO(string userid)
        {
            var db = new SAFEDB();
            var res = (from x in db.SAFE_HIDDEN_USER
                       where x.NAME == userid
                       select x).First();
            return res;
        }
        public string GetDept()
        {
            try{
                 var db = new SAFEDB();
                 var res = (from x in db.SAFE_ROLEUSERS_T
                            where x.USER_ID == this.USER_ID
                            select x).First().C_KSCODE;
                 return res;
            }
            catch
            {
                return "";
            }
           
        }
        /// <summary>
        /// 用户是否可以审核该线
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>

        public CSException User_VerifyAble_Link(IWORKFLOW_LINK link)
        {
            return new CSException();
        }

        
        public CSException User_VerifyAble_Node(IWORKFLOW_NODE node)
        {
            try
            {



                var cate_cn = EP_TEPEP01.GetDicByCName("节点状态")[node.NODE_CATEGORY];
                if (cate_cn != "开始" && cate_cn != "审核") { throw new Exception("1"); }
                var db = new SAFEDB();
                List<decimal> res1;
                this.Fill_USER_ROLE_LIST();
                res1 = this.USER_ROLE_LIST;
                List<decimal> res2 = (from x in db.VERI_ROLEAUTH_NODE
                                      where x.WORKFLOW_NODE_ID == node.NODE_ID
                                      select x).Select(x => x.ROLE_ID).ToList();
                var intersec = res1.Intersect(res2);
                if (intersec.Count() > 0)
                {
                    return new CSException();
                }
                else
                {
                    return new CSException("该节点不能审核");
                }
            }
            catch
            {
                return new CSException("该节点不能审核");
            }

        }
        public CSException User_VerifyAble_Workflow(AdvWorkFlow advworkflow)
        {
            var db = new SAFEDB();
            List<decimal> res1;
            this.Fill_USER_ROLE_LIST();
            res1 = this.USER_ROLE_LIST;
            List<decimal> res2 = (from x in db.VERI_ROLEAUTH_WORKFLOW
                                  where x.WORKFLOW_ID == advworkflow.WORKFLOW_ID
                                  select x).Select(x => x.ROLE_ID).ToList();
            var intersec = res1.Intersect(res2);
            if (intersec.Count() > 0)
            {
                return new CSException();
            }
            else
            {
                return new CSException("该流程不能审核");
            }
        }

        public List<IWORKFLOW_NODE> GetUser_VerifyAble_Node()
        {
            var db = new SAFEDB();
            this.Fill_USER_ROLE_LIST();
            var k = this.USER_ROLE_LIST;
            var res = (from x in db.VERI_ROLEAUTH_NODE
                       where k.Contains(x.ROLE_ID)
                       select x).Select(x => x.WORKFLOW_NODE_ID);
            var res2 = ((IQueryable<IWORKFLOW_NODE>)(from x in db.VERI_WORKFLOW_NODE
                                                     where res.Contains(x.NODE_ID)
                                                     select x)).ToList();
            return res2;

        }

    }
}