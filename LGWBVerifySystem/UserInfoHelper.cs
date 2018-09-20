using System.Linq;



namespace LGWBVerifySystem
{
  
    public interface IAdvanceUserInfo : IUserInfo
    {



        /// <summary>
        /// 根据用户id获得用户组信息(可能有多个用户组)
        /// </summary>
        /// <param name="userid">用户Id</param>
        /// <returns></returns>
        IQueryable<IUserRole> ROLEGROUP_GetRoleListForUser();


        IUserInfo USERINFO_GetUserINFO(string userid);

        /// <summary>
        /// 用户是否有审核该流程的权限
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        CSException User_VerifyAble_Workflow(AdvWorkFlow advworkflow);

        CSException User_VerifyAble_Node(IWORKFLOW_NODE node);
        CSException User_VerifyAble_Link(IWORKFLOW_LINK link);
        
    }

    /// <summary>
    /// 记录用户信息类
    /// </summary>
    public interface IUserInfo
    {
       string USER_ID { get; }
      string USER_NAME { get; }
     IAdvanceUserInfo AdvanceUserInfo();
        
        
    }
    public interface IUserRole
    {
        string ROLE_ID { get;}
        string ROLE_NAME { get; }
    }
}