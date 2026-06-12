using ElearingEnglis.services.Appoinment.DTO;

namespace ElearingEnglis.services.Patient.DTO;

public class DTOPatien : DTOPatientCreat
{
    public Guid id {get; set;}
    public CreateAppoinmentDTO Appoinment {get; set;}
  
}
