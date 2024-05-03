using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblMuonTra")]
    public partial class TblMuonTra
    {
        [Key]
        [Column("ms_id")]
        public Guid MsId { get; set; }
        [Column("ms_ngay", TypeName = "datetime")]
        public DateTime? MsNgay { get; set; }
        [Column("ms_khach_id")]
        public Guid? MsKhachId { get; set; }
        [Column("ms_nhanvien_id")]
        public Guid? MsNhanvienId { get; set; }
        [Column("ms_ngaytra", TypeName = "datetime")]
        public DateTime? MsNgaytra { get; set; }
        [Column("ms_datra")]
        public int? MsDatra { get; set; }
        [Column("ms_sach_id")]
        public Guid? MsSachId { get; set; }
        [Column("ms_sach_soluong")]
        public int? MsSachSoluong { get; set; }

        [ForeignKey("MsKhachId")]
        [InverseProperty("TblMuonTras")]
        public virtual TblKhach? MsKhach { get; set; }
        [ForeignKey("MsNhanvienId")]
        [InverseProperty("TblMuonTras")]
        public virtual TblNhanVien? MsNhanvien { get; set; }
        [ForeignKey("MsSachId")]
        [InverseProperty("TblMuonTras")]
        public virtual TblSach? MsSach { get; set; }
    }
}
