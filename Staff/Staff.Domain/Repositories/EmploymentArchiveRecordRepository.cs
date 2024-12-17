using Staff.Domain.Models;

namespace Staff.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями EmploymentArchiveRecord.
/// Реализует интерфейс IRepository для управления записями архива трудовой деятельности.
/// </summary>
public class EmploymentArchiveRecordRepository : IRepository<EmploymentArchiveRecord>
{
    private readonly List<EmploymentArchiveRecord> _records = new();

    public IEnumerable<EmploymentArchiveRecord> GetAll() => _records;

    public EmploymentArchiveRecord? GetById(int id) => _records.Find(r => r.RecordId == id);

    public EmploymentArchiveRecord? Post(EmploymentArchiveRecord entity)
    {
        _records.Add(entity);
        return entity;
    }

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

    public bool Delete(int id)
    {
        var record = GetById(id);
        if (record == null)
            return false;

        _records.Remove(record);
        return true;
    }
}
