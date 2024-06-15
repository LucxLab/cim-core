using CIM.Core.Application.Exceptions;

using MongoDB.Driver;

namespace CIM.Core.Infrastructure.Persistence.MongoDB.Interfaces;

public interface IMongoDbFactory
{
    /// <summary>
    /// Gets a collection from the database.
    /// </summary>
    /// <typeparam name="T">The type of the collection.</typeparam>
    /// <param name="databaseName">The name of the database to get the collection from. If not provided, the default database will be used.</param>
    /// <param name="collectionName">The name of the collection to get.</param>
    /// <returns>The collection from the database.</returns>
    /// <exception cref="InfrastructureException">Thrown when the database connection is not initialized.</exception>
    IMongoCollection<T> GetCollection<T>(string collectionName, string? databaseName = null);
    
    /// <summary>
    /// Drops the entire database.
    /// </summary>
    /// <param name="databaseName">The name of the database to drop. If not provided, the default database will be dropped.</param>
    /// <exception cref="InfrastructureException">Thrown when the database connection is not initialized.</exception>
    void DropDatabase(string? databaseName = null);
}
