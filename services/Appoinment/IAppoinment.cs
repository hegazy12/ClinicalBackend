using ElearingEnglis.services.Appoinment.DTO;
using ElearingEnglis.DataCon.Module;
namespace ElearingEnglis.services.Appoinment;

public interface IAppoinment
{
   public Task<bool> Create(Guid Userid,CreateAppoinmentDTO dTO);
   public List<DTOAppoinment> GetPatientAppoinment(Guid idPatient);
}
