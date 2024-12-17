using Staff.Domain.Models;

namespace Staff.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями Workshop.
/// Реализует интерфейс IRepository для управления цехами.
/// </summary>
public class WorkshopRepository : IRepository<Workshop>
{
    private readonly List<Workshop> _workshops = new();

    public IEnumerable<Workshop> GetAll() => _workshops;

    public Workshop? GetById(int id) => _workshops.Find(w => w.WorkshopId == id);

    public Workshop? Post(Workshop entity)
    {
        _workshops.Add(entity);
        return entity;
    }

    public bool Put(Workshop entity)
    {
        var existingWorkshop = GetById(entity.WorkshopId);
        if (existingWorkshop == null)
            return false;

        existingWorkshop.Name = entity.Name;
        return true;
    }

    public bool Delete(int id)
    {
        var workshop = GetById(id);
        if (workshop == null)
            return false;

        _workshops.Remove(workshop);
        return true;
    }
}
