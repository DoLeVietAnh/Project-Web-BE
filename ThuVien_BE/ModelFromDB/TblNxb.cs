using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblNXB")]
    public partial class TblNxb
    {
        public TblNxb()
        {
            TblNhapXuatSaches = new HashSet<TblNhapXuatSach>();
            TblSaches = new HashSet<TblSach>();
        }

        [Key]
        [Column("NXB_ID")]
        public Guid NxbId { get; set; }
        [Column("TenNXB")]
        [StringLength(255)]
        public string? TenNxb { get; set; }
        [Column("sdt_lienhe")]
        [StringLength(50)]
        public string? SdtLienhe { get; set; }
        [Column("email_lienhe")]
        [StringLength(500)]
        public string? EmailLienhe { get; set; }
        [Column("diachi_lienhe")]
        [StringLength(500)]
        public string? DiachiLienhe { get; set; }
        [StringLength(500)]
        public string? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }

        [InverseProperty("NxNxb")]
        public virtual ICollection<TblNhapXuatSach> TblNhapXuatSaches { get; set; }
        [InverseProperty("Nxb")]
        public virtual ICollection<TblSach> TblSaches { get; set; }
    }
}
