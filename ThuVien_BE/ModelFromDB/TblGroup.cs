using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblGroup")]
    public partial class TblGroup
    {
        public TblGroup()
        {
            TblGroupMenus = new HashSet<TblGroupMenu>();
        }

        [Key]
        [Column("groupID")]
        public Guid GroupId { get; set; }
        [Column("groupMa")]
        [StringLength(255)]
        public string? GroupMa { get; set; }
        [Column("groupTen")]
        [StringLength(255)]
        public string? GroupTen { get; set; }

        [InverseProperty("Group")]
        public virtual ICollection<TblGroupMenu> TblGroupMenus { get; set; }
    }
}
