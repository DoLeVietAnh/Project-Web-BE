using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuonTraController : ControllerBase
    {
        private ThuVien dbc;

        public MuonTraController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/MuonTra/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblMuonTras.ToList()
            });
        }

        [HttpPost]
        [Route("/MuonTra/Insert")]
        public IActionResult InsertMuonTra(string MaSach, string MaKhach, DateTime NgayMuon, DateTime NgayTra, int datra, int soluong)
        {
            TblMuonTra muonTra = new TblMuonTra();
            TblKhach khach = new TblKhach();
            muonTra.MsId = Guid.NewGuid();
            muonTra.MsNgay = NgayMuon;
            muonTra.MsNgaytra = NgayTra;
            muonTra.MsDatra = datra;
            muonTra.MsSachSoluong = soluong;

            dbc.TblMuonTras.Add(muonTra);
            dbc.SaveChanges();
            return Ok(new
            {
                muonTra
            });
        }

        [HttpPost]
        [Route("/MuonTra/Update")]
        public IActionResult UpdateMuonTra(string MsId, string MaSach, string MaKhach, DateTime NgayMuon, DateTime NgayTra, int datra, int soluong)
        {
            TblMuonTra muonTra = new TblMuonTra();
            muonTra.MsId = new Guid(MsId);
            muonTra.MsNgay = NgayMuon;
            muonTra.MsNgaytra = NgayTra;
            muonTra.MsDatra = datra;
            muonTra.MsSachSoluong = soluong;

            dbc.TblMuonTras.Update(muonTra);
            dbc.SaveChanges();
            return Ok(new
            {
                muonTra
            });
        }

        [HttpPost]
        [Route("/MuonTra/Delete")]
        public IActionResult DeleteMuonTra(string MsId)
        {
            TblMuonTra muonTra = dbc.TblMuonTras.Find(new Guid(MsId));
            dbc.TblMuonTras.Remove(muonTra);
            dbc.SaveChanges();
            return Ok(new
            {
                muonTra
            });
        }
    }
}