using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachController : ControllerBase
    {
        private ThuVien dbc;

        public KhachController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/Khach/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblKhaches.ToList()
            });
        }

        [HttpPost]
        [Route("/Khach/Insert")]
        public IActionResult InsertKhach(string TenKhach, string HoKhach, int SDT, string Email, string DiaChi, string GioiTinh, string NgaySinh)
        {
            TblKhach khach = new TblKhach();
            khach.KhachId = Guid.NewGuid();
            khach.TenKhach = TenKhach;
            khach.HoKhach = HoKhach;

            //var phoneNumber = Convert.ToString(SDT);
            //var formattedPhoneNumber = string.Format("{0:(###) ###-####}", phoneNumber);
            //var phoneNumberInt = Convert.ToInt32(formattedPhoneNumber);
            khach.Sdt = SDT;

            khach.Email = Email;
            khach.DiaChi = DiaChi;
            khach.GioiTinh = GioiTinh;
            khach.Ngaysinh = NgaySinh;

            dbc.TblKhaches.Add(khach);
            dbc.SaveChanges();
            return Ok(new
            {
                khach
            });
        }

        [HttpPost]
        [Route("/Khach/Update")]
        public IActionResult UpdateKhach(string KhachId, string TenKhach, string HoKhach, int SDT, string Email, string DiaChi, string GioiTinh, string NgaySinh)
        {
            TblKhach khach = new TblKhach();
            khach.KhachId = new Guid(KhachId);
            khach.TenKhach = TenKhach;
            khach.HoKhach = HoKhach;

            //var phoneNumber = Convert.ToString(SDT);
            //var formattedPhoneNumber = string.Format("{0:(###) ###-####}", phoneNumber);
            //var phoneNumberInt = Convert.ToInt32(formattedPhoneNumber);
            khach.Sdt = SDT;

            khach.Email = Email;
            khach.DiaChi = DiaChi;
            khach.GioiTinh = GioiTinh;
            khach.Ngaysinh = NgaySinh;

            dbc.TblKhaches.Update(khach);
            dbc.SaveChanges();
            return Ok(new
            {
                khach
            });
        }

        [HttpPost]
        [Route("/Khach/Delete")]
        public IActionResult DeleteKhach(string KhachId)
        {
            TblKhach khach = dbc.TblKhaches.Find(new Guid(KhachId));
            dbc.TblKhaches.Remove(khach);
            dbc.SaveChanges();
            return Ok(new
            {
                khach
            });
        }
    }
}