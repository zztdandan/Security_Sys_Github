using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGWBVerifySystem
{
    public interface IVerifyEntity
    {
        /// <summary>
        /// 该实体的实际状态
        /// </summary>
        string STATS { get; set; }
        /// <summary>
        /// 该实体的唯一标识码
        /// </summary>
        string REC_ID { get; set; }
        /// <summary>
        /// 该实体的审核进度，该进度以WORKFLOW_NODE中该实体所处节点的ID表示
        /// </summary>
        string AUDITSTEP_ID { get; set; }


        /// <summary>
        /// 该审核实体的pk集合，由于某些情况下不一定是rec或flow作为key的
        /// </summary>
       string[] KeyCollection { get; set; }

        CSException EntityVeri_Precondition_Comfirmed(IAdvanceUserInfo userinfo);

        /// <summary>
        /// 流程唯一标识ID，一个流程会创造多个REC_ID，但是流程标识ID只有一个
        /// </summary>
        string FLOW_ID { get; set; }
        //string LAST_ORDER { get; set; }

        AdvWorkFlow AdvWork { get; set; }
        /// <summary>
        /// 该实体的数据更新后，将结果更新到数据库
        /// </summary>
        /// <returns></returns>
        CSException UpdateDB(AdvWorkFlow AdvWork);
        /// <summary>
        /// 删除这条数据
        /// </summary>
        /// <param name="AdvWork"></param>
        /// <returns></returns>
        CSException DelDB(AdvWorkFlow AdvWork);

        List<IVerifyEntity> GetListBythisFlowid();
        
        IVerifyEntity CreateNewVerifyEntity(IWORKFLOW_NODE endnode);
        /// <summary>
        /// 将此条数据添加到表格
        /// </summary>
        /// <param name="AdvWork"></param>
        /// <returns></returns>
        CSException AddDB(AdvWorkFlow AdvWork);

    IVerifyEntity StaticGetEntityByid(string id);
        /// <summary>
        /// 获得描述该实体的工作流
        /// </summary>
        /// <returns></returns>
   AdvWorkFlow GetAdvWorkFlow();
     IWORKFLOW_NODE GetCurrentNode();

     CSException AlterStats(string stats, string audistep,string conclusion);
    }
}
