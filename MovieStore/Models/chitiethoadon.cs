namespace MovieStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitiethoadon")]
    public partial class chitiethoadon
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mahd { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idphim { get; set; }

        [StringLength(50)]
        public string tenphim { get; set; }

        public int? soluong { get; set; }

        public double? gia { get; set; }

        public double? thanhtien { get; set; }

        public virtual hoadon hoadon { get; set; }

        public virtual phim phim { get; set; }
    }
}
