using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CIM.Core.Infrastructure.Repositories.Models;

/// <summary>
/// Represents a user, mapped from/to the data persistence layer.
/// </summary>
internal class UserData
{
    internal const string CollectionName = "users";

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = default!;

    [BsonElement("email")]
    public string Email { get; set; } = default!;
    
    [BsonElement("password")]
    public byte[] Password { get; set; } = default!;
    
    [BsonElement("salt")]
    public byte[] Salt { get; set; } = default!;
}
