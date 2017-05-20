namespace DemoProject.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyDbContext")
        {
        }

        public virtual DbSet<tblGiangDay> tblGiangDays { get; set; }
        public virtual DbSet<tblGiaoVien> tblGiaoViens { get; set; }
        public virtual DbSet<tblHocSinh> tblHocSinhs { get; set; }
        public virtual DbSet<tblLop> tblLops { get; set; }
        public virtual DbSet<tblMonHoc> tblMonHocs { get; set; }
        public virtual DbSet<tblPhanQuyen> tblPhanQuyens { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblGiaoVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<tblGiaoVien>()
                .HasMany(e => e.tblGiangDays)
                .WithRequired(e => e.tblGiaoVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblGiaoVien>()
                .HasMany(e => e.tblLops)
                .WithOptional(e => e.tblGiaoVien)
                .HasForeignKey(e => e.GVCN);

            modelBuilder.Entity<tblLop>()
                .HasMany(e => e.tblGiangDays)
                .WithRequired(e => e.tblLop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblPhanQuyen>()
                .HasMany(e => e.tblUsers)
                .WithRequired(e => e.tblPhanQuyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            //modelBuilder.Entity<tblUser>()
            //    .Property(e => e.MaGV)
            //    .IsUnicode(false);
        }
    }
}
