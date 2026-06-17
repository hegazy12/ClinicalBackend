using ElearingEnglis.DataCon.Module;

namespace ElearingEnglis.services.VitalSignMaster
{
    public interface IVitalSignMasterRepo
    {
        Task<ElearingEnglis.DataCon.Module.VitalSignMaster> CreateVitalSignMasterAsync(Guid UserId,ElearingEnglis.DataCon.Module.VitalSignMaster vitalSignMaster);
    }
}
