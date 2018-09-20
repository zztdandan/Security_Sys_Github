namespace AppBox.Model
{
    using AppBox.Verify;
    using LGWBVerifySystem;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("SAFE.SAFE_HIDDEN_USER")]
    public partial class SAFE_HIDDEN_USER:IUserInfo
    {
        public decimal ID { get; set; }

        [StringLength(64)]
        public string NAME { get; set; }

        [StringLength(64)]
        public string CHINESENAME { get; set; }

        [StringLength(2)]
        public string ENABLED { get; set; }

        [StringLength(64)]
        public string PASSWORD { get; set; }

        [StringLength(64)]
        public string OFFICEPHONE { get; set; }

        [StringLength(64)]
        public string HOMEPHONE { get; set; }

        [StringLength(64)]
        public string TELPHONE { get; set; }

        [StringLength(500)]
        public string REMARK { get; set; }

        [StringLength(10)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }

        [StringLength(2)]
        public string ROLE_IDENTITY { get; set; }

        public decimal? SAFE_ROLE { get; set; }
        public static SAFE_HIDDEN_USER GetUserById(string id){
            var db = new SAFEDB();
            var res = (from x in db.SAFE_HIDDEN_USER
                       where x.NAME == id
                       select x).First();
            return res;
        }

        public IAdvanceUserInfo AdvanceUserInfo()
        {
            var a = new AdvUserInfo(this);
            return a;
        }

        public string USER_ID
        {
            get { return this.NAME; }
        }

        public string USER_NAME
        {
            get { return this.CHINESENAME; }
        }
    }
}
