using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblNhapXuatChitiet")]
    public partial class TblNhapXuatChitiet
    {
        [Key]
        [Column("nhapxuatchitietID")]
        public Guid NhapxuatchitietId { get; set; }
        [Column("tenSach")]
        [StringLength(255)]
        public string? TenSach { get; set; }
        [Column("gia")]
        public double? Gia { get; set; }
        [Column("soluong")]
        public int? Soluong { get; set; }
        [Column("thanhtien")]
        public double? Thanhtien { get; set; }
        [Column("nx_id")]
        public Guid? NxId { get; set; }
        [Column("sach_id")]
        public Guid? SachId { get; set; }
        [StringLength(500)]
        public string? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }

        [ForeignKey("NxId")]
        [InverseProperty("TblNhapXuatChitiets")]
        public virtual TblNhapXuatSach? Nx { get; set; }
        [ForeignKey("SachId")]
        [InverseProperty("TblNhapXuatChitiets")]
        public virtual TblSach? Sach { get; set; }
    }
}
