using Staff.Domain.Models;

namespace Staff.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями Position.
/// Реализует интерфейс IRepository для управления должностями.
/// </summary>
public class PositionRepository : IRepository<Position>
{
    private readonly List<Position> _positions = new();

    /// <summary>
    /// Получает все должности.
    /// </summary>
    public IEnumerable<Position> GetAll() => _positions;

    /// <summary>
    /// Получает должность по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор должности.</param>
    public Position? GetById(int id) => _positions.Find(p => p.PositionId == id);

    /// <summary>
    /// Добавляет новую должность.
    /// </summary>
    /// <param name="entity">Новая должность для добавления.</param>
    public Position? Post(Position entity)
    {
        _positions.Add(entity);
        return entity;
    }

    /// <summary>
    /// Обновляет информацию о должности.
    /// </summary>
    /// <param name="entity">Обновленные данные должности.</param>
    public bool Put(Position entity)
    {
        var existingPosition = GetById(entity.PositionId);
        if (existingPosition == null)
            return false;

        existingPosition.Title = entity.Title;
        return true;
    }

    /// <summary>
    /// Удаляет должность по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор должности для удаления.</param>
    public bool Delete(int id)
    {
        var position = GetById(id);
        if (position == null)
            return false;

        _positions.Remove(position);
        return true;
    }
}
