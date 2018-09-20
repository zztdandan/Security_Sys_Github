using System;
using System.Collections.Generic;
//using RegexAttribute;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Linq;
using AppBox.CommonHelper;
using LGWBVerifySystem;
using AppBox.Model_View;
namespace AppBox.Model
{
    /// <summary>
    /// 危险源管理主表
    /// </summary>
    [Table("SAFE.TH_THAZA01")]
    public class TH_THAZA01 : INotifyPropertyChanged
    {
        #region 属性
        [Key]
        [Display(Name = "危险源数据表序列功能主键")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// 这个值，每条风险数据的历史、现在、审核共享同一个风险主键
        /// </summary>
        [Display(Name = "危险源主键"), Column(TypeName = "NVARCHAR2"), MaxLength(32)]

        public string HAZA_ID { get; set; }
        [Display(Name = "危险源名称"), Column(TypeName = "NVARCHAR2"), MaxLength(50)]
        public string HAZA_NAME { get; set; }

        [Display(Name = "危险源危险区域"), Column(TypeName = "NVARCHAR2"), MaxLength(100)]
        public string HAZA_LOCA { get; set; }

        [NotMapped]
        public string HAZA_LOCA_G
        {
            get
            {
                try
                {
                    var a = TH_HAZALOCA.FindbyID(this.HAZA_LOCA);
                    return  a.C_NAME;
                }
                catch
                {
                    return this.HAZA_LOCA;
                }

            }
        }

        [Display(Name = "危险源录入单位"), Column(TypeName = "NVARCHAR2"), MaxLength(64)]
        // [RegexX("(.)(\\d+)")]
        public string HAZA_DEPT { get; set; }
        [NotMapped]
        public string HAZA_DEPT_G
        {
            get
            {
                try
                {
                    var dept = new ORG_JOBUNITRELATION_V().FindDeptById(this.HAZA_DEPT);
                    var a = dept.C_UNITCODE + "_" + dept.C_UNITNAME;
                    return a;
                }
                catch
                {
                    return this.HAZA_DEPT;
                }


            }
        }

        [Display(Name = "危险源评级"), Column(TypeName = "NVARCHAR2"), MaxLength(10)]
        public string HAZA_LVL { get; set; }
        [NotMapped]
        public string HAZA_LVL_G
        {
            get
            {
                try
                {
                    var hazalvl_dic = EP_TEPEP01.GetDicByCName("危险源等级");
                    var a = hazalvl_dic[this.HAZA_LVL];
                    return a;
                }
                catch (Exception ex)
                {
                    return this.HAZA_LVL;
                }


            }
        }
        [Display(Name = "风险总值"), Column(TypeName = "NUMBER")]
        public decimal? HAZA_D { get; set; }

        [Display(Name = "危险源录入人"), Column(TypeName = "NVARCHAR2"), MaxLength(64)]
        public string REC_CREATOR { get; set; }

        [NotMapped]
        public string REC_CREATOR_G
        {
            get
            {
                try
                {
                    var name = SAFE_HIDDEN_USER.GetUserById(this.REC_CREATOR).CHINESENAME;

                    return name;
                }
                catch (Exception ex)
                {
                    return this.REC_CREATOR;
                }


            }
        }

        [Display(Name = "危险源录入时间"), Column(TypeName = "NVARCHAR2"), MaxLength(14)]
        public string REC_CREATETIME { get; set; }
        [NotMapped]
        public string REC_CREATETIME_G
        {
            get
            {

                var a = DateTime.ParseExact(this.REC_CREATETIME, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm");
                return a;

            }
        }
        /// <summary>
        /// 危险源数据属性，1审批 2 显示 3 历史
        /// </summary>
        [Display(Name = "危险源数据属性"), Column(TypeName = "NVARCHAR2"), MaxLength(8)]
        public string HAZA_CATEGORY { get; set; }
        [NotMapped]
        public string HAZA_CATEGORY_G
        {
            get
            {
                try
                {
                    var hazacate_dic = EP_TEPEP01.GetDicByCName("危险源数据状态");

                    return hazacate_dic[this.HAZA_CATEGORY];
                }
                catch (Exception ex)
                {
                    return "";
                }


            }
        }

        [Display(Name = "危险源包含风险"), Column(TypeName = "NCLOB")]
        public string HAZA_RISK_String { get; set; }
        [NotMapped]
        public List<TH_TRISK01> RISKLIST { get; set; }
        #endregion
        #region 实例初始化

        public TH_THAZA01(string newstring)
        {
            if (newstring == "new")
            {
                var db = new SAFEDB();

                var _haza_id = Guid.NewGuid().ToString("N");
                this.HAZA_ID = _haza_id;
                this.REC_CREATETIME = DateTime.Now.ToString("yyyyMMddHHmmss");
                var re = this.SetStats("审核");

            }
            else if (newstring == "insert")
            {
                var db = new SAFEDB();

                var _haza_id = Guid.NewGuid().ToString("N");
                this.HAZA_ID = _haza_id;
                this.REC_CREATETIME = DateTime.Now.ToString("yyyyMMddHHmmss");
                var re = this.SetStats("正式");

            }
            else
            {
                throw new Exception("不是新建命令");
            }

        }
        public TH_THAZA01(string editstring, string haza_id)
        {
            var new_haza = new TH_THAZA01("new");
            this.REC_CREATETIME = new_haza.REC_CREATETIME;
            this.ID = new_haza.ID;
            this.HAZA_CATEGORY = new_haza.HAZA_CATEGORY;
            this.HAZA_ID = haza_id;


        }
        public TH_THAZA01()
        {
        }

        #endregion
        #region 基于本体的简单查询


        public CSException SetStats(string stats)
        {
            try
            {


                var delstring = EP_TEPEP01.GetDicByCName("危险源数据状态").Where(x => x.Value == stats).FirstOrDefault().Key;
                this.HAZA_CATEGORY = delstring;

                return new CSException();
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }

        }
        public static TH_THAZA01 FindByID(int id_value)
        {
            var db = new SAFEDB();
            var res = (from x in db.TH_THAZA01
                       where x.ID == id_value
                       select x).FirstOrDefault();
            return res;
        }

        public static List<TH_THAZA01> FindListByIDList(List<int> id_value)
        {
            var db = new SAFEDB();
            var res = (from x in db.TH_THAZA01
                       where id_value.Contains(x.ID)
                       select x).ToList();
            return res;
        }

        /// <summary>
        /// 列出同一HAZAID（表示同类）的危险源
        /// </summary>
        /// <param name="haza_id"></param>
        /// <returns></returns>
        public static List<TH_THAZA01> GetListByEntityID(string haza_id)
        {
            var db = new SAFEDB();
            var res = (from x in db.TH_THAZA01
                       where x.HAZA_ID == haza_id
                       select x).ToList();
            return res;
        }
        public static CSException<TH_THAZA01> FindHAZA(string hazaloca, string name)
        {
            try
            {
                var db = new SAFEDB();
                var res = (from x in db.TH_THAZA01
                           where x.HAZA_NAME == name && x.HAZA_LOCA == hazaloca
                           select x).FirstOrDefault();
                if (res.ID == 0 || res.ID == null)
                {
                    return new CSException<TH_THAZA01>(false, new TH_THAZA01());
                }
                return new CSException<TH_THAZA01>(true, res);
            }
            catch (Exception ex)
            {
                return new CSException<TH_THAZA01>(false, ex.Message, new TH_THAZA01());
            }
        }

        #endregion
        #region 与risk的互联
        public CSException Fill_RiskString()
        {
            try
            {
                if (this.RISKLIST.Count == 0)
                {
                    throw new Exception("没有risk可以填充");
                }

                this.HAZA_RISK_String = "";
                foreach (var risk in this.RISKLIST)
                {
                    if (this.HAZA_RISK_String == "")
                    {
                        this.HAZA_RISK_String = risk.RISK_ID;
                    }
                    else
                    {
                        this.HAZA_RISK_String = this.HAZA_RISK_String + "," + risk.RISK_ID;
                    }
                }
                return new CSException();
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }

        }
        public List<TH_TRISK01> GetRiskList()
        {
            if (this.HAZA_RISK_String == "" || this.HAZA_RISK_String == null)
            {
                return new List<TH_TRISK01>();
            }
            var db = new SAFEDB();
            var arr = this.HAZA_RISK_String.Split(',');
            var res = (from x in db.TR_TRISK01
                       where arr.Contains(x.RISK_ID)
                       select x).ToList();
            return res;


        }


        /// <summary>
        /// 外部使用刷新hazalvl的函数
        /// </summary>
        /// <param name="risk_list"></param>
        /// <param name="haza_d"></param>
        /// <param name="hazalvl"></param>
        public static void ReCalcHAZA_LVL(List<TH_TRISK01> risk_list, out decimal haza_d, out string hazalvl)
        {
            var maxLVL = (from x in risk_list
                          orderby x.RISK_LVL descending
                          select x).First().RISK_LVL;

            hazalvl = maxLVL;
            haza_d = risk_list.Sum(x => x.RISK_D);
        }

        /// <summary>
        /// 因为list更新而刷新hazalvl的函数
        /// </summary>
        /// <param name="risk_list"></param>
        public void ReCalcHAZA_LVL(List<TH_TRISK01> risk_list)
        {
            var re0 = this.Fill_RiskString();
            decimal haza_d;
            string hazalvl;
            TH_THAZA01.ReCalcHAZA_LVL(this.RISKLIST, out haza_d, out hazalvl);
            this.HAZA_D = haza_d;
            this.HAZA_LVL = hazalvl;
        }

        /// <summary>
        /// 因为liststr更新而刷新hazalvl的函数
        /// </summary>
        /// <param name="str_risk_list"></param>
        public void ReCalcHAZA_LVL(string str_risk_list)
        {
            this.RISKLIST = this.GetRiskList();
            decimal haza_d;
            string hazalvl;
            TH_THAZA01.ReCalcHAZA_LVL(this.RISKLIST, out haza_d, out hazalvl);
            this.HAZA_D = haza_d;
            this.HAZA_LVL = hazalvl;
        }

        #endregion
        #region 存储入数据库操作
        public static CSException SetStatsAndSave(int ID, string stats)
        {

            try
            {
                var db = new SAFEDB();
                var res = (from x in db.TH_THAZA01
                           where x.ID == ID
                           select x).First();
                var delstring = EP_TEPEP01.GetDicByCName("危险源数据状态").Where(x => x.Value == stats).FirstOrDefault().Key;
                res.HAZA_CATEGORY = delstring;
                db.SaveChanges();
                return new CSException();
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }

        }


        public CSException SaveEdit()
        {
            try
            {
                var db = new SAFEDB();
                var entry = db.Entry(this);
                entry.State = EntityState.Modified;
                db.SaveChanges();
                return new CSException();
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }


        }

        public CSException AddNew()
        {
            try
            {

                var db = new SAFEDB();

                db.Configuration.AutoDetectChangesEnabled = false;

                var k = db.Set<TH_THAZA01>().Add(this);
                db.SaveChanges();

                return new CSException();
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }
        }
        public CSException AddSaveEntitytoDB()
        {
            try
            {
                var db = new SAFEDB();
                try
                {
                    var res = (from x in db.TH_THAZA01
                               where x.ID == this.ID
                               select x).First();
                    res.HAZA_CATEGORY = this.HAZA_CATEGORY;
                    res.HAZA_D = this.HAZA_D;
                    res.HAZA_DEPT = this.HAZA_DEPT;
                    res.HAZA_ID = this.HAZA_ID;
                    res.REC_CREATETIME = this.REC_CREATETIME;
                    res.REC_CREATOR = this.REC_CREATOR;
                    res.HAZA_LOCA = this.HAZA_LOCA;
                    res.HAZA_LVL = this.HAZA_LVL;
                    res.HAZA_NAME = this.HAZA_NAME;
                    res.HAZA_RISK_String = this.HAZA_RISK_String;
                    res.RISKLIST = this.RISKLIST;
                    db.Entry(res).State = EntityState.Modified;
                    db.SaveChanges();
                    return new CSException();
                }
                catch
                {
                    this.ID = 10000;
                    db.TH_THAZA01.Add(this);
                    db.SaveChanges();
                    return new CSException();
                }

            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }

        }
        #endregion
        #region HAZA01业务操作
        /// <summary>
        /// 获得这个haza01id组下的正式成员（注意，每个haza01组仅有一个正式成员，可以没有
        /// </summary>
        /// <returns></returns>
        public TH_THAZA01 GetOfficalHAZA01InThisHAZAID()
        {
            var db = new SAFEDB();
            var res = (from x in db.TH_THAZA01
                       where x.HAZA_ID == this.HAZA_ID && x.HAZA_CATEGORY == "01"
                       select x).First();
            return res;
        }
        /// <summary>
        /// 获得该hazaid名下唯一一个审核节点，注意，每个haza01id有且仅有一个审核节点
        /// </summary>
        /// <returns></returns>
        public TH_THAZA01 GetVeriHAZA01InThisHAZAID()
        {
            var db = new SAFEDB();
            var res = (from x in db.TH_THAZA01
                       where x.HAZA_ID == this.HAZA_ID && x.HAZA_CATEGORY == "03"
                       select x).First();
            return res;
        }
        /// <summary>
        /// 获得最近的一项
        /// </summary>
        /// <returns></returns>
        public TH_THAZA01 GetLatestHAZA01InThisHAZAID()
        {
            var db = new SAFEDB();
            var res = (from x in db.TH_THAZA01
                       where x.HAZA_ID == this.HAZA_ID
                       orderby x.REC_CREATETIME
                       select x).Last();
            return res;
        }


        /// <summary>
        /// 根据现在该工作的状态进行该树的维护
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public string CheckNode(IWORKFLOW_NODE node)
        {
            var vr_cate_dic = EP_TEPEP01.GetDicByCName("节点状态");
            var vr_cate_cdic = EP_TEPEP01.GetCDicByCName("节点状态");
            var this_cate_cdic = EP_TEPEP01.GetCDicByCName("危险源数据状态");

            if (node.NODE_CATEGORY == vr_cate_cdic["否决"])
            {
                this.HAZA_CATEGORY = this_cate_cdic["删除"];
                this.SaveEdit();
            }
            else if (node.NODE_CATEGORY == vr_cate_cdic["结束"])
            {
                try
                {
                    var oldhaza = this.GetOfficalHAZA01InThisHAZAID();

                    oldhaza.HAZA_CATEGORY = this_cate_cdic["历史"];
                    var re1 = oldhaza.SaveEdit();
                }
                catch { }

                this.HAZA_CATEGORY = this_cate_cdic["正式"];
                this.SaveEdit();
            }
            else if (node.NODE_CATEGORY == vr_cate_cdic["开始"])//当一个节点审核开始，该项目中的其他审核节点进入删除状态，同一时间只存在一个审核节点
            {
                try
                {
                    var otherveriHaza = this.GetVeriHAZA01InThisHAZAID();
                    otherveriHaza.HAZA_CATEGORY = this_cate_cdic["历史"];
                    var re1 = otherveriHaza.SaveEdit();
                }
                catch { }
                
               
            }
            return this.HAZA_CATEGORY;

        }
        #endregion
        #region 导入
        /// <summary>
        /// haza01的文件导入函数，从npoi的sheet转化成list
        /// </summary>
        /// <param name="HSSFSheet"></param>
        /// <returns></returns>
        public static CSException<List<TH_THAZA01>> BuildListByNPOISheet(NPOI.HSSF.UserModel.HSSFSheet HSSFSheet, string userid)
        {
            try
            {
                var risk_status_Dic = EP_TEPEP01.GetDicByCName("风险状态");

                var rowcount = HSSFSheet.LastRowNum;//有一行是标题，但是还是+1，因为从0开始算。如果没有标题还是+1，因为这个不是统计总行，而是行数的最后一行的代码
                var hazaList = new List<TH_THAZA01>();
                for (var i = 1; i < rowcount + 1; i++)
                {

                    try
                    {

                        string force_haza_lvl;
                        var row = HSSFSheet.GetRow(i);
                        if (row.Cells.Count() < 9)
                        {
                            break;
                        }
                        //读取sheet对应行所有数据
                        //一边读数据一边新建risk
                        var newrisk = new TH_TRISK01("insert");
                        var haza_loca_deptCode = row.Cells[0].ToString().Trim();
                        if (haza_loca_deptCode == "END")
                        {
                            //根据要求，加了这个标记的行作为结束行
                            break;
                        }
                        var haza_loca_name = "";
                        var haza_name = "";
                        var risk_status_Cname = "";
                        try
                        {
                            newrisk.RISK_DEPT = haza_loca_deptCode;
                            haza_loca_name = row.Cells[1].ToString().Trim();
                            haza_name = row.Cells[2].ToString().Trim();
                            risk_status_Cname = row.Cells[3].ToString();
                            newrisk.RISK_STATUS = risk_status_Dic.Where(x => x.Value == risk_status_Cname).First().Key;
                            newrisk.RISK_DECONTENT = row.Cells[4].ToString().Trim();
                            newrisk.RISK_MOD = row.Cells[5].ToString().Trim();
                            newrisk.RISK_L = decimal.Parse(row.Cells[6].ToString().Trim());
                            newrisk.RISK_E = decimal.Parse(row.Cells[7].ToString().Trim());
                            newrisk.RISK_C = decimal.Parse(row.Cells[8].ToString().Trim());
                            newrisk.CalcLVL();
                            newrisk.RISK_SOL = row.Cells[9].ToString().Trim().Replace("、", "");
                            if (row.PhysicalNumberOfCells > 10)
                            {
                                force_haza_lvl = row.Cells[10].ToString().Trim();
                            }
                            else
                            {
                                force_haza_lvl = "";
                            }
                        }
                        catch
                        {
                            throw new Exception("数据中有空白行，不符合规范");
                        }

                        //看危险源区域是否已经录入
                        var locare = TH_HAZALOCA.FindLoca(haza_loca_deptCode, haza_loca_name);
                        if (!locare.Flag)
                        {
                            throw new Exception("没有找到危险源区域");
                        }
                        //危险源区域获得
                        var hazaloca = locare.Entity;

                        var re_inList = TH_THAZA01.FindInList(hazaloca, haza_name, hazaList);
                        var re_inDB = TH_THAZA01.FindInDB(hazaloca, haza_name);


                        if (re_inDB.Flag && re_inList.Flag)//在数据库和表中同时找到两项，则优先加入临时程序表中
                        {
                            var hazard = hazaList[(int)re_inList.StatusNum];
                            //直接添加一个风险进入

                            hazard.RISKLIST.Add(newrisk);
                            hazard.ReCalcHAZA_LVL(hazard.RISKLIST);
                            if (force_haza_lvl != "")
                            {
                                var lvldic = EP_TEPEP01.GetDicByCName("危险源等级");
                                hazard.HAZA_LVL = lvldic.Where(x => x.Value == force_haza_lvl).First().Key;
                            }
                        }
                        else if (re_inDB.Flag && !re_inList.Flag)//在数据库中存在
                        {

                            re_inDB.Entity.ReCalcHAZA_LVL(re_inDB.Entity.HAZA_RISK_String);
                            re_inDB.Entity.RISKLIST.Add(newrisk);
                            re_inDB.Entity.ReCalcHAZA_LVL(re_inDB.Entity.RISKLIST);
                            if (force_haza_lvl != "")
                            {
                                var lvldic = EP_TEPEP01.GetDicByCName("危险源等级");
                                re_inDB.Entity.HAZA_LVL = lvldic.Where(x => x.Value == force_haza_lvl).First().Key;
                            }
                            hazaList.Add(re_inDB.Entity);

                        }
                        else if (!re_inDB.Flag && re_inList.Flag)//在列表中
                        {
                            var hazard = hazaList[(int)re_inList.StatusNum];
                            //直接添加一个风险进入
                            hazard.RISKLIST.Add(newrisk);
                            hazard.ReCalcHAZA_LVL(hazard.RISKLIST);
                            if (force_haza_lvl != "")
                            {
                                var lvldic = EP_TEPEP01.GetDicByCName("危险源等级");
                                hazard.HAZA_LVL = lvldic.Where(x => x.Value == force_haza_lvl).First().Key;
                            }
                        }
                        else if (!re_inDB.Flag && !re_inList.Flag)//该危险源在已有资源中不存在，是个完全新危险源
                        {
                            //新建危险源
                            var newhaza = new TH_THAZA01("insert");
                            newhaza.HAZA_LOCA = hazaloca.ID;
                            newhaza.REC_CREATOR = userid;
                            newhaza.HAZA_DEPT = haza_loca_deptCode;
                            newhaza.HAZA_NAME = haza_name;
                            newhaza.RISKLIST = new List<TH_TRISK01>();
                            //马上添加一个新的风险
                            newhaza.RISKLIST.Add(newrisk);
                            newhaza.ReCalcHAZA_LVL(newhaza.RISKLIST);
                            if (force_haza_lvl != null && force_haza_lvl != "")
                            {
                                try
                                {
                                    var lvldic = EP_TEPEP01.GetDicByCName("危险源等级");
                                    newhaza.HAZA_LVL = lvldic.Where(x => x.Value == force_haza_lvl).First().Key;
                                }
                                catch
                                {
                                    throw new Exception("强制危险源等级错误");
                                }

                            }
                            //新危险源添加入List
                            hazaList.Add(newhaza);
                        }


                    }
                    catch (Exception ex)
                    {
                        var cell = HSSFSheet.GetRow(i).Cells.Select(x => { return x.ToString(); });
                        var jsoncell = JsonHelper.SerializeObject(cell);
                        var errmsg = String.Format("至第{0}行录入成功,第{1}行录入失败 原因：{2}，\n错误行信息:{3}", i, i + 1, ex.Message, jsoncell);
                        return new CSException<List<TH_THAZA01>>(false, errmsg, hazaList);
                    }
                }
                //返回加完的hazalist
                return new CSException<List<TH_THAZA01>>(true, hazaList);
            }

            catch (Exception ex)
            {
                return new CSException<List<TH_THAZA01>>(false, ex.Message, new List<TH_THAZA01>());
            }
        }
        #endregion
        #region hazaloca相关操作
        /// <summary>
        /// 查找是否有同类
        /// </summary>
        /// <param name="loca"></param>
        /// <param name="name"></param>
        /// <param name="haza01"></param>
        /// <returns></returns>
        public static CSException<TH_THAZA01> FindInList(TH_HAZALOCA loca, string name, List<TH_THAZA01> haza01)
        {
            try
            {
                int find_Index = haza01.FindIndex(x => x.HAZA_NAME == name && x.HAZA_LOCA == loca.ID);
                if (find_Index >= 0)
                {
                    return new CSException<TH_THAZA01>(true, find_Index, haza01[find_Index]);
                }
                else
                {
                    return new CSException<TH_THAZA01>(false, new TH_THAZA01());
                }
            }
            catch (Exception ex)
            {
                return new CSException<TH_THAZA01>(ex.Message, new TH_THAZA01());
            }
        }
        public static CSException<TH_THAZA01> FindInDB(TH_HAZALOCA loca, string name)
        {
            try
            {
                var db = new SAFEDB();
                var res = (from x in db.TH_THAZA01
                           where x.HAZA_NAME == name && x.HAZA_LOCA == loca.ID
                           select x).FirstOrDefault();
                var ind = (int)res.ID;
                if (ind > 0)
                {
                    return new CSException<TH_THAZA01>(true, ind, res);
                }
                else
                {
                    return new CSException<TH_THAZA01>(false, new TH_THAZA01());
                }
            }
            catch (Exception ex)
            {
                return new CSException<TH_THAZA01>(ex.Message, new TH_THAZA01());
            }
        }
        #endregion





        public event PropertyChangedEventHandler PropertyChanged;
    }
}