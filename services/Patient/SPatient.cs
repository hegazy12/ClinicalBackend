using ElearingEnglis.services.Patient.DTO;
using ElearingEnglis.DataCon;
namespace ElearingEnglis.services.Patient;

public class SPatient : IPatient
{
     private readonly DBCon _context;

    public SPatient(DBCon context)
    {
        _context = context;
    }
    public bool createPatient(Guid Userid , DTOPatientCreat creat)
    {
        try{
            var P = new DataCon.Module.Patient(){FristName = creat.FristName,LastName = creat.LastName , Phone = creat.Phone};
            P.Create(Userid);
            _context.patients.Add(P);
            _context.SaveChanges();
            
        }
        catch
        {
            return false;
        }
        return true;    
    } 

    public DTOPatien getPatient(Guid Patientid)
    {
        var x = _context.patients.Where(o=> o.Id == Patientid).First();
        return new DTOPatien(){FristName =x.FristName , LastName = x.LastName , Phone = x.Phone , id = x.Id};
    }

    public List<DTOPatien> GetDTOPatiens(int nuberpage)
    {
        try{
           var DTOs =  new List<DTOPatien>();
           var patients = _context.patients.OrderByDescending(o=>o.CreatedAt).Skip((nuberpage-1)*10).Take(15).ToList();
           
           foreach(var item in patients)
           {
                DTOs.Add(new DTOPatien () {FristName = item.FristName , LastName = item.LastName , Phone = item.Phone ,id = item.Id});    
           }
            return DTOs;
        }
        catch
        {
             return new List<DTOPatien>();
        } 
    }

    public List<DTOPatien> GetDTOPatiens(string shearch)
    {
        return new List<DTOPatien>(); 
    }
}
