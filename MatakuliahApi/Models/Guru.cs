using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace MatakuliahApi.Models;

public class Guru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string Nama { get; set; } = null!;
    public string Kelas { get; set; } = null!;
    public string NIP { get; set; } = null!;

}