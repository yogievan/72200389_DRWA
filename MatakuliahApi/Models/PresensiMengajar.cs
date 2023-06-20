using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace MatakuliahApi.Models;

public class PresensiMengajar
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string NIP { get; set; } = null!;
    public string Tgl { get; set; } = null!;
    public string Kehadiran { get; set; } = null!;
    public string Kelas { get; set; } = null!;


}