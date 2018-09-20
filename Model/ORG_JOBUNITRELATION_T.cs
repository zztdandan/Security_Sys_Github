namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("SAFE.ORG_JOBUNITRELATION_T")]
    public partial class ORG_JOBUNITRELATION_T
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long C_JOBID { get; set; }

        [StringLength(1024)]
        public string C_JOBCODE { get; set; }

        [StringLength(1024)]
        public string C_JOBNAME { get; set; }

        [StringLength(64)]
        public string C_JOBLEVEL { get; set; }

        [StringLength(1024)]
        public string C_LEVELNAME { get; set; }

        public long? C_ROOTID { get; set; }

        [StringLength(1024)]
        public string C_ROOTCODE { get; set; }

        [StringLength(1024)]
        public string C_ROOTNAME { get; set; }

        public long? C_CORPID { get; set; }

        [StringLength(1024)]
        public string C_CORPCODE { get; set; }

        [StringLength(1024)]
        public string C_CORPNAME { get; set; }

        public long? C_CORPSUBID { get; set; }

        [StringLength(1024)]
        public string C_CORPSUBCODE { get; set; }

        [StringLength(1024)]
        public string C_CORPSUBNAME { get; set; }

        public long? C_SECID { get; set; }

        [StringLength(1024)]
        public string C_SECCODE { get; set; }

        [StringLength(1024)]
        public string C_SECNAME { get; set; }

        public long? C_KSID { get; set; }

        [StringLength(1024)]
        public string C_KSCODE { get; set; }

        [StringLength(1024)]
        public string C_KSNAME { get; set; }

        public long? C_UNITID { get; set; }

        [StringLength(1024)]
        public string C_UNITCODE { get; set; }

        [StringLength(1024)]
        public string C_UNITNAME { get; set; }

        [StringLength(4000)]
        public string C_UNITFULLNAME { get; set; }


        /// <summary>
        /// ”√code’“≤ø√≈
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static ORG_JOBUNITRELATION_T FindDeptByCode(string code){

            try
            {
                var db = new SAFEDB();
                var res = (from x in db.ORG_JOBUNITRELATION_T
                           where x.C_UNITCODE == code||x.C_KSCODE==code||x.C_CORPCODE==code||x.C_SECCODE==code
                           select x
                           ).OrderBy(x=>x.C_UNITCODE).First();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         
        }

        
    }
}
