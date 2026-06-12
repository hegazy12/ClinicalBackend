using Microsoft.AspNetCore.Mvc;
using ElearingEnglis.services.Doctor;
using ElearingEnglis.services.Doctor.DTO;
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
}
