using Microsoft.AspNetCore.Mvc;

namespace ElearingEnglis.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DataController : ControllerBase
{
    [HttpGet]
    public IActionResult GetSystemStatus()
    {
        return Ok(new { 
            Status = "Active", 
            Runtime = ".NET 10.0", 
            Engine = "Optimized",
            Timestamp = DateTime.UtcNow 
        });
    }
}
