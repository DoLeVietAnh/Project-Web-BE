using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMenuController : ControllerBase
    {
        private ThuVien dbc;

        public GroupMenuController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/GroupMenu/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblGroupMenus.ToList()
            });
        }

        [HttpPost]
        [Route("/GroupMenu/Insert")]
        public IActionResult InsertGroupMenu(string groupid, string menuid, bool them, bool sua, bool xoa, bool xem, bool xuatFile, bool timkiem)
        {
            TblGroupMenu groupMenu = new TblGroupMenu();
            groupMenu.Id = Guid.NewGuid();
            groupMenu.MenuId = new Guid(menuid);
            groupMenu.GroupId = new Guid(groupid);
            groupMenu.Them = them;
            groupMenu.Sua = sua;
            groupMenu.Xoa = xoa;
            groupMenu.Xem = xem;
            groupMenu.XuatFile = xuatFile;
            groupMenu.TimKiem = timkiem;

            dbc.TblGroupMenus.Add(groupMenu);
            dbc.SaveChanges();
            return Ok(new
            {
                groupMenu
            });
        }

        [HttpPost]
        [Route("/GroupMenu/Update")]
        public IActionResult UpdateGroupMenu(string GM_id, string groupid, string menuid, bool them, bool sua, bool xoa, bool xem, bool xuatFile, bool timkiem)
        {
            TblGroupMenu groupMenu = new TblGroupMenu();
            groupMenu.Id = new Guid(GM_id);
            groupMenu.MenuId = new Guid(menuid);
            groupMenu.GroupId = new Guid(groupid);
            groupMenu.Them = them;
            groupMenu.Sua = sua;
            groupMenu.Xoa = xoa;
            groupMenu.Xem = xem;
            groupMenu.XuatFile = xuatFile;
            groupMenu.TimKiem = timkiem;

            dbc.TblGroupMenus.Add(groupMenu);
            dbc.SaveChanges();
            return Ok(new
            {
                groupMenu
            });
        }

        [HttpPost]
        [Route("/GroupMenu/Delete")]
        public IActionResult DeleteGroupMenu(string GM_id)
        {
            TblGroupMenu groupMenu = dbc.TblGroupMenus.Find(new Guid(GM_id));
            dbc.TblGroupMenus.Remove(groupMenu);
            dbc.SaveChanges();
            return Ok(new
            {
                groupMenu
            });
        }
    }
}