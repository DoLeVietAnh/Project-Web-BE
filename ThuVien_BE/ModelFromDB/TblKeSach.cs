using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ThuVien_BE.ModelFromDB
{
    [Table("tblKeSach")]
    public partial class TblKeSach
    {
        public TblKeSach()
        {
            TblSaches = new HashSet<TblSach>();
        }

        [Key]
        [Column("KeSachID")]
        public Guid KeSachId { get; set; }
        [StringLength(100)]
        public string? TenKeSach { get; set; }
        [Column("TheLoaiID")]
        public Guid? TheLoaiId { get; set; }
        [StringLength(255)]
        public string? TheLoai { get; set; }
        [StringLength(500)]
        public string? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }

        [ForeignKey("TheLoaiId")]
        [InverseProperty("TblKeSaches")]
        [JsonIgnore]
        public virtual TblTheLoai? TheLoaiNavigation { get; set; }
        [InverseProperty("KeSach")]
        [JsonIgnore]

        public virtual ICollection<TblSach> TblSaches { get; set; }
    }
}
