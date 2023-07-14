using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoCrudTest.Models
{
    public class TestModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string PersonName { get; set; } = null!;

       public decimal? Score { get; set; }
    }
}
