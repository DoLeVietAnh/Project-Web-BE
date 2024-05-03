using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private ThuVien dbc;

        public MenuController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/Menu/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblMenus.ToList()
            });
        }

        [HttpPost]
        [Route("/Menu/Insert")]
        public IActionResult InsertMenu(string tenMenu, string view, string url, bool active, DateTime ngaytao, string nguoitao,
            string nguoitao_uid)
        {
            TblMenu menu = new TblMenu();
            menu.MenuId = Guid.NewGuid();
            menu.MenuTen = tenMenu;
            menu.MenuView = view;
            menu.MenuUrl = url;
            menu.Active = active;
            menu.Ngaytao = ngaytao;
            menu.Nguoitao = nguoitao;
            menu.NguoitaoUid = nguoitao_uid;

            dbc.TblMenus.Add(menu);
            dbc.SaveChanges();
            return Ok(new
            {
                menu
            });
        }

        [HttpPost]
        [Route("/Menu/Update")]
        public IActionResult UpdateMenu(string menuId, string tenMenu, string view, string url, bool active, DateTime ngaytao, string nguoitao,
                       string nguoitao_uid)
        {
            TblMenu menu = new TblMenu();
            menu.MenuId = new Guid(menuId);
            menu.MenuTen = tenMenu;
            menu.MenuView = view;
            menu.MenuUrl = url;
            menu.Active = active;
            menu.Ngaytao = ngaytao;
            menu.Nguoitao = nguoitao;
            menu.NguoitaoUid = nguoitao_uid;

            dbc.TblMenus.Update(menu);
            dbc.SaveChanges();
            return Ok(new
            {
                menu
            });
        }

        [HttpPost]
        [Route("/Menu/Delete")]
        public IActionResult DeleteMenu(string menuId)
        {
            TblMenu menu = dbc.TblMenus.Find(new Guid(menuId));
            dbc.TblMenus.Remove(menu);
            dbc.SaveChanges();
            return Ok(new
            {
                menu
            });
        }
    }
}