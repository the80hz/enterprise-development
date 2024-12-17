using Staff.Domain.Models;

namespace Staff.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями Position.
/// Реализует интерфейс IRepository для управления должностями.
/// </summary>
public class PositionRepository : IRepository<Position>
{
    private readonly List<Position> _positions = new();

    public IEnumerable<Position> GetAll() => _positions;

    public Position? GetById(int id) => _positions.Find(p => p.PositionId == id);

    public Position? Post(Position entity)
    {
        _positions.Add(entity);
        return entity;
    }

    public bool Put(Position entity)
    {
        var existingPosition = GetById(entity.PositionId);
        if (existingPosition == null)
            return false;

        existingPosition.Title = entity.Title;
        return true;
    }

    public bool Delete(int id)
    {
        var position = GetById(id);
        if (position == null)
            return false;

        _positions.Remove(position);
        return true;
    }
}
