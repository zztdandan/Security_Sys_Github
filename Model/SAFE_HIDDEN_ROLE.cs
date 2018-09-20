namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using LGWBVerifySystem;

    [Table("SAFE.SAFE_HIDDEN_ROLE")]
    public partial class SAFE_HIDDEN_ROLE:IUserRole
    {
        public decimal ID { get; set; }

        [StringLength(64)]
        public string ROLE_LEV { get; set; }

        [StringLength(64)]
        public string ROLE_NAME { get; set; }

        [StringLength(1000)]
        public string BZ { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        public DateTime? INSERT_TIME { get; set; }

        public decimal? ORD { get; set; }

        public string ROLE_ID
        {
            get { return this.ID.ToString(); }
        }
    }
}
