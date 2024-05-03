using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhapXuatChiTietController : ControllerBase
    {
        private ThuVien dbc;

        public NhapXuatChiTietController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/NhapXuatChiTiet/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblNhapXuatChitiets.ToList()
            });
        }

        [HttpPost]
        [Route("/NhapXuatChiTiet/Insert")]
        public IActionResult InsertNhapXuatChiTiet(string tenSach, float gia, int soluong)
        {
            TblNhapXuatChitiet nxct = new TblNhapXuatChitiet();
            nxct.NhapxuatchitietId = Guid.NewGuid();
            nxct.TenSach = tenSach;
            nxct.Gia = gia;
            nxct.Soluong = soluong;
            float thanhtien;
            thanhtien = gia * soluong;
            nxct.Thanhtien = thanhtien;

            dbc.TblNhapXuatChitiets.Add(nxct);
            dbc.SaveChanges();
            return Ok(new
            {
                nxct
            });
        }

        [HttpPost]
        [Route("/NhapXuatChiTiet/Update")]
        public IActionResult UpdateNhapXuatChiTiet(string NhapXuatChiTietId, string tenSach, float gia, int soluong)
        {
            TblNhapXuatChitiet nxct = new TblNhapXuatChitiet();
            nxct.NhapxuatchitietId = new Guid(NhapXuatChiTietId);
            nxct.TenSach = tenSach;
            nxct.Gia = gia;
            nxct.Soluong = soluong;
            float thanhtien;
            thanhtien = gia * soluong;
            nxct.Thanhtien = thanhtien;

            dbc.TblNhapXuatChitiets.Update(nxct);
            dbc.SaveChanges();
            return Ok(new
            {
                nxct
            });
        }

        [HttpPost]
        [Route("/NhapXuatChiTiet/Delete")]
        public IActionResult DeleteNhapXuatChiTiet(string NhapXuatChiTietId)
        {
            TblNhapXuatChitiet nxct = dbc.TblNhapXuatChitiets.Find(new Guid(NhapXuatChiTietId));
            dbc.TblNhapXuatChitiets.Remove(nxct);
            dbc.SaveChanges();
            return Ok(new
            {
                nxct
            });
        }
    }
}