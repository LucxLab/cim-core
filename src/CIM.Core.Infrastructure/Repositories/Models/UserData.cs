using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CIM.Core.Infrastructure.Repositories.Models;

/// <summary>
///     Represents a user in the infrastructure, mapped from/to the data persistence layer.
/// </summary>
public class UserData
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = default!;

    [BsonElement("email")]
    public string Email { get; set; } = default!;
}
