namespace shopxe_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sanpham")]
    public partial class sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sanpham()
        {
            chitietdonhangs = new HashSet<chitietdonhang>();
        }

        public int id { get; set; }

        [StringLength(250)]
        public string ten { get; set; }

        [Column(TypeName = "money")]
        public decimal? gia { get; set; }

        public int? loai { get; set; }

        public int? hang { get; set; }

        [StringLength(250)]
        public string imgurl_1 { get; set; }

        [StringLength(250)]
        public string imgurl_2 { get; set; }

        [StringLength(250)]
        public string imgurl_3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietdonhang> chitietdonhangs { get; set; }

        public virtual hang hang1 { get; set; }

        public virtual loai loai1 { get; set; }
    }
}
