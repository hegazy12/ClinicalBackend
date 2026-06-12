using ElearingEnglis.DataCon.Module;
using ElearingEnglis.DataCon;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;


namespace ElearingEnglis.services.Drug
{
    public class DrugImportService : IDrugImportService
    {
        private readonly DBCon _context;

        public DrugImportService(DBCon context)
        {
            _context = context;
        }

        public async Task<int> ImportFromJsonAsync(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            var json = await File.ReadAllTextAsync(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var drugs = JsonSerializer.Deserialize<List<DataCon.Module.Drug>>(json, options);

            if (drugs == null || drugs.Count == 0)
                return 0;

            var existingNames = await _context.drugs
                .Select(d => d.CommercialNameEn)
                .ToListAsync();

            var existingSet = existingNames
                .Where(x => x != null)
                .Select(x => x.ToLower())
                .ToHashSet();

            var newDrugs = new List<DataCon.Module.Drug>();

            foreach (var drug in drugs)
            {
                if (string.IsNullOrWhiteSpace(drug.CommercialNameEn))
                    continue;

                var name = drug.CommercialNameEn.Trim();

                if (existingSet.Contains(name.ToLower()))
                    continue;
                drug.CommercialNameEn = name;
                drug.CommercialNameAr = drug.CommercialNameAr?.Trim();
                drug.ScientificName = drug.ScientificName?.Trim();
                drug.Manufacturer = drug.Manufacturer?.Trim();
                drug.DrugClass = drug.DrugClass?.Trim();
                drug.Route = drug.Route?.Trim();
                if (drug.Id == Guid.Empty)
                    drug.Id = Guid.NewGuid();

                newDrugs.Add(drug);
            }

            if (newDrugs.Count == 0)
                return 0;

            await _context.drugs.AddRangeAsync(newDrugs);
            await _context.SaveChangesAsync();

            return newDrugs.Count;
        }
    }
}
