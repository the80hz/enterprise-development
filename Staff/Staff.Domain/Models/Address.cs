namespace Staff.Domain.Models;

/// <summary>
/// Представляет адрес сотрудника.
/// </summary>
public class Address
{
    /// <summary>
    /// Идентификатор адреса.
    /// </summary>
    public int AddressId { get; set; }

    /// <summary>
    /// Улица.
    /// </summary>
    public required string Street { get; set; }

    /// <summary>
    /// Номер дома.
    /// </summary>
    public required string HouseNumber { get; set; }

    /// <summary>
    /// Город.
    /// </summary>
    public required string City { get; set; }

    /// <summary>
    /// Почтовый индекс.
    /// </summary>
    public required string PostalCode { get; set; }

    /// <summary>
    /// Страна.
    /// </summary>
    public required string Country { get; set; }
}
