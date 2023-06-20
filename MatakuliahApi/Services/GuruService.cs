using MatakuliahApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MatakuliahApi.Services;

public class GuruService
{
    private readonly IMongoCollection<Guru> _GuruCollection;

    public GuruService(
        IOptions<MatakuliahDatabaseSettings> MatakuliahDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            MatakuliahDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            MatakuliahDatabaseSettings.Value.DatabaseName);

        _GuruCollection = mongoDatabase.GetCollection<Mapel>(
            MatakuliahDatabaseSettings.Value.GuruCollectionName);
    }

    public async Task<List<Guru>> GetAsync() =>
        await _GuruCollection.Find(_ => true).ToListAsync();

    public async Task<Guru?> GetAsync(string id) =>
        await _GuruCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Guru newGuru) =>
        await _GuruCollection.InsertOneAsync(newGuru);

    public async Task UpdateAsync(string id, Guru updatedGuru) =>
        await _GuruCollection.ReplaceOneAsync(x => x.Id == id, updatedGuru);

    public async Task RemoveAsync(string id) =>
        await _GuruCollection.DeleteOneAsync(x => x.Id == id);
}