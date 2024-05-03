using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacGiaController : ControllerBase
    {
        private ThuVien dbc;

        public TacGiaController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/TacGia/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblTacGias.ToList()
            });
        }

        [HttpPost]
        [Route("/TacGia/Insert")]
        public IActionResult InsertTacGia(string ten, string diachi, string email, string sdt)
        {
            TblTacGia tacgia = new TblTacGia();
            tacgia.TacGiaId = Guid.NewGuid();
            tacgia.TenTacGia = ten;
            tacgia.DiaChi = diachi;
            tacgia.EmailLienhe = email;
            tacgia.SdtLienhe = sdt;

            dbc.TblTacGias.Add(tacgia);
            dbc.SaveChanges();
            return Ok(new
            {
                tacgia
            });
        }

        [HttpPost]
        [Route("/TacGia/Update")]
        public IActionResult UpdateTacGia(string id, string ten, string diachi, string email, string sdt)
        {
            TblTacGia tacgia = new TblTacGia();
            tacgia.TacGiaId = new Guid(id);
            tacgia.TenTacGia = ten;
            tacgia.DiaChi = diachi;
            tacgia.EmailLienhe = email;
            tacgia.SdtLienhe = sdt;

            dbc.TblTacGias.Update(tacgia);
            dbc.SaveChanges();
            return Ok(new
            {
                tacgia
            });
        }

        [HttpPost]
        [Route("/TacGia/Delete")]
        public IActionResult DeleteTacGia(string id)
        {
            TblTacGia tacgia = dbc.TblTacGias.Find(new Guid(id));
            dbc.TblTacGias.Remove(tacgia);
            dbc.SaveChanges();
            return Ok(new
            {
                tacgia
            });
        }
    }
}