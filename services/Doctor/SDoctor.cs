using ElearingEnglis.services.Doctor.DTO;
using ElearingEnglis.DataCon;
using Microsoft.EntityFrameworkCore;
using ElearingEnglis.DataCon.Module;


namespace ElearingEnglis.services.Doctor;

public class SDoctor : IDoctor
{
    private readonly DBCon _context;

    public SDoctor(DBCon context)
    {
        _context = context;
    }
    public List<DTODoctor> getDoctors()
    {
         var doctors =  _context.doctors.Include(m=>m.user).ToList();
         List<DTODoctor> dTO = new List<DTODoctor>();
         foreach ( var i in doctors)
         {
            dTO.Add(new DTODoctor(){firstName = i.fristName , lastName = i.lastName ,ID = i.Id.ToString()  ,specialization=i.specialization});
         }
         return dTO;
    }

    public bool CreateDoctor(Guid useid , CreateDoctorDTO dTO)
    {
        try
        {
            var user = _context.Users.Find(dTO.UserId);
            var x = new DataCon.Module.Doctor(){ user = user , fristName = dTO.firstName , lastName = dTO.lastName , specialization = dTO.specialization };
            x.Create(useid);
            _context.doctors.Add(x);
            _context.SaveChanges();
            return true;
        }
        catch 
        {
            return false;
        }
    }
}
