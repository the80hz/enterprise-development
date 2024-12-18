using Staff.Domain.Models;

namespace Staff.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями Workshop.
/// Реализует интерфейс IRepository для управления цехами.
/// </summary>
public class WorkshopRepository : IRepository<Workshop>
{
    private readonly List<Workshop> _workshops = new();

    /// <summary>
    /// Получает все цехи.
    /// </summary>
    public IEnumerable<Workshop> GetAll() => _workshops;

    /// <summary>
    /// Получает цех по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор цеха.</param>
    public Workshop? GetById(int id) => _workshops.Find(w => w.WorkshopId == id);

    /// <summary>
    /// Добавляет новый цех.
    /// </summary>
    /// <param name="entity">Новый цех для добавления.</param>
    public Workshop? Post(Workshop entity)
    {
        _workshops.Add(entity);
        return entity;
    }

    /// <summary>
    /// Обновляет информацию о цехе.
    /// </summary>
    /// <param name="entity">Обновленные данные цеха.</param>
    public bool Put(Workshop entity)
    {
        var existingWorkshop = GetById(entity.WorkshopId);
        if (existingWorkshop == null)
            return false;

        existingWorkshop.Name = entity.Name;
        return true;
    }

    /// <summary>
    /// Удаляет цех по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор цеха для удаления.</param>
    public bool Delete(int id)
    {
        var workshop = GetById(id);
        if (workshop == null)
            return false;

        _workshops.Remove(workshop);
        return true;
    }
}
