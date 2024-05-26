using System.Security.Cryptography;

using CIM.Core.Application.Services.Interfaces;

namespace CIM.Core.Application.Services;

public class HashingService : IHashingService
{
    public byte[] GenerateSalt(int length = 16)
    {
        byte[] salt = new byte[length];
        using var rng = RandomNumberGenerator.Create();

        rng.GetBytes(salt);
        return salt;
    } 
    
    public byte[] HashWithSalt(byte[] password, byte[] salt)
    {
        byte[] combined = new byte[password.Length + salt.Length];

        Buffer.BlockCopy(password, 0, combined, 0, password.Length);
        Buffer.BlockCopy(salt, 0, combined, password.Length, salt.Length);
        return SHA256.HashData(combined);
    }
}
