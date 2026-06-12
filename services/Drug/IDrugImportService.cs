namespace ElearingEnglis.services.Drug
{
    public interface IDrugImportService
    {
        Task<int> ImportFromJsonAsync(string filePath);
    }
}
