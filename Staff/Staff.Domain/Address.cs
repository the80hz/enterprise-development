namespace Staff.Domain;

/// <summary>
/// Представляет адрес сотрудника.
/// </summary>
public class Address
{
    /// <summary>
    /// Улица.
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    /// Номер дома.
    /// </summary>
    public string HouseNumber { get; set; }

    /// <summary>
    /// Город.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Почтовый индекс.
    /// </summary>
    public string PostalCode { get; set; }

    /// <summary>
    /// Страна.
    /// </summary>
    public string Country { get; set; }
}
