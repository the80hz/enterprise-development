using Staff.Domain.Models;

namespace Staff.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями UnionBenefit.
/// Реализует интерфейс IRepository для управления льготными профсоюзными путевками.
/// </summary>
public class UnionBenefitRepository : IRepository<UnionBenefit>
{
    private readonly List<UnionBenefit> _unionBenefits = [];

    /// <summary>
    /// Получает все льготные профсоюзные путевки.
    /// </summary>
    public IEnumerable<UnionBenefit> GetAll() => _unionBenefits;

    /// <summary>
    /// Получает льготную путевку по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор путевки.</param>
    public UnionBenefit? GetById(int id) => _unionBenefits.Find(u => u.UnionBenefitId == id);

    /// <summary>
    /// Добавляет новую льготную путевку.
    /// </summary>
    /// <param name="entity">Новая путевка для добавления.</param>
    public UnionBenefit? Post(UnionBenefit entity)
    {
        _unionBenefits.Add(entity);
        return entity;
    }

    /// <summary>
    /// Обновляет информацию о льготной путевке.
    /// </summary>
    /// <param name="entity">Обновленные данные путевки.</param>
    public bool Put(UnionBenefit entity)
    {
        var existingBenefit = GetById(entity.UnionBenefitId);
        if (existingBenefit == null)
            return false;

        existingBenefit.BenefitType = entity.BenefitType;
        existingBenefit.DateReceived = entity.DateReceived;
        return true;
    }

    /// <summary>
    /// Удаляет льготную путевку по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор путевки для удаления.</param>
    public bool Delete(int id)
    {
        var benefit = GetById(id);
        if (benefit == null)
            return false;

        _unionBenefits.Remove(benefit);
        return true;
    }
}
