namespace CIM.Core.Application.Models.Base;

/// <summary>
/// Base class for all identifiable entities in the application.
/// </summary>
public class IdentifiableBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IdentifiableBase"/> class, with a default identifier.
    /// </summary>
    protected IdentifiableBase()
    {
        Id = default!;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IdentifiableBase"/> class, with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier for the entity.</param>
    protected IdentifiableBase(string id)
    {
        Id = id;
    }

    /// <summary>
    /// Unique identifier for an entity.
    /// </summary>
    public string Id { get; }
}
