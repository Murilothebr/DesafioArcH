using MongoDB;
using MongoDB.Bson.Serialization.Attributes;

namespace TransacaoAPI.Entity;
public class Transaction
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string ID { get; set; }

    [BsonElement("Value")]
    public long Value { get ; set;}
}

