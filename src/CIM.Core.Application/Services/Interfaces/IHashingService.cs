namespace CIM.Core.Application.Services.Interfaces;

/// <summary>
/// Interface for a service that provides hashing functionality.
/// </summary>
public interface IHashingService
{
    /// <summary>
    /// Generates a random salt of the specified length.
    /// </summary>
    /// <param name="length">The length of the salt to generate. Defaults to 16.</param>
    /// <returns>A byte array representing the generated salt.</returns>
    byte[] GenerateSalt(int length = 16);

    /// <summary>
    /// Hashes the provided value using the provided salt.
    /// </summary>
    /// <param name="value">The value to hash.</param>
    /// <param name="salt">The salt to use in the hashing process.</param>
    /// <returns>A byte array representing the hashed value.</returns>
    byte[] HashWithSalt(byte[] value, byte[] salt);
}
