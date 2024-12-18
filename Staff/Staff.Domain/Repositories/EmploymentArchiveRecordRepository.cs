using Staff.Domain.Models;

namespace Staff.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями EmploymentArchiveRecord.
/// Реализует интерфейс IRepository для управления записями архива трудовой деятельности.
/// </summary>
public class EmploymentArchiveRecordRepository : IRepository<EmploymentArchiveRecord>
{
    private readonly List<EmploymentArchiveRecord> _records = [];

    /// <summary>
    /// Получает все записи архива трудовой деятельности.
    /// </summary>
    public IEnumerable<EmploymentArchiveRecord> GetAll() => _records;

    /// <summary>
    /// Получает запись архива по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор записи.</param>
    public EmploymentArchiveRecord? GetById(int id) => _records.Find(r => r.RecordId == id);

    /// <summary>
    /// Добавляет новую запись в архив трудовой деятельности.
    /// </summary>
    /// <param name="entity">Новая запись для добавления.</param>
    public EmploymentArchiveRecord? Post(EmploymentArchiveRecord entity)
    {
        _records.Add(entity);
        return entity;
    }

    /// <summary>
    /// Обновляет существующую запись в архиве трудовой деятельности.
    /// </summary>
    /// <param name="entity">Обновленная запись.</param>
    public bool Put(EmploymentArchiveRecord entity)
    {
        var existingRecord = GetById(entity.RecordId);
        if (existingRecord == null)
            return false;

        existingRecord.StartDate = entity.StartDate;
        existingRecord.EndDate = entity.EndDate;
        existingRecord.Position = entity.Position;
        return true;
    }

    /// <summary>
    /// Удаляет запись из архива трудовой деятельности по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор записи для удаления.</param>
    public bool Delete(int id)
    {
        var record = GetById(id);
        if (record == null)
            return false;

        _records.Remove(record);
        return true;
    }
}
