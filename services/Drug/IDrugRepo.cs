using ElearingEnglis.DataCon.Module;

namespace ElearingEnglis.services.Drug
{
    public interface IDrugRepo
    {
        public Task<List<ElearingEnglis.DataCon.Module.Drug>> GetDrugsAsync(string SearchTerm);
    }
}
