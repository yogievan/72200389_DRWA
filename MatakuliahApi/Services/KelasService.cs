using MatakuliahApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MatakuliahApi.Services;

public class KelasService
{
    private readonly IMongoCollection<Kelas> _kelasCollection;

    public KelasService(
        IOptions<MatakuliahDatabaseSettings> MatakuliahDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            MatakuliahDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            MatakuliahDatabaseSettings.Value.DatabaseName);

        _kelasCollection = mongoDatabase.GetCollection<Kelas>(
            MatakuliahDatabaseSettings.Value.KelasCollectionName);
    }

    public async Task<List<Kelas>> GetAsync() =>
        await _kelasCollection.Find(_ => true).ToListAsync();

    public async Task<Kelas?> GetAsync(string id) =>
        await _kelasCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Kelas newKelas) =>
        await _kelasCollection.InsertOneAsync(newKelas);

    public async Task UpdateAsync(string id, Kelas updatedKelas) =>
        await _kelasCollection.ReplaceOneAsync(x => x.Id == id, updatedKelas);

    public async Task RemoveAsync(string id) =>
        await _kelasCollection.DeleteOneAsync(x => x.Id == id);
}