namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.SAFE_MANAGE_T")]
    public partial class SAFE_MANAGE_T
    {
        public decimal ID { get; set; }

        [StringLength(64)]
        public string LEIBIE { get; set; }

        [StringLength(64)]
        public string MANAGE_UNIT { get; set; }

        [StringLength(64)]
        public string MANAGE_NAME { get; set; }

        [StringLength(64)]
        public string EMPLOY_UNIT { get; set; }

        [StringLength(64)]
        public string EU_NAME { get; set; }

        [StringLength(64)]
        public string EMPLOY_DEPARTMENT { get; set; }

        [StringLength(64)]
        public string ED_NAME { get; set; }

        [StringLength(64)]
        public string EMPLOY_GROUP { get; set; }

        [StringLength(64)]
        public string EG_NAME { get; set; }

        [StringLength(64)]
        public string EQUIPMENT { get; set; }

        [StringLength(64)]
        public string FACTORY { get; set; }

        [StringLength(64)]
        public string SIZE { get; set; }

        [StringLength(64)]
        public string PLACE { get; set; }

        public byte? QUANTITY { get; set; }

        public DateTime? EXPIRY_DATE { get; set; }

        [StringLength(64)]
        public string USER_MODE { get; set; }

        [StringLength(64)]
        public string PERIOD { get; set; }

        [StringLength(64)]
        public string SERIAL { get; set; }

        [StringLength(64)]
        public string TEST { get; set; }

        [StringLength(64)]
        public string OUTCOME { get; set; }

        [StringLength(64)]
        public string SET_PEOPLE { get; set; }

        [StringLength(64)]
        public string INSERT_TIME { get; set; }
    }
}
