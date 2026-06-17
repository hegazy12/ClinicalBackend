using Microsoft.AspNetCore.Mvc;
using ElearingEnglis.services.Doctor;
using ElearingEnglis.services.Doctor.DTO;
using System.Security.Claims;
namespace ElearingEnglis.Controllers;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(Roles = "Admin,User")]
public class DoctorController : ControllerBase
{
    private readonly IDoctor _Doctor;
    public DoctorController(IDoctor doctor)
    {
        _Doctor = doctor;
    }

    [HttpGet]
    public List<DTODoctor> getDoctors()
    {
        return _Doctor.getDoctors();
    }

    [HttpPost]
    public bool CreateDoctor(CreateDoctorDTO create)
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        Guid userid = Guid.Parse(userIdStr);
        return _Doctor.CreateDoctor(userid,create);
    }
}
