using MongoDB.Driver;

namespace CIM.Core.Infrastructure.Persistence.MongoDB;

/// <summary>
/// Settings for the MongoDB persistence layer.
/// </summary>
public class MongoDbSettings
{
    public const string SectionName = "MongoDB";
    /// <summary>
    /// The connection string to the MongoDB server.
    /// </summary>
    public string? ConnectionString { get; set; }

    /// <summary>
    /// The name of the database.
    /// </summary>
    public string? DatabaseName { get; set; }
}
