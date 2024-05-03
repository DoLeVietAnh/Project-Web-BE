using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private ThuVien dbc;

        public NhanVienController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/NhanVien/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblNhanViens.ToList()
            });
        }

        [HttpPost]
        [Route("/NhanVien/Insert")]
        public IActionResult InsertNhanVien(string hoten, string chucvu, DateTime ngaysinh, int sdt, string email, string gioitinh)
        {
            TblNhanVien nv = new TblNhanVien();
            nv.HoTen = hoten;
            nv.ChucVu = chucvu;
            nv.Ngaysinh = ngaysinh;

            var phoneNumber = Convert.ToString(sdt);
            var formattedPhoneNumber = string.Format("{0:(###) ###-####}", phoneNumber);
            var phoneNumberInt = Convert.ToInt32(formattedPhoneNumber);
            nv.Sdt = phoneNumberInt;

            nv.Email = email;
            nv.GioiTinh = gioitinh;

            dbc.TblNhanViens.Add(nv);
            dbc.SaveChanges();
            return Ok(new
            {
                nv
            });
        }

        [HttpPost]
        [Route("/NhanVien/Update")]
        public IActionResult UpdateNhanVien(string NhanVienId, string hoten, string chucvu, DateTime ngaysinh, int sdt, string email, string gioitinh)
        {
            TblNhanVien nv = new TblNhanVien();
            nv.NhanVienId = new Guid(NhanVienId);
            nv.HoTen = hoten;
            nv.ChucVu = chucvu;
            nv.Ngaysinh = ngaysinh;

            var phoneNumber = Convert.ToString(sdt);
            var formattedPhoneNumber = string.Format("{0:(###) ###-####}", phoneNumber);
            var phoneNumberInt = Convert.ToInt32(formattedPhoneNumber);
            nv.Sdt = phoneNumberInt;

            nv.Email = email;
            nv.GioiTinh = gioitinh;

            dbc.TblNhanViens.Update(nv);
            dbc.SaveChanges();
            return Ok(new
            {
                nv
            });
        }

        [HttpPost]
        [Route("/NhanVien/Delete")]
        public IActionResult DeleteNhanVien(string NhanVienId)
        {
            TblNhanVien nv = dbc.TblNhanViens.Find(new Guid(NhanVienId));
            dbc.TblNhanViens.Remove(nv);
            dbc.SaveChanges();
            return Ok(new
            {
                nv
            });
        }
    }
}