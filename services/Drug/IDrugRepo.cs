using ElearingEnglis.DataCon.Module;

namespace ElearingEnglis.services.Drug
{
    public interface IDrugRepo
    {
        public Task<IQueryable<DataCon.Module.Drug>> GetDrugsAsync(string SearchTerm);
    }
}
