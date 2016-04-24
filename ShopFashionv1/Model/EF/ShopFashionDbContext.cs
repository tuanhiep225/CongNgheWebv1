namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    public partial class ShopFashionDbContext : DbContext
    {
        public ShopFashionDbContext()
            : base("name=ShopFashionDbContext")
        {
        }

        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<BoSuuTap> BoSuuTaps { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DanhMucSP> DanhMucSPs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<Hang> Hangs { get; set; }
        public virtual DbSet<HinhAnh> HinhAnhs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KichThuoc> KichThuocs { get; set; }
        public virtual DbSet<MauSac> MauSacs { get; set; }
        public virtual DbSet<QuangCao> QuangCaos { get; set; }
        public virtual DbSet<QuanTriVien> QuanTriViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiViet>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KichThuoc>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.KichThuoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KichThuoc>()
                .HasMany(e => e.SanPhams)
                .WithMany(e => e.KichThuocs)
                .Map(m => m.ToTable("SanPham_KichThuoc").MapLeftKey("MaSize").MapRightKey("MaSP"));

            modelBuilder.Entity<MauSac>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.MauSac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MauSac>()
                .HasMany(e => e.SanPhams)
                .WithMany(e => e.MauSacs)
                .Map(m => m.ToTable("SanPham_MauSac").MapLeftKey("MaMau").MapRightKey("MaSP"));

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);
        }
    }
}
