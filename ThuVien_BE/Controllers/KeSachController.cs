using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeSachController : ControllerBase
    {
        private ThuVien dbc;

        public KeSachController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/KeSach/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblKeSaches.ToList()
            });
        }

        [HttpPost]
        [Route("/KeSach/Insert")]
        public IActionResult InsertKeSach(string TenKe, string TheLoai)
        {
            TblTheLoai theloai = dbc.TblTheLoais.FirstOrDefault(t => t.TenTheloai == TheLoai);

            if (theloai != null)
            {
                TblKeSach keSach = new TblKeSach();
                keSach.KeSachId = Guid.NewGuid();
                keSach.TenKeSach = TenKe;
                keSach.TheLoai = TheLoai;
                keSach.TheLoaiId = theloai.TheloaiId;
                dbc.TblKeSaches.Add(keSach);

                dbc.SaveChanges();
                return Ok(new { keSach });
            }
            else
            {
                return BadRequest("Không tìm thấy thể loại");
            }
        }

        [HttpPost]
        [Route("/KeSach/Update")]
        public IActionResult UpdateKeSach(string KeSachId, string TenKe, string TheLoai)
        {
            TblKeSach keSach = new TblKeSach();
            keSach.KeSachId = new Guid(KeSachId);
            keSach.TenKeSach = TenKe;
            keSach.TheLoai = TheLoai;

            dbc.TblKeSaches.Update(keSach);
            dbc.SaveChanges();
            return Ok(new
            {
                keSach
            });
        }

        [HttpPost]
        [Route("/KeSach/Delete")]
        public IActionResult DeleteKeSach(string KeSachId)
        {
            TblKeSach keSach = dbc.TblKeSaches.Find(new Guid(KeSachId));
            dbc.TblKeSaches.Remove(keSach);
            dbc.SaveChanges();
            return Ok(new
            {
                keSach
            });
        }
    }
}