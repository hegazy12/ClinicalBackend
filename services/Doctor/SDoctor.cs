using ElearingEnglis.services.Doctor.DTO;
using ElearingEnglis.DataCon;
using Microsoft.EntityFrameworkCore;


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
            dTO.Add(new DTODoctor(){firstName = i.fristName , lastName = i.lastName ,ID = i.user.Id  ,specialization=i.specialization});
         }
         return dTO;

    }
}
