using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SachController : ControllerBase
    {
        private ThuVien dbc;

        public SachController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/Sach/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblSaches.ToList()
            });
        }

        [HttpPost]
        [Route("/Sach/Insert")]
        public IActionResult InsertSach(string ten, string tenNXB, string biasach, string ghichu, int sotrang, string anh, string tomtat)
        {
            TblSach sach = new TblSach();
            sach.SachId = Guid.NewGuid();
            sach.TenSach = ten;
            sach.TenNxb = tenNXB;
            sach.BiaSach = biasach;
            sach.GhiChu = ghichu;
            sach.SoTrang = sotrang;
            sach.Anh = anh;
            sach.Tomtat = tomtat;


            dbc.TblSaches.Add(sach);
            dbc.SaveChanges();
            return Ok(new
            {
                sach
            });
        }

        [HttpPost]
        [Route("/Sach/Update")]
        public IActionResult UpdateSach(string id, string ten, string tenNXB, string biasach, string ghichu, int sotrang, string anh, string tomtat)
        {
            TblSach sach = new TblSach();
            sach.SachId = new Guid(id);
            sach.TenSach = ten;
            sach.TenNxb = tenNXB;
            sach.BiaSach = biasach;
            sach.GhiChu = ghichu;
            sach.SoTrang = sotrang;
            sach.Anh = anh;
            sach.Tomtat = tomtat;

            dbc.TblSaches.Update(sach);
            dbc.SaveChanges();
            return Ok(new
            {
                sach
            });
        }

        [HttpPost]
        [Route("/Sach/Delete")]
        public IActionResult DeleteSach(string id)
        {
            TblSach sach = new TblSach();
            sach.SachId = new Guid(id);
            dbc.TblSaches.Remove(sach);
            dbc.SaveChanges();
            return Ok(new
            {
                sach
            });
        }
    }
}