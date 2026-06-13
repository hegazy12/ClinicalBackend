using ElearingEnglis.services.Drug.DTO;


 namespace ElearingEnglis.services.Drug
{
    public interface IDrugService
    {
        public Task<List<DrugDto>> GetDrugsAsync(string SearchTerm);
    }
}
