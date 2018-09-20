using LGWBVerifySystem;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AppBox.Model
{
    [Table("SAFE.VERI_WORKFLOW_INSTEP")]
    public class VERI_WORKFLOW_INSTEP : IWORKFLOW_INSTSTEP
    {

        [Key]
        [StringLength(8), Display(Name = "注册id")]
        public string INSTEP_ID { get; set; }

        [StringLength(20), Display(Name = "该记录的流程id")]
        public string WORKFLOW_ID { get; set; }

        /// <summary>
        /// 该记录相关流程的键值对，这个记录的是那个审核表的而不是主表的FLOW_ID，这个值同一个审核是一样的，虽然审核实体可能不同
        /// </summary>
        [StringLength(8), Display(Name = "该记录相关流程的流程值")]
        public string WORKFLOW_EN_FLOW { get; set; }

        /// <summary>
        /// 在多线审核中，每一条并发的线都会生成一条审核记录
        /// </summary>
        [StringLength(8), Display(Name = "这个审核记录的审核线")]
        public string VERIFY_LINK_ID { get; set; }

        /// <summary>
        /// 如果需要生成审核流程图，那么时间将作为遍历线索
        /// </summary>
        [StringLength(14) ,Display(Name = "审核记录的创建时间")]
        public string REC_CREATE_TIME { get; set; }

        [StringLength(64), Display(Name = "该审核记录的执行人")]
        public string INSTEP_USER { get; set; }
        [StringLength(64), Display(Name = "该审核记录留下的审核语句")]
        public string INSTEP_CONCLUSION { get; set; }

        public VERI_WORKFLOW_INSTEP() { }

        /// <summary>
        /// 根据实例和workflow建立一个默认的记录
        /// </summary>
        /// <param name="workflow"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IWORKFLOW_INSTSTEP BuildINSTSTEP(IWORKFLOW workflow, IVerifyEntity entity)
        {
            var newstep = new VERI_WORKFLOW_INSTEP().BuildINSTSTEP(workflow);
            newstep.WORKFLOW_EN_FLOW = entity.FLOW_ID;
            return newstep;
            
        }

        public CSException Static_WORKFLOW_INSTSTEP_InitWorkFlowStep(string conclusion, IWORKFLOW_LINK link, IVerifyEntity entity)
        {
            //link.WORKFLOWLINK_ID
            //entity.FLOW_ID
            
            return new CSException();
        }
        /// <summary>
        /// 仅根据流程建立一个默认记录
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        public IWORKFLOW_INSTSTEP BuildINSTSTEP(IWORKFLOW workflow)
        {
            var newstep = new VERI_WORKFLOW_INSTEP();
            newstep.WORKFLOW_ID = workflow.WORKFLOW_ID;
            newstep.REC_CREATE_TIME = DateTime.Now.ToString("yyyyMMddHHmmss");
            return newstep;
        }
        public IQueryable<VERI_WORKFLOW_INSTEP> GetInstepByWorkflow(IWORKFLOW workflow)
        {
            var db = new SAFEDB();
            var res = (from x in db.VERI_WORKFLOW_INSTEP
                       where x.WORKFLOW_ID == workflow.WORKFLOW_ID
                       select x);
            return res;
        }

    }
}