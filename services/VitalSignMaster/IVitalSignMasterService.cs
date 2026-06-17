using ElearingEnglis.services.Response;
using ElearingEnglis.services.VitalSignMaster.DTOs;

namespace ElearingEnglis.services.VitalSignMaster
{
    public interface IVitalSignMasterService
    {
        Task<GeneralResponse<VitalSignMasterDto>> CreateVitalSignMasterAsync(Guid UserId,CreateVitalSignMasterDto vitalSignMasterDto);

    }
}
