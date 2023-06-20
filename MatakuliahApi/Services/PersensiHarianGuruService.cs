using MatakuliahApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MatakuliahApi.Services;

public class PresensiHarianGuruService
{
    private readonly IMongoCollection<PresensiHarianGuru> _PresensiHarianGuruCollection;

    public PresensiHarianGuruService(
        IOptions<MatakuliahDatabaseSettings> MatakuliahDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            MatakuliahDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            MatakuliahDatabaseSettings.Value.DatabaseName);

        _PresensiHarianGuruCollection = mongoDatabase.GetCollection<Mapel>(
            MatakuliahDatabaseSettings.Value.PresensiHarianGuruCollectionName);
    }

    public async Task<List<PresensiHarianGuru>> GetAsync() =>
        await _PresensiHarianGuruCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiHarianGuru?> GetAsync(string id) =>
        await _PresensiHarianGuruCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiHarianGuru newPresensiHarianGuru) =>
        await _PresensiHarianGuruCollection.InsertOneAsync(newPresensiHarianGuru);

    public async Task UpdateAsync(string id, PresensiHarianGuru updatedPresensiHarianGuru) =>
        await _PresensiHarianGuruCollection.ReplaceOneAsync(x => x.Id == id, updatedPresensiHarianGuru);

    public async Task RemoveAsync(string id) =>
        await _PresensiHarianGuruCollection.DeleteOneAsync(x => x.Id == id);
}