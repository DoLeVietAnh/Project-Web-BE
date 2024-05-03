using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblUser_Group")]
    public partial class TblUserGroup
    {
        [Key]
        [Column("UG_ID")]
        public int UgId { get; set; }
        [Column("groupID")]
        public Guid? GroupId { get; set; }
        [Column("userID")]
        public Guid? UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("TblUserGroups")]
        public virtual TblUser? User { get; set; }
    }
}
