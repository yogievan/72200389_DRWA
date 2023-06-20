using MatakuliahApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MatakuliahApi.Services;

public class PresensiMengajarService
{
    private readonly IMongoCollection<PresensiMengajar> _PresensiMengajarCollection;

    public PresensiMengajarService(
        IOptions<MatakuliahDatabaseSettings> MatakuliahDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            MatakuliahDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            MatakuliahDatabaseSettings.Value.DatabaseName);

        _PresensiMengajarCollection = mongoDatabase.GetCollection<Mapel>(
            MatakuliahDatabaseSettings.Value.PresensiMengajarCollectionName);
    }

    public async Task<List<PresensiMengajar>> GetAsync() =>
        await _PresensiMengajarCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiMengajar?> GetAsync(string id) =>
        await _PresensiMengajarCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiMengajar newPresensiMengajar) =>
        await _PresensiMengajarCollection.InsertOneAsync(newPresensiMengajar);

    public async Task UpdateAsync(string id, PresensiMengajar updatedPresensiMengajar) =>
        await _PresensiMengajarCollection.ReplaceOneAsync(x => x.Id == id, updatedPresensiMengajar);

    public async Task RemoveAsync(string id) =>
        await _PresensiMengajarCollection.DeleteOneAsync(x => x.Id == id);
}