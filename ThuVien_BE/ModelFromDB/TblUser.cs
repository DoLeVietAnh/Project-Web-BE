using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblUser")]
    public partial class TblUser
    {
        public TblUser()
        {
            TblLogs = new HashSet<TblLog>();
            TblUserGroups = new HashSet<TblUserGroup>();
        }

        [Key]
        [Column("userID")]
        public Guid UserId { get; set; }
        [Column("NhanvienID")]
        public Guid? NhanvienId { get; set; }
        [Column("KhachID")]
        public Guid? KhachId { get; set; }
        [Column("fullname")]
        [StringLength(100)]
        public string? Fullname { get; set; }
        [Column("pass")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Pass { get; set; }
        [Column("avata")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Avata { get; set; }

        [ForeignKey("KhachId")]
        [InverseProperty("TblUsers")]
        public virtual TblKhach? Khach { get; set; }
        [ForeignKey("NhanvienId")]
        [InverseProperty("TblUsers")]
        public virtual TblNhanVien? Nhanvien { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<TblLog> TblLogs { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<TblUserGroup> TblUserGroups { get; set; }
    }
}
