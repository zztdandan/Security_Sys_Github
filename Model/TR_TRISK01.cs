using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using LGWBVerifySystem;

namespace AppBox.Model
{
    /// <summary>
    /// 风险数据主表
    /// </summary>
    [Table("SAFE.TH_TRISK01")]
    public class TH_TRISK01
    {
        #region 属性

        [Key]
        [Required]
        /// <summary>
        /// 这个主键每条风险数据的历史、现在、审核共享同一个风险主键
        /// </summary>
        [Display(Name = "风险主键"), Column(TypeName = "NVARCHAR2"), MaxLength(32)]
        public string RISK_ID { get; set; }
        [Display(Name = "风险录入时间"), Column(TypeName = "NVARCHAR2"), MaxLength(14)]
        public string REC_CREATE_TIME { get; set; }

        [Display(Name = "风险录入人"), Column(TypeName = "NVARCHAR2"), MaxLength(14)]
        public string REC_CREATOR { get; set; }

        /// <summary>
        /// 绑定类，目前HAZA表示危险源，WORK表示作业
        /// </summary>
        [Display(Name = "风险绑定类"), Column(TypeName = "NVARCHAR2"), MaxLength(100)]
        public string RISK_BINDTYPE { get; set; }
        [Display(Name = "风险单位"), Column(TypeName = "NVARCHAR2"), MaxLength(100)]
        public string RISK_DEPT { get; set; }
        [Display(Name = "风险状态"), Column(TypeName = "NVARCHAR2"), MaxLength(100)]
        public string RISK_STATUS { get; set; }

        [NotMapped]
        public string RISK_STATUS_G { get {

                var db = new SAFEDB();
                var dic = EP_TEPEP01.GetDicByCName("风险状态");
                return dic[this.RISK_STATUS];
            } }


        [Display(Name = "风险评级"), Column(TypeName = "NVARCHAR2"), MaxLength(10)]
        public string RISK_LVL { get; set; }

        [Display(Name = "风险评级L值")]
        public decimal RISK_L { get; set; }
        [Display(Name = "风险评级E值")]
        public decimal RISK_E { get; set; }
        [Display(Name = "风险评级C值")]
        public decimal RISK_C { get; set; }
        [Display(Name = "风险评级D值")]
        public decimal RISK_D { get; set; }


        [Display(Name = "事故模式"), Column(TypeName = "NVARCHAR2"), MaxLength(100)]
        public string RISK_MOD { get; set; }

        [Display(Name = "风险处理措施"), Column(TypeName = "NVARCHAR2"), MaxLength(100)]
        public string RISK_SOL { get; set; }
        /// <summary>
        /// 风险数据特征码，如果绑定危险源，则为危险源数据表序列主键(因为历史和现实的可能不同，要分别绑定)，绑定风险作业则为风险作业主键
        /// </summary>
        [Display(Name = "风险数据特征码"), Column(TypeName = "NVARCHAR2"), MaxLength(100)]
        public string FEATURE_CODE { get; set; }
        [Display(Name = "风险详情/描述"), Column(TypeName = "NVARCHAR2"), MaxLength(500)]
        public string RISK_DECONTENT { get; set; }

        #endregion
        #region 数据库相关
        public static TH_TRISK01 FindByID(string id)
        {
            var db = new SAFEDB();
            var res = (from x in db.TR_TRISK01
                       where x.RISK_ID == id
                       select x).First();
            return res;
        }
        public static List<TH_TRISK01> FindListByIDList(List<string> idlist)
        {
            var db = new SAFEDB();
            var res = (from x in db.TR_TRISK01
                       where idlist.Contains(x.RISK_ID)
                       select x).ToList();
            return res;
        }
        public CSException AddtoDB()
        {
            try
            {
                if (this.RISK_ID == null || this.RISK_ID == "")
                {
                    this.RISK_ID = Guid.NewGuid().ToString("N").Substring(0, 8);
                }

                var db = new SAFEDB();
                db.Configuration.AutoDetectChangesEnabled = false;

                db.Set<TH_TRISK01>().Add(this);
                db.SaveChanges();
                db.Dispose();
                return new CSException();
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }

        }
        #endregion
        #region 计算D、LVL
        public void CalcLVL()
        {
            try
            {
                decimal this_d;
                string this_lvl;
                CalcLVL(this.RISK_L, this.RISK_E, this.RISK_C, out this_d, out this_lvl);
                this.RISK_D = this_d;
                this.RISK_LVL = this_lvl;
                return;
            }
            catch (Exception ex)
            {
                return;
            }
            
        }


        public static void CalcLVL(decimal L, decimal E, decimal C, out decimal D, out string lvl)
        {
            var int_D = L * E * C;
            var valueList = EP_TEPEP01.GetListByCName("危险分数分级表");
            foreach (var rank in valueList)
            {
                var Minval = int.Parse(rank.CODE_DESC_1);
                var Maxval = int.Parse(rank.CODE_DESC_2);
                if (int_D >= Minval && int_D <= Maxval)
                {
                    D = int_D;
                    lvl = rank.CODE;
                    return;
                }
            }
            D = 0;
            lvl = "1D";
        }
        #endregion
        private SAFEDB AddToContext(SAFEDB context,
    TH_TRISK01 entity, int count, int commitCount, bool recreateContext)
        {
            context.Set<TH_TRISK01>().Add(entity);

            if (count % commitCount == 0)
            {
                context.SaveChanges();
                if (recreateContext)
                {
                    context.Dispose();
                    context = new SAFEDB();
                    context.Configuration.AutoDetectChangesEnabled = false;
                }
            }

            return context;
        }
        public TH_TRISK01(string newtype)
        {
            this.RISK_ID = Guid.NewGuid().ToString("N").Substring(0, 8);
            this.REC_CREATE_TIME = DateTime.Now.ToString("yyyyMMddHHmmss");

        }

        public TH_TRISK01()
        {

        }
        public CSException SaveRISKChange()
        {
            var db = new SAFEDB();
            var entry=db.Entry(this);
            entry.State = EntityState.Modified;
           var effect = db.SaveChanges();
            return new CSException();
        }

        public CSException CheckAndSaveRiskinDB(){
            try
            {
                var db = new SAFEDB();
                try
                {
                    var res = (from x in db.TR_TRISK01
                               where x.RISK_ID == this.RISK_ID
                               select x).First();
                  
                }
                catch
                {
                    db.TR_TRISK01.Add(this);
                    db.SaveChanges();
                }
               
                return new CSException();
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }
           
        }
    }
}