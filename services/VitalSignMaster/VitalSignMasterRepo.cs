
using ElearingEnglis.DataCon;

namespace ElearingEnglis.services.VitalSignMaster
{
    public class VitalSignMasterRepo : IVitalSignMasterRepo
    {
        private readonly DBCon _context;
        public VitalSignMasterRepo(DBCon context)
        {
            _context = context;
        }
        public async Task<DataCon.Module.VitalSignMaster> CreateVitalSignMasterAsync(Guid UserId,DataCon.Module.VitalSignMaster vitalSignMaster)
        {
            if(vitalSignMaster == null)
            {
                return null;
            }
            vitalSignMaster.Create(UserId);

            await _context.VitalSignMaster.AddAsync(vitalSignMaster);
           await _context.SaveChangesAsync();
            return vitalSignMaster;
        }
    }
}
