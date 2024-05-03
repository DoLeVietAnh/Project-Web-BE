using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblNhanVien")]
    public partial class TblNhanVien
    {
        public TblNhanVien()
        {
            TblMuonTras = new HashSet<TblMuonTra>();
            TblNhapXuatSaches = new HashSet<TblNhapXuatSach>();
            TblUsers = new HashSet<TblUser>();
        }

        [Key]
        [Column("NhanVienID")]
        public Guid NhanVienId { get; set; }
        [StringLength(100)]
        public string? HoTen { get; set; }
        [StringLength(100)]
        public string? ChucVu { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Ngaysinh { get; set; }
        [Column("SDT")]
        public int? Sdt { get; set; }
        [StringLength(500)]
        public string? Email { get; set; }
        [StringLength(50)]
        public string? GioiTinh { get; set; }
        [StringLength(500)]
        public string? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }

        [InverseProperty("MsNhanvien")]
        public virtual ICollection<TblMuonTra> TblMuonTras { get; set; }
        [InverseProperty("NxNv")]
        public virtual ICollection<TblNhapXuatSach> TblNhapXuatSaches { get; set; }
        [InverseProperty("Nhanvien")]
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
