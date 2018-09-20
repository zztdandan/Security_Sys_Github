namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web.UI.WebControls;
    using AppBox.Model_View;
    using LGWBVerifySystem;
    using NPOI.HSSF.UserModel;
    [Table("SAFE.TH_HAZALOCA")]
    public class TH_HAZALOCA
    {
        [StringLength(100)]
        public string ID { get; set; }

        [StringLength(50)]
        public string DEPT { get; set; }
        [NotMapped]
        public string DEPT_C
        {
            get
            {
                try
                {
                    var dept = new ORG_JOBUNITRELATION_V().FindDeptById(this.DEPT);
                    return dept.C_UNITNAME;
                }
                catch
                {
                    return this.DEPT;
                }

            }
        }

        [StringLength(50)]
        public string C_NAME { get; set; }


        [StringLength(10)]
        public string STATS { get; set; }
        /// <summary>
        /// 地址的属性为HAZA还是RISK，待定字段
        /// </summary>
        [StringLength(50)]
        public string LOCA_TYPE { get; set; }

        public TH_HAZALOCA(string Name, string Dept)
        {

            var newguid = Guid.NewGuid().ToString("N").Substring(0, 8);

            this.ID = Dept + "_" + newguid;
            this.C_NAME = Name;
            this.DEPT = Dept;
            this.SetStats("正式");
        }

        public static CSException<List<TH_HAZALOCA>> BuildListByNPOISheet(NPOI.HSSF.UserModel.HSSFSheet HSSFSheet)
        {
            try
            {
                var db = new SAFEDB();

                var rowcount = HSSFSheet.LastRowNum + 1;
                var hazaList = new List<TH_HAZALOCA>();
                for (var i = 0; i < rowcount; i++)
                {
                    var row = HSSFSheet.GetRow(i);
                    var deptCode = row.Cells[0].StringCellValue;
                    var locaName = row.Cells[1].StringCellValue;
                    var newLoca = new TH_HAZALOCA(locaName, deptCode);
                    var allowed = newLoca.IsAllowed();
                    if (!allowed.Flag)
                    {
                        db.TH_HAZALOCA.Add(newLoca);
                        db.SaveChanges();
                    }
                    else
                    {


                        throw new Exception(allowed.Msg);
                    }


                }
                return new CSException<List<TH_HAZALOCA>>(true, rowcount.ToString(), hazaList);
            }

            catch (Exception ex)
            {
                return new CSException<List<TH_HAZALOCA>>(ex.Message, new List<TH_HAZALOCA>());
            }
        }

        public static CSException AddRangetoDB(List<TH_HAZALOCA> list)
        {
            try
            {
                var db = new SAFEDB();
                db.TH_HAZALOCA.AddRange(list);
                db.SaveChanges();
                return new CSException();
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }




        }

        public TH_HAZALOCA()
        {

        }
        public CSException AddtoDB()
        {
            try
            {
                var db = new SAFEDB();
                db.TH_HAZALOCA.Add(this);
                db.SaveChanges();
                return new CSException();
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }
        }


        /// <summary>
        /// 通过id寻找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static TH_HAZALOCA FindbyID(string id)
        {

            var db = new SAFEDB();
            var res = (from x in db.TH_HAZALOCA
                       where x.ID == id
                       select x).FirstOrDefault();
            return res;


        }

        /// <summary>
        /// 查询数据库中是否存在相同描述的地址,true 有，false 没有
        /// </summary>
        /// <returns></returns>
        public CSException IsAllowed()
        {
            try
            {
                var db = new SAFEDB();
                var res = (from x in db.TH_HAZALOCA
                           where x.DEPT == this.DEPT && x.C_NAME == this.C_NAME && x.STATS != "04"
                           select x).ToList();
                if (res.Count() == 0)
                {
                    try
                    {
                        var res1 = new ORG_JOBUNITRELATION_V().FindDeptById(this.DEPT);
                        return new CSException(false);
                    }
                    catch
                    {
                        return new CSException(true, "数据库中没有这个单位代号：" + this.DEPT);
                    }

                }
                else
                {
                    var msgstr = string.Format("{0}、{1}的区域已经存在于数据库中", this.DEPT, this.C_NAME.ToString());
                    return new CSException(true, msgstr);
                }
            }
            catch (Exception ex)
            {
                return new CSException(true, ex.Message);
            }
        }

        [NotMapped]
        public string C_STATS
        {
            get
            {

                var delstring = EP_TEPEP01.GetDicByCName("危险源数据状态")[this.STATS];
                return delstring;
            }
        }

        /// <summary>
        /// 修改该实体的状态
        /// </summary>
        /// <param name="stats"></param>
        /// <returns></returns>
        public CSException SetStats(string stats)
        {
            try
            {

                var delstring = EP_TEPEP01.GetDicByCName("危险源数据状态").Where(x => x.Value == stats).FirstOrDefault().Key;
                this.STATS = delstring;

                return new CSException();
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }

        }

        /// <summary>
        /// 修改该实体的状态并保存
        /// </summary>
        /// <param name="stats"></param>
        /// <returns></returns>
        public CSException SetStatsAndSave(string stats)
        {
            try
            {

                var delstring = EP_TEPEP01.GetDicByCName("危险源数据状态").Where(x => x.Value == stats).FirstOrDefault().Key;
                this.STATS = delstring;
                var db = new SAFEDB();
                var res = (from x in db.TH_HAZALOCA
                           where x.ID == this.ID
                           select x).FirstOrDefault();
                res.STATS = this.STATS;
                db.SaveChanges();
                return new CSException();
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }

        }

        public static CSException<TH_HAZALOCA> FindLoca(string dept, string name)
        {
            try
            {
                var db = new SAFEDB();
                var res = (from x in db.TH_HAZALOCA
                           where x.C_NAME == name && x.DEPT == dept
                           select x).FirstOrDefault();
                if (res.ID == "" || res.ID == null)
                {
                    return new CSException<TH_HAZALOCA>(false, new TH_HAZALOCA());
                }
                return new CSException<TH_HAZALOCA>(true, res);
            }
            catch (Exception ex)
            {
                return new CSException<TH_HAZALOCA>(false, new TH_HAZALOCA());
            }
        }

        public CSException ThisEntitySaveChanges()
        {
            try
            {
                var db = new SAFEDB();
                var res = (from x in db.TH_HAZALOCA
                           where x.ID == this.ID
                           select x).FirstOrDefault();
                res = this;
                db.SaveChanges();

                return new CSException();
            }
            catch (Exception ex)
            {
                return new CSException(ex.Message);
            }

        }
    }
}
