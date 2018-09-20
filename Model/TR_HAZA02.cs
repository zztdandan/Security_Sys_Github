using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web;
using LGWBVerifySystem;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBox.Model
{
    /// <summary>
    /// 危险源管理历史表
    /// </summary>
    [Table("SAFE.TR_THAZA02")]
    public class TR_THAZA02 : IVerifyEntity
    {
        [Key]
        [Required]
        [Display(Name = "危险源数据审核主键"), Column(TypeName = "NVARCHAR2"), MaxLength(8)]
        public string REC_ID { get; set; }

        /// <summary>
        /// 这个主键每条风险数据的历史、现在、审核共享同一个风险主键
        /// </summary>
        [Display(Name = "对应危险源主表主键")]
        public int THAZA01 { get; set; }
        [Display(Name = "该实体的实际状态"), Column(TypeName = "NVARCHAR2"), MaxLength(50)]
        public string STATS { get; set; }

        [Display(Name = "该实体的审核进度"), Column(TypeName = "NVARCHAR2"), MaxLength(50)]
        public string AUDITSTEP_ID { get; set; }

        [Display(Name = "流程唯一标识ID"), Column(TypeName = "NVARCHAR2"), MaxLength(8)]
        public string FLOW_ID { get; set; }
        //[Display(Name = "上一节点"), Column(TypeName = "NVARCHAR2"), MaxLength(100)]
        //public string LAST_ORDER { get; set; }

        /// <summary>
        /// 该实体对应的workflow值
        /// </summary>
        [NotMapped]
        public AdvWorkFlow AdvWork { get; set; }
        /// <summary>
        /// 该审核实体的pk集合，由于某些情况下不一定是rec或flow作为key的
        /// </summary>
        public Dictionary<string, string> KeyCollection { get; set; }
        public CSException EntityVeri_Precondition_Comfirmed(IAdvanceUserInfo userinfo)
        {
            return new CSException();
        }

        /// <summary>
        /// 该实体的数据更新后，将结果更新到数据库
        /// </summary>
        /// <returns></returns>
        public CSException UpdateDB(AdvWorkFlow AdvWork)
        {
            return new CSException();
        }
        /// <summary>
        /// 删除这条数据
        /// </summary>
        /// <param name="AdvWork"></param>
        /// <returns></returns>
        public CSException DelDB(AdvWorkFlow AdvWork)
        {
            return new CSException();
        }

        public List<IVerifyEntity> GetListBythisFlowid()
        {
            return new List<IVerifyEntity>();
        }

        public IVerifyEntity CreateNewVerifyEntity(IWORKFLOW_NODE endnode)
        {
            return this;
        }
        /// <summary>
        /// 将此条数据添加到表格
        /// </summary>
        /// <param name="AdvWork"></param>
        /// <returns></returns>
        public CSException AddDB(AdvWorkFlow AdvWork)
        {
            return new CSException();
        }
    }
}