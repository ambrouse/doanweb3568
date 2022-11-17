namespace shopxe_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitietdonhang")]
    public partial class chitietdonhang
    {
        public int id { get; set; }

        public int? idsanpham { get; set; }

        public int? iddonhang { get; set; }

        [StringLength(250)]
        public string ten { get; set; }

        [Column(TypeName = "money")]
        public decimal? dongia { get; set; }

        public int? soluong { get; set; }

        public virtual sanpham sanpham { get; set; }
    }
}
