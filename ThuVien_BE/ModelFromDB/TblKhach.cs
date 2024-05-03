using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblKhach")]
    public partial class TblKhach
    {
        public TblKhach()
        {
            TblMuonTras = new HashSet<TblMuonTra>();
            TblUsers = new HashSet<TblUser>();
        }

        [Key]
        [Column("KhachID")]
        public Guid KhachId { get; set; }
        [Column("userID")]
        public Guid? UserId { get; set; }
        [StringLength(255)]
        public string? TenKhach { get; set; }
        [StringLength(255)]
        public string? HoKhach { get; set; }
        [Column("SDT")]
        public int? Sdt { get; set; }
        [StringLength(255)]
        public string? Email { get; set; }
        [StringLength(500)]
        public string? DiaChi { get; set; }
        [StringLength(255)]
        public string? GioiTinh { get; set; }
        [StringLength(255)]
        public string? Ngaysinh { get; set; }
        [StringLength(500)]
        public string? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }

        [InverseProperty("MsKhach")]
        public virtual ICollection<TblMuonTra> TblMuonTras { get; set; }
        [InverseProperty("Khach")]
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
