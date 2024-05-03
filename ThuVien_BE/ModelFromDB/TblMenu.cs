using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblMenu")]
    public partial class TblMenu
    {
        public TblMenu()
        {
            TblGroupMenus = new HashSet<TblGroupMenu>();
        }

        [Key]
        [Column("menuID")]
        public Guid MenuId { get; set; }
        [Column("menuTen")]
        [StringLength(255)]
        public string? MenuTen { get; set; }
        [Column("menuView")]
        [StringLength(50)]
        public string? MenuView { get; set; }
        [Column("menuURL")]
        [StringLength(50)]
        public string? MenuUrl { get; set; }
        [Column("active")]
        public bool? Active { get; set; }
        [Column("ngaytao", TypeName = "datetime")]
        public DateTime? Ngaytao { get; set; }
        [Column("nguoitao")]
        [StringLength(500)]
        public string? Nguoitao { get; set; }
        [Column("nguoitao_uid")]
        [StringLength(50)]
        public string? NguoitaoUid { get; set; }
        [Column("nguoisua")]
        [StringLength(50)]
        public string? Nguoisua { get; set; }
        [Column("ngaysua", TypeName = "datetime")]
        public DateTime? Ngaysua { get; set; }

        [InverseProperty("Menu")]
        public virtual ICollection<TblGroupMenu> TblGroupMenus { get; set; }
    }
}
