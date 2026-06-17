
using ElearingEnglis.DataCon;
using Microsoft.EntityFrameworkCore;

namespace ElearingEnglis.services.Drug
{
    public class DrugRepo : IDrugRepo
    {
        private readonly DBCon _context;
        public DrugRepo(DBCon con)
        {
            _context = con;
        }

        public async Task<IQueryable<DataCon.Module.Drug>> GetDrugsAsync(string SearchTerm)
        {
            var drugs = _context.drugs.Where(d=>d.CommercialNameEn.Contains(SearchTerm));
            return drugs;
        }
    }
}
