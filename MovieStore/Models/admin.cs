namespace MovieStore.Models
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

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(10)]
        public string password { get; set; }
    }
}
