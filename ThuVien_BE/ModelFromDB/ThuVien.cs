using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    public partial class ThuVien : DbContext
    {
        public ThuVien()
        {
        }

        public ThuVien(DbContextOptions<ThuVien> options)
            : base(options)
        {
        }

        public virtual DbSet<TblGroup> TblGroups { get; set; } = null!;
        public virtual DbSet<TblGroupMenu> TblGroupMenus { get; set; } = null!;
        public virtual DbSet<TblKeSach> TblKeSaches { get; set; } = null!;
        public virtual DbSet<TblKhach> TblKhaches { get; set; } = null!;
        public virtual DbSet<TblLog> TblLogs { get; set; } = null!;
        public virtual DbSet<TblMenu> TblMenus { get; set; } = null!;
        public virtual DbSet<TblMuonTra> TblMuonTras { get; set; } = null!;
        public virtual DbSet<TblNhanVien> TblNhanViens { get; set; } = null!;
        public virtual DbSet<TblNhapXuatChitiet> TblNhapXuatChitiets { get; set; } = null!;
        public virtual DbSet<TblNhapXuatSach> TblNhapXuatSaches { get; set; } = null!;
        public virtual DbSet<TblNxb> TblNxbs { get; set; } = null!;
        public virtual DbSet<TblSach> TblSaches { get; set; } = null!;
        public virtual DbSet<TblTacGia> TblTacGias { get; set; } = null!;
        public virtual DbSet<TblTheLoai> TblTheLoais { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;
        public virtual DbSet<TblUserGroup> TblUserGroups { get; set; } = null!;

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ThuVien;Persist Security Info=True;User ID=vanh1414;Password=123");
        //            }
        //        }

        //        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //        {
        //            modelBuilder.Entity<TblGroup>(entity =>
        //            {
        //                entity.HasKey(e => e.GroupId)
        //                    .HasName("PK__tblGroup__88C102ADAFD0CE2C");

        //                entity.Property(e => e.GroupId).ValueGeneratedNever();
        //            });

        //            modelBuilder.Entity<TblGroupMenu>(entity =>
        //            {
        //                entity.Property(e => e.Id).ValueGeneratedNever();

        //                entity.HasOne(d => d.Group)
        //                    .WithMany(p => p.TblGroupMenus)
        //                    .HasForeignKey(d => d.GroupId)
        //                    .HasConstraintName("FK__tblGroup___group__59063A47");

        //                entity.HasOne(d => d.Menu)
        //                    .WithMany(p => p.TblGroupMenus)
        //                    .HasForeignKey(d => d.MenuId)
        //                    .HasConstraintName("FK__tblGroup___menuI__5812160E");
        //            });

        //            modelBuilder.Entity<TblKeSach>(entity =>
        //            {
        //                entity.HasKey(e => e.KeSachId)
        //                    .HasName("PK__tblKeSac__EA338915760BB59A");

        //                entity.Property(e => e.KeSachId).ValueGeneratedNever();

        //                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");

        //                entity.HasOne(d => d.TheLoaiNavigation)
        //                    .WithMany(p => p.TblKeSaches)
        //                    .HasForeignKey(d => d.TheLoaiId)
        //                    .HasConstraintName("FK_tblKeSach_tblTheLoai");
        //            });

        //            modelBuilder.Entity<TblKhach>(entity =>
        //            {
        //                entity.HasKey(e => e.KhachId)
        //                    .HasName("PK__tblKhach__AB0C18993E3D8795");

        //                entity.Property(e => e.KhachId).ValueGeneratedNever();

        //                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
        //            });

        //            modelBuilder.Entity<TblLog>(entity =>
        //            {
        //                entity.HasKey(e => e.LogId)
        //                    .HasName("PK__tblLog__7839F62DCA59D9B6");

        //                entity.Property(e => e.LogId).ValueGeneratedNever();

        //                entity.HasOne(d => d.User)
        //                    .WithMany(p => p.TblLogs)
        //                    .HasForeignKey(d => d.UserId)
        //                    .HasConstraintName("FK__tblLog__userID__6FE99F9F");
        //            });

        //            modelBuilder.Entity<TblMenu>(entity =>
        //            {
        //                entity.HasKey(e => e.MenuId)
        //                    .HasName("PK__tblMenu__3B407E941474AA4C");

        //                entity.Property(e => e.MenuId).ValueGeneratedNever();

        //                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

        //                entity.Property(e => e.Ngaytao).HasDefaultValueSql("(getdate())");
        //            });

        //            modelBuilder.Entity<TblMuonTra>(entity =>
        //            {
        //                entity.Property(e => e.MsId).ValueGeneratedNever();

        //                entity.Property(e => e.MsDatra).HasDefaultValueSql("((0))");

        //                entity.HasOne(d => d.MsKhach)
        //                    .WithMany(p => p.TblMuonTras)
        //                    .HasForeignKey(d => d.MsKhachId)
        //                    .OnDelete(DeleteBehavior.Cascade)
        //                    .HasConstraintName("FK_tblMuonTra_tblKhach");

        //                entity.HasOne(d => d.MsNhanvien)
        //                    .WithMany(p => p.TblMuonTras)
        //                    .HasForeignKey(d => d.MsNhanvienId)
        //                    .OnDelete(DeleteBehavior.Cascade)
        //                    .HasConstraintName("FK_tblMuonTra_tblNhanVien");

        //                entity.HasOne(d => d.MsSach)
        //                    .WithMany(p => p.TblMuonTras)
        //                    .HasForeignKey(d => d.MsSachId)
        //                    .OnDelete(DeleteBehavior.Cascade)
        //                    .HasConstraintName("FK_tblMuonTra_tblSach");
        //            });

        //            modelBuilder.Entity<TblNhanVien>(entity =>
        //            {
        //                entity.HasKey(e => e.NhanVienId)
        //                    .HasName("PK__tblNhanV__E27FD7EAB0ECDBF4");

        //                entity.Property(e => e.NhanVienId).ValueGeneratedNever();

        //                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
        //            });

        //            modelBuilder.Entity<TblNhapXuatChitiet>(entity =>
        //            {
        //                entity.HasKey(e => e.NhapxuatchitietId)
        //                    .HasName("PK__tblNhapX__1E3FB5E243029CE1");

        //                entity.Property(e => e.NhapxuatchitietId).ValueGeneratedNever();

        //                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");

        //                entity.HasOne(d => d.Nx)
        //                    .WithMany(p => p.TblNhapXuatChitiets)
        //                    .HasForeignKey(d => d.NxId)
        //                    .OnDelete(DeleteBehavior.Cascade)
        //                    .HasConstraintName("FK_tblNhapXuatChitiet_tblNhapXuatSach");

        //                entity.HasOne(d => d.Sach)
        //                    .WithMany(p => p.TblNhapXuatChitiets)
        //                    .HasForeignKey(d => d.SachId)
        //                    .HasConstraintName("FK_tblNhapXuatChitiet_tblSach");
        //            });

        //            modelBuilder.Entity<TblNhapXuatSach>(entity =>
        //            {
        //                entity.Property(e => e.NxId).ValueGeneratedNever();

        //                entity.Property(e => e.Ngaytao).HasDefaultValueSql("(getdate())");

        //                entity.Property(e => e.NxLnxId).HasComment("1. nhap/2. xuat");

        //                entity.HasOne(d => d.NxNv)
        //                    .WithMany(p => p.TblNhapXuatSaches)
        //                    .HasForeignKey(d => d.NxNvId)
        //                    .OnDelete(DeleteBehavior.Cascade)
        //                    .HasConstraintName("FK_tblNhapXuatSach_tblNhanVien");

        //                entity.HasOne(d => d.NxNxb)
        //                    .WithMany(p => p.TblNhapXuatSaches)
        //                    .HasForeignKey(d => d.NxNxbId)
        //                    .OnDelete(DeleteBehavior.Cascade)
        //                    .HasConstraintName("FK_tblNhapXuatSach_tblNXB");
        //            });

        //            modelBuilder.Entity<TblNxb>(entity =>
        //            {
        //                entity.HasKey(e => e.NxbId)
        //                    .HasName("PK__tblNXB__13416E68FD06244B");

        //                entity.Property(e => e.NxbId).ValueGeneratedNever();

        //                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
        //            });

        //            modelBuilder.Entity<TblSach>(entity =>
        //            {
        //                entity.HasKey(e => e.SachId)
        //                    .HasName("PK__tblSach__F3005E3AAE76CBB9");

        //                entity.Property(e => e.SachId).ValueGeneratedNever();

        //                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");

        //                entity.HasOne(d => d.KeSach)
        //                    .WithMany(p => p.TblSaches)
        //                    .HasForeignKey(d => d.KeSachId)
        //                    .OnDelete(DeleteBehavior.Cascade)
        //                    .HasConstraintName("FK_tblSach_tblKeSach");

        //                entity.HasOne(d => d.Nxb)
        //                    .WithMany(p => p.TblSaches)
        //                    .HasForeignKey(d => d.NxbId)
        //                    .OnDelete(DeleteBehavior.Cascade)
        //                    .HasConstraintName("FK_tblSach_tblNXB");

        //                entity.HasOne(d => d.TacGiaNavigation)
        //                    .WithMany(p => p.TblSaches)
        //                    .HasForeignKey(d => d.TacGiaId)
        //                    .OnDelete(DeleteBehavior.Cascade)
        //                    .HasConstraintName("FK_tblSach_tblTacGia");

        //                entity.HasOne(d => d.TheLoaiNavigation)
        //                    .WithMany(p => p.TblSaches)
        //                    .HasForeignKey(d => d.TheLoaiId)
        //                    .OnDelete(DeleteBehavior.Cascade)
        //                    .HasConstraintName("FK_tblSach_tblTheLoai");
        //            });

        //            modelBuilder.Entity<TblTacGium>(entity =>
        //            {
        //                entity.HasKey(e => e.TacGiaId)
        //                    .HasName("PK__tblTacGi__E80230C94E528115");

        //                entity.Property(e => e.TacGiaId).ValueGeneratedNever();

        //                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
        //            });

        //            modelBuilder.Entity<TblTheLoai>(entity =>
        //            {
        //                entity.HasKey(e => e.TheloaiId)
        //                    .HasName("PK__tblTheLo__14F395D2C04F6D7B");

        //                entity.Property(e => e.TheloaiId).ValueGeneratedNever();

        //                entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
        //            });

        //            modelBuilder.Entity<TblUser>(entity =>
        //            {
        //                entity.HasKey(e => e.UserId)
        //                    .HasName("PK__tblUser__CB9A1CDF9B184D75");

        //                entity.Property(e => e.UserId).ValueGeneratedNever();

        //                entity.HasOne(d => d.Khach)
        //                    .WithMany(p => p.TblUsers)
        //                    .HasForeignKey(d => d.KhachId)
        //                    .OnDelete(DeleteBehavior.Cascade)
        //                    .HasConstraintName("FK_tblUser_tblKhach");

        //                entity.HasOne(d => d.Nhanvien)
        //                    .WithMany(p => p.TblUsers)
        //                    .HasForeignKey(d => d.NhanvienId)
        //                    .OnDelete(DeleteBehavior.Cascade)
        //                    .HasConstraintName("FK_tblUser_tblNhanVien");
        //            });

        //            modelBuilder.Entity<TblUserGroup>(entity =>
        //            {
        //                entity.HasKey(e => e.UgId)
        //                    .HasName("PK__tblUser___E84F927E5F903C37");

        //                entity.Property(e => e.UgId).ValueGeneratedNever();

        //                entity.HasOne(d => d.User)
        //                    .WithMany(p => p.TblUserGroups)
        //                    .HasForeignKey(d => d.UserId)
        //                    .HasConstraintName("FK_tblUser_Group_tblUser");
        //            });

        //            OnModelCreatingPartial(modelBuilder);
        //        }

        //        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
