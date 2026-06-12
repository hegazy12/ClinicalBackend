
using ElearingEnglis.services.Patient.DTO;
namespace ElearingEnglis.services.Patient;

public interface IPatient
{
   public bool createPatient(Guid Userid,DTOPatientCreat creat);
   public DTOPatien getPatient(Guid Patientid);
   public List<DTOPatien> GetDTOPatiens (int PageNuber);
   public List<DTOPatien> GetDTOPatiens(string shearch);
}