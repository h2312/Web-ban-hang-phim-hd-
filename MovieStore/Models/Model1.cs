namespace MovieStore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model14")
        {
        }

        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<chitiethoadon> chitiethoadons { get; set; }
        public virtual DbSet<danhmucphim> danhmucphims { get; set; }
        public virtual DbSet<hoadon> hoadons { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<phim> phims { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<danhmucphim>()
                .HasMany(e => e.phims)
                .WithRequired(e => e.danhmucphim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hoadon>()
                .HasMany(e => e.chitiethoadons)
                .WithRequired(e => e.hoadon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<khachhang>()
                .Property(e => e.sdt)
                .IsFixedLength();

            modelBuilder.Entity<phim>()
                .Property(e => e.thoiluongphim)
                .IsFixedLength();

            modelBuilder.Entity<phim>()
                .HasMany(e => e.chitiethoadons)
                .WithRequired(e => e.phim)
                .WillCascadeOnDelete(false);
        }
    }
}
