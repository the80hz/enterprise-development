using Staff.Domain.Models;

namespace Staff.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями Address.
/// Реализует интерфейс IRepository для управления адресами.
/// </summary>
public class AddressRepository : IRepository<Address>
{
    private readonly List<Address> _addresses = new();

    /// <summary>
    /// Получает все адреса.
    /// </summary>
    public IEnumerable<Address> GetAll() => _addresses;

    /// <summary>
    /// Получает адрес по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор адреса.</param>
    public Address? GetById(int id) => _addresses.Find(a => a.AddressId == id);

    /// <summary>
    /// Добавляет новый адрес.
    /// </summary>
    /// <param name="entity">Новый адрес для добавления.</param>
    public Address? Post(Address entity)
    {
        _addresses.Add(entity);
        return entity;
    }

    /// <summary>
    /// Обновляет информацию об адресе.
    /// </summary>
    /// <param name="entity">Обновленные данные адреса.</param>
    public bool Put(Address entity)
    {
        var existingAddress = GetById(entity.AddressId);
        if (existingAddress == null)
            return false;

        existingAddress.Street = entity.Street;
        existingAddress.HouseNumber = entity.HouseNumber;
        existingAddress.City = entity.City;
        existingAddress.PostalCode = entity.PostalCode;
        existingAddress.Country = entity.Country;
        return true;
    }

    /// <summary>
    /// Удаляет адрес по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор адреса для удаления.</param>
    public bool Delete(int id)
    {
        var address = GetById(id);
        if (address == null)
            return false;

        _addresses.Remove(address);
        return true;
    }
}
