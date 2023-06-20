using MatakuliahApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MatakuliahApi.Services;

public class MapelService
{
    private readonly IMongoCollection<Mapel> _MapelCollection;

    public MapelService(
        IOptions<MatakuliahDatabaseSettings> MatakuliahDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            MatakuliahDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            MatakuliahDatabaseSettings.Value.DatabaseName);

        _MapelCollection = mongoDatabase.GetCollection<Mapel>(
            MatakuliahDatabaseSettings.Value.MapelCollectionName);
    }

    public async Task<List<Mapel>> GetAsync() =>
        await _MapelCollection.Find(_ => true).ToListAsync();

    public async Task<Mapel?> GetAsync(string id) =>
        await _MapelCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Mapel newMapel) =>
        await _MapelCollection.InsertOneAsync(newMapel);

    public async Task UpdateAsync(string id, Mapel updatedMapel) =>
        await _MapelCollection.ReplaceOneAsync(x => x.Id == id, updatedMapel);

    public async Task RemoveAsync(string id) =>
        await _MapelCollection.DeleteOneAsync(x => x.Id == id);
}