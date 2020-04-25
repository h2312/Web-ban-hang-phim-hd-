namespace MovieStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("khachhang")]
    public partial class khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khachhang()
        {
            hoadons = new HashSet<hoadon>();
        }

        [Key]
        public int makh { get; set; }

        [Required]
        [StringLength(50)]
        public string tenkh { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        [StringLength(10)]
        public string sdt { get; set; }

        [StringLength(50)]
        public string diachi { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon> hoadons { get; set; }
    }
}
