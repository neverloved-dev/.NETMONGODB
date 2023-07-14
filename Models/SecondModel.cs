using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoCrudTest.Models;

public class SecondModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string CarModel { get; set; } = null!;

    public int InStock { get; set; }
}