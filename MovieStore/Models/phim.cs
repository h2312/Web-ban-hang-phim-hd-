namespace MovieStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("phim")]
    public partial class phim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phim()
        {
            chitiethoadons = new HashSet<chitiethoadon>();
        }

        [Key]
        public int idphim { get; set; }

        [StringLength(50)]
        public string tenphim { get; set; }

        public double? gia { get; set; }

        public int? soluong { get; set; }

        [StringLength(50)]
        public string availability { get; set; }

        [StringLength(50)]
        public string hinh { get; set; }

        public int madm { get; set; }

        [StringLength(10)]
        public string thoiluongphim { get; set; }

        public int? phimbomtan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitiethoadon> chitiethoadons { get; set; }

        public virtual danhmucphim danhmucphim { get; set; }
    }
}
