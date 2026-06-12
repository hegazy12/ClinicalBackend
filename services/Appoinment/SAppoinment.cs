using ElearingEnglis.services.Appoinment.DTO;
using ElearingEnglis.DataCon.Module;
using ElearingEnglis.DataCon;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ElearingEnglis.services.Doctor.DTO;
namespace ElearingEnglis.services.Appoinment;
public class SAppoinment:IAppoinment
{

    private readonly DBCon _context;
    private readonly UserManager<IdentityUser>  _userManager;
    public SAppoinment(DBCon context,UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
 public async Task<bool> Create(Guid Userid , CreateAppoinmentDTO dTO)
  {
    var Doctor = _context.doctors.Find(dTO.DoctorId.ToString());
    var P      = _context.patients.Where(m=> m.Id == dTO.PatientId).FirstOrDefault();
    try {
            Appointment _appointment = new Appointment()
            {
              AppointmentDate = dTO.DateTimeAppoinment,
              Deposit=dTO.Deposit,
              Doctor= Doctor,
              Patient = P ,
              Notes = dTO.note
            };
            
            Console.WriteLine(dTO.DateTimeAppoinment);
            Console.WriteLine(_appointment.AppointmentDate);

            _appointment.Create(Userid);
            _context.appointments.Add(_appointment);
            _context.SaveChanges();
    }catch
    {
        return false;        
    }

    return true;
  }

public List<DTOAppoinment> GetPatientAppoinment(Guid idPatient)
{
    var patient = _context.patients.Find(idPatient);
    
    var Appoinments = _context.appointments.Where(m => m.Patient == patient).Include(m=> m.Doctor).ToList();
    
    List<DTOAppoinment> Result = new List<DTOAppoinment>();
    
    DataCon.Module.Doctor D = null;
    
    foreach (var i in Appoinments)
    {
      D = _context.doctors.Where(m=> m.Id == i.Doctor.Id).First();
      
      Result.Add(new DTOAppoinment (){
        AppoinmentDate = DateOnly.FromDateTime(i.AppointmentDate) ,
        Deposit = i.Deposit , 
        Doctor = new DTODoctor(){firstName = D.fristName , lastName = D.lastName , specialization =  D.specialization , ID = D.Id.ToString()},
        note = i.Notes,
        Id =i.Id
        });
    }
    return Result;
}
}
