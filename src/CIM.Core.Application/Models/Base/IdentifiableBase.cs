namespace CIM.Core.Application.Models.Base;

/// <summary>
/// Base class for all identifiable entities in the application.
/// </summary>
public class IdentifiableBase
{
    protected IdentifiableBase(string? id)
    {
        Id = id ?? default!;
    }

    /// <summary>
    /// Unique identifier for the user.
    /// </summary>
    public string Id { get; }
}
