namespace shopxe_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        public int id { get; set; }

        [StringLength(250)]
        public string ten { get; set; }

        [StringLength(250)]
        public string email { get; set; }

        public int? sodt { get; set; }
    }
}
