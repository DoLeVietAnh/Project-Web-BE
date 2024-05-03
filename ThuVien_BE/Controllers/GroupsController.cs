using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private ThuVien dbc;

        public GroupsController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/Groups/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblGroups.ToList()
            });
        }

        [HttpPost]
        [Route("/Groups/Insert")]
        public IActionResult InsertGroup(string ten, string ma)
        {
            TblGroup group = new TblGroup();
            group.GroupId = Guid.NewGuid();
            group.GroupTen = ten;
            group.GroupMa = ma;

            dbc.TblGroups.Add(group);
            dbc.SaveChanges();
            return Ok(new
            {
                group
            });
        }

        [HttpPost]
        [Route("/Groups/Update")]
        public IActionResult UpdateGroup(string id, string ten, string ma)
        {
            TblGroup group = new TblGroup();
            group.GroupId = new Guid(id);
            group.GroupTen = ten;
            group.GroupMa = ma;

            dbc.TblGroups.Update(group);
            dbc.SaveChanges();
            return Ok(new
            {
                group
            });
        }

        [HttpPost]
        [Route("/Groups/Delete")]
        public IActionResult DeleteGroup(string id)
        {
            TblGroup group = dbc.TblGroups.Find(new Guid(id));
            dbc.TblGroups.Remove(group);
            dbc.SaveChanges();
            return Ok(new
            {
                group
            });
        }
    }
}