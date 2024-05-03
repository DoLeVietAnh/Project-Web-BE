﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblTacGia")]
    public partial class TblTacGia
    {
        public TblTacGia()
        {
            TblSaches = new HashSet<TblSach>();
        }

        [Key]
        [Column("TacGiaID")]
        public Guid TacGiaId { get; set; }
        [StringLength(100)]
        public string? TenTacGia { get; set; }
        [StringLength(255)]
        public string? DiaChi { get; set; }
        [Column("email_lienhe")]
        [StringLength(500)]
        public string? EmailLienhe { get; set; }
        [Column("sdt_lienhe")]
        [StringLength(50)]
        public string? SdtLienhe { get; set; }
        [StringLength(500)]
        public string? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }

        [InverseProperty("TacGia")]
        public virtual ICollection<TblSach> TblSaches { get; set; }
    }
}
