using Staff.Domain.Models;

namespace Staff.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями UnionBenefit.
/// Реализует интерфейс IRepository для управления льготными профсоюзными путевками.
/// </summary>
public class UnionBenefitRepository : IRepository<UnionBenefit>
{
    private readonly List<UnionBenefit> _unionBenefits = new();

    public IEnumerable<UnionBenefit> GetAll() => _unionBenefits;

    public UnionBenefit? GetById(int id) => _unionBenefits.Find(u => u.UnionBenefitId == id);

    public UnionBenefit? Post(UnionBenefit entity)
    {
        _unionBenefits.Add(entity);
        return entity;
    }

    public bool Put(UnionBenefit entity)
    {
        var existingBenefit = GetById(entity.UnionBenefitId);
        if (existingBenefit == null)
            return false;

        existingBenefit.BenefitType = entity.BenefitType;
        existingBenefit.DateReceived = entity.DateReceived;
        return true;
    }

    public bool Delete(int id)
    {
        var benefit = GetById(id);
        if (benefit == null)
            return false;

        _unionBenefits.Remove(benefit);
        return true;
    }
}
