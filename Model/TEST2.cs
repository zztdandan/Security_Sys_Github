namespace AppBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAFE.TEST2")]
    public partial class TEST2
    {
        [Key]
        [StringLength(64)]
        public string CODE { get; set; }
    }
}
