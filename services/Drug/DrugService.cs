using ElearingEnglis.services.Drug.DTO;

namespace ElearingEnglis.services.Drug
{
    public class DrugService : IDrugService
    {
        private readonly IDrugRepo _repo;
        public DrugService(IDrugRepo repo)
        {
            _repo = repo;
        }
      public async Task<List<DrugDto>> GetDrugsAsync(string SearchTerm)
        {
           var drugs=await _repo.GetDrugsAsync(SearchTerm);
            var res = drugs.Select(d => new DrugDto { 
            Id = d.Id,
            Manufacturer = d.Manufacturer,
            CommercialNameAr=d.CommercialNameAr,
            DrugClass = d.DrugClass,
            CommercialNameEn=d.CommercialNameEn,
            PriceEgp=d.PriceEgp,
            ScientificName=d.ScientificName,
            Route=d.Route
            }).Take(100).ToList();
            return res;
        }
    }
}
