using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblLog")]
    public partial class TblLog
    {
        [Key]
        [Column("logID")]
        public int LogId { get; set; }
        [Column("time", TypeName = "datetime")]
        public DateTime? Time { get; set; }
        [Column("userID")]
        public Guid? UserId { get; set; }
        [Column("thao_tac")]
        [StringLength(255)]
        public string? ThaoTac { get; set; }
        [Column("may_tinh")]
        [StringLength(50)]
        [Unicode(false)]
        public string? MayTinh { get; set; }
        [Column("ghi_chu")]
        public string? GhiChu { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("TblLogs")]
        public virtual TblUser? User { get; set; }
    }
}
