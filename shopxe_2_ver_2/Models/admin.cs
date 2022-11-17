namespace shopxe_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("admin")]
    public partial class admin
    {
        public int id { get; set; }

        [StringLength(250)]
        public string ten { get; set; }

        [StringLength(250)]
        public string pass { get; set; }
    }
}
