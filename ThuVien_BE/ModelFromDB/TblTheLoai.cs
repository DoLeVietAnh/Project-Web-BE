using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblTheLoai")]
    public partial class TblTheLoai
    {
        public TblTheLoai()
        {
            TblKeSaches = new HashSet<TblKeSach>();
            TblSaches = new HashSet<TblSach>();
        }

        [Key]
        [Column("theloaiID")]
        public Guid TheloaiId { get; set; }
        [Column("tenTheloai")]
        [StringLength(255)]
        public string? TenTheloai { get; set; }
        [StringLength(500)]
        public string? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }

        [InverseProperty("TheLoaiNavigation")]
        public virtual ICollection<TblKeSach> TblKeSaches { get; set; }
        [InverseProperty("TheLoaiNavigation")]
        public virtual ICollection<TblSach> TblSaches { get; set; }
    }
}
