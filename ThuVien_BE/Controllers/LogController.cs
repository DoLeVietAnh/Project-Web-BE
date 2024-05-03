using Microsoft.AspNetCore.Mvc;
using ThuVien_BE.ModelFromDB;

namespace ThuVien_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private ThuVien dbc;

        public LogController(ThuVien db)
        {
            dbc = db;
        }

        [HttpPost]
        [Route("/Log/List")]
        public IActionResult GetList()
        {
            return Ok(new
            {
                data = dbc.TblLogs.ToList()
            });
        }

        // Endpoint to log user actions
        [HttpPost("LogAction")]
        public IActionResult LogAction([FromBody] LogActionRequest request)
        {
            try
            {
                // Log the action
                var logEntry = new TblLog
                {
                    //LogId = Guid.NewGuid(),
                    UserId = request.UserId,
                    ThaoTac = request.Action,
                    Time = DateTime.UtcNow,
                    MayTinh = Environment.MachineName
                };
                dbc.TblLogs.Add(logEntry);
                dbc.SaveChanges();

                return Ok(new { message = "Action logged successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to log action", message = ex.Message });
            }
        }
    }

    // Request model for logging actions
    public class LogActionRequest
    {
        public Guid UserId { get; set; }
        public string Action { get; set; }
    }
}