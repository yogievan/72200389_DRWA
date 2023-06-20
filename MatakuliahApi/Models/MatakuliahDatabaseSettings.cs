namespace BookStoreApi.Models;

public class MatakuliahDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string KelasCollectionName { get; set; } = null!;
    public string MapelCollectionName { get; set; } = null!;
    public string GuruCollectionName { get; set; } = null!;
    public string PresensiHarianGuruCollectionName { get; set; } = null!;
    public string PresensiMengajarCollectionName { get; set; } = null!;
}