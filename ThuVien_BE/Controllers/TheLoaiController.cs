using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaiController : ControllerBase
    {
        private ThuVien dbc;

        public TheLoaiController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/TheLoai/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblTheLoais.ToList()
            });
        }

        [HttpPost]
        [Route("/TheLoai/Insert")]
        public IActionResult InsertTheLoai(string ten)
        {
            TblTheLoai theloai = new TblTheLoai();
            theloai.TheloaiId = Guid.NewGuid();
            theloai.TenTheloai = ten;

            dbc.TblTheLoais.Add(theloai);
            dbc.SaveChanges();
            return Ok(new
            {
                theloai
            });
        }

        [HttpPost]
        [Route("/TheLoai/Update")]
        public IActionResult UpdateTheLoai(string id, string ten)
        {
            TblTheLoai theloai = new TblTheLoai();
            theloai.TheloaiId = new Guid(id);
            theloai.TenTheloai = ten;

            dbc.TblTheLoais.Update(theloai);
            dbc.SaveChanges();
            return Ok(new
            {
                theloai
            });
        }

        [HttpPost]
        [Route("/TheLoai/Delete")]
        public IActionResult DeleteTheLoai(string id)
        {
            TblTheLoai theloai = new TblTheLoai();
            theloai.TheloaiId = new Guid(id);

            dbc.TblTheLoais.Remove(theloai);
            dbc.SaveChanges();
            return Ok(new
            {
                theloai
            });
        }
    }
}