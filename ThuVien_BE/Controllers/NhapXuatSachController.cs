using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhapXuatSachController : ControllerBase
    {
        private ThuVien dbc;

        public NhapXuatSachController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/NhapXuatSach/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblNhapXuatSaches.ToList()
            });
        }

        [HttpPost]
        [Route("/NhapXuatSach/Insert")]
        public IActionResult InsertNhapXuatSach(DateTime ngay, int lnxID, float tongtien)
        {
            TblNhapXuatSach nxSach = new TblNhapXuatSach();
            nxSach.NxId = Guid.NewGuid();
            nxSach.NxNgay = ngay;
            nxSach.NxLnxId = lnxID;
            nxSach.Tongtien = tongtien;

            dbc.TblNhapXuatSaches.Add(nxSach);
            dbc.SaveChanges();
            return Ok(new
            {
                nxSach
            });
        }

        [HttpPost]
        [Route("/NhapXuatSach/Update")]
        public IActionResult UpdateNhapXuatSach(string NxId, DateTime ngay, int lnxID, float tongtien)
        {
            TblNhapXuatSach nxSach = new TblNhapXuatSach();
            nxSach.NxId = new Guid(NxId);
            nxSach.NxNgay = ngay;
            nxSach.NxLnxId = lnxID;
            nxSach.Tongtien = tongtien;

            dbc.TblNhapXuatSaches.Update(nxSach);
            dbc.SaveChanges();
            return Ok(new
            {
                nxSach
            });
        }

        [HttpPost]
        [Route("/NhapXuatSach/Delete")]
        public IActionResult DeleteNhapXuatSach(string NxId)
        {
            TblNhapXuatSach nxSach = dbc.TblNhapXuatSaches.Find(new Guid(NxId));
            dbc.TblNhapXuatSaches.Remove(nxSach);
            dbc.SaveChanges();
            return Ok(new
            {
                nxSach
            });
        }
    }
}