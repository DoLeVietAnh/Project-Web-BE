using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblSach")]
    public partial class TblSach
    {
        public TblSach()
        {
            TblMuonTras = new HashSet<TblMuonTra>();
            TblNhapXuatChitiets = new HashSet<TblNhapXuatChitiet>();
        }

        [Key]
        [Column("SachID")]
        public Guid SachId { get; set; }
        [StringLength(255)]
        public string? TenSach { get; set; }
        [StringLength(500)]
        public string? TacGia { get; set; }
        [Column("TacGiaID")]
        public Guid? TacGiaId { get; set; }
        [StringLength(500)]
        public string? TheLoai { get; set; }
        [Column("TheLoai_ID")]
        public Guid? TheLoaiId { get; set; }
        [Column("TenNXB")]
        [StringLength(255)]
        public string? TenNxb { get; set; }
        public string? BiaSach { get; set; }
        public int? SoLuongSach { get; set; }
        public int? SoTrang { get; set; }
        public string? Anh { get; set; }
        public string? Tomtat { get; set; }
        [Column("ghiChu")]
        [StringLength(1000)]
        public string? GhiChu { get; set; }
        [Column("KeSachID")]
        public Guid? KeSachId { get; set; }
        [Column("NhanVienID")]
        public Guid? NhanVienId { get; set; }
        [Column("NXB_ID")]
        public Guid? NxbId { get; set; }
        [StringLength(500)]
        public string? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }

        [ForeignKey("KeSachId")]
        [InverseProperty("TblSaches")]
        public virtual TblKeSach? KeSach { get; set; }
        [ForeignKey("NxbId")]
        [InverseProperty("TblSaches")]
        public virtual TblNxb? Nxb { get; set; }
        [ForeignKey("TacGiaId")]
        [InverseProperty("TblSaches")]
        public virtual TblTacGium? TacGiaNavigation { get; set; }
        [ForeignKey("TheLoaiId")]
        [InverseProperty("TblSaches")]
        public virtual TblTheLoai? TheLoaiNavigation { get; set; }
        [InverseProperty("MsSach")]
        public virtual ICollection<TblMuonTra> TblMuonTras { get; set; }
        [InverseProperty("Sach")]
        public virtual ICollection<TblNhapXuatChitiet> TblNhapXuatChitiets { get; set; }
    }
}
