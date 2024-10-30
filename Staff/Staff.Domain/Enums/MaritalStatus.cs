namespace Staff.Domain;

/// <summary>
/// Перечисление, представляющее семейное положение сотрудника.
/// </summary>
public enum MaritalStatus
{
    /// <summary>
    /// Холост/Не замужем.
    /// </summary>
    Single,

    /// <summary>
    /// Женат/Замужем.
    /// </summary>
    Married,

    /// <summary>
    /// Разведен/Разведена.
    /// </summary>
    Divorced,

    /// <summary>
    /// Вдовец/Вдова.
    /// </summary>
    Widowed
}
