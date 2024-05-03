using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NXBController : ControllerBase
    {
        private ThuVien dbc;

        public NXBController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/NXB/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblNxbs.ToList()
            });
        }

        [HttpPost]
        [Route("/NXB/Insert")]
        public IActionResult InsertNXB(string ten, string diachi, string sdt, string email)
        {
            TblNxb nxb = new TblNxb();
            nxb.NxbId = Guid.NewGuid();
            nxb.TenNxb = ten;
            nxb.DiachiLienhe = diachi;
            nxb.SdtLienhe = sdt;
            nxb.EmailLienhe = email;
            dbc.TblNxbs.Add(nxb);
            dbc.SaveChanges();
            return Ok(new
            {
                nxb
            });
        }

        [HttpPost]
        [Route("/NXB/Update")]
        public IActionResult UpdateNXB(string id, string ten, string diachi, string sdt, string email)
        {
            TblNxb nxb = new TblNxb();
            nxb.NxbId = new Guid(id);
            nxb.TenNxb = ten;
            nxb.DiachiLienhe = diachi;
            nxb.SdtLienhe = sdt;
            nxb.EmailLienhe = email;

            dbc.TblNxbs.Update(nxb);
            dbc.SaveChanges();
            return Ok(new
            {
                nxb
            });
        }

        [HttpPost]
        [Route("/NXB/Delete")]
        public IActionResult DeleteNXB(string id)
        {
            TblNxb nxb = dbc.TblNxbs.Find(new Guid(id));
            dbc.TblNxbs.Remove(nxb);
            dbc.SaveChanges();
            return Ok(new
            {
                nxb
            });
        }
    }
}