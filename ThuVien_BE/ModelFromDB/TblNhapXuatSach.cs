using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblNhapXuatSach")]
    public partial class TblNhapXuatSach
    {
        public TblNhapXuatSach()
        {
            TblNhapXuatChitiets = new HashSet<TblNhapXuatChitiet>();
        }

        [Key]
        [Column("nx_id")]
        public Guid NxId { get; set; }
        [Column("nx_nxb_id")]
        public Guid? NxNxbId { get; set; }
        [Column("nx_nv_id")]
        public Guid? NxNvId { get; set; }
        [Column("nx_ngay", TypeName = "datetime")]
        public DateTime? NxNgay { get; set; }
        /// <summary>
        /// 1. nhap/2. xuat
        /// </summary>
        [Column("nx_lnx_id")]
        public int? NxLnxId { get; set; }
        [Column("tongtien")]
        public double? Tongtien { get; set; }
        [Column("ngaytao", TypeName = "datetime")]
        public DateTime? Ngaytao { get; set; }
        [Column("nguoitao")]
        [StringLength(500)]
        public string? Nguoitao { get; set; }

        [ForeignKey("NxNvId")]
        [InverseProperty("TblNhapXuatSaches")]
        public virtual TblNhanVien? NxNv { get; set; }
        [ForeignKey("NxNxbId")]
        [InverseProperty("TblNhapXuatSaches")]
        public virtual TblNxb? NxNxb { get; set; }
        [InverseProperty("Nx")]
        public virtual ICollection<TblNhapXuatChitiet> TblNhapXuatChitiets { get; set; }
    }
}
