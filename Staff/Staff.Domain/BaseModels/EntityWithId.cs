namespace Staff.Domain.BaseModels;

/// <summary>
/// Базовый класс для сущностей с идентификатором.
/// </summary>
public abstract class EntityWithId
{
    /// <summary>
    /// Уникальный идентификатор сущности.
    /// </summary>
    public int Id { get; set; }
}
