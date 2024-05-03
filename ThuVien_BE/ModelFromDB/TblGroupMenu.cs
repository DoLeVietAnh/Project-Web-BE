using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblGroup_Menu")]
    public partial class TblGroupMenu
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("menuID")]
        public Guid? MenuId { get; set; }
        [Column("groupID")]
        public Guid? GroupId { get; set; }
        [Column("them")]
        public bool? Them { get; set; }
        [Column("sua")]
        public bool? Sua { get; set; }
        [Column("xoa")]
        public bool? Xoa { get; set; }
        [Column("xem")]
        public bool? Xem { get; set; }
        [Column("xuatFile")]
        public bool? XuatFile { get; set; }
        [Column("timKiem")]
        public bool? TimKiem { get; set; }

        [ForeignKey("GroupId")]
        [InverseProperty("TblGroupMenus")]
        public virtual TblGroup? Group { get; set; }
        [ForeignKey("MenuId")]
        [InverseProperty("TblGroupMenus")]
        public virtual TblMenu? Menu { get; set; }
    }
}
