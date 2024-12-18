namespace Staff.WebAPI.Dto;

using Staff.Domain.Enums;

/// <summary>
/// DTO для передачи данных о сотруднике.
/// </summary>
public class EmployeeDto
{
    /// <summary>
    /// Регистрационный номер сотрудника.
    /// </summary>
    public int RegistrationNumber { get; set; }

    /// <summary>
    /// Фамилия сотрудника.
    /// </summary>
    public required string Surname { get; set; }

    /// <summary>
    /// Имя сотрудника.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Отчество сотрудника.
    /// </summary>
    public required string Patronymic { get; set; }

    /// <summary>
    /// Дата рождения.
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Пол сотрудника.
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Дата приема на работу.
    /// </summary>
    public DateTime DateOfHire { get; set; }

    /// <summary>
    /// Список отделов, в которых работает сотрудник.
    /// </summary>
    public List<DepartmentDto> Departments { get; set; } = [];

    /// <summary>
    /// Цех, в котором работает сотрудник.
    /// </summary>
    public required WorkshopDto Workshop { get; set; }

    /// <summary>
    /// Должность сотрудника.
    /// </summary>
    public required PositionDto Position { get; set; }

    /// <summary>
    /// Адрес проживания сотрудника.
    /// </summary>
    public required AddressDto Address { get; set; }

    /// <summary>
    /// Рабочий телефон.
    /// </summary>
    public required string WorkPhone { get; set; }

    /// <summary>
    /// Домашний телефон.
    /// </summary>
    public required string HomePhone { get; set; }

    /// <summary>
    /// Семейное положение.
    /// </summary>
    public MaritalStatus MaritalStatus { get; set; }

    /// <summary>
    /// Размер семьи.
    /// </summary>
    public int FamilySize { get; set; }

    /// <summary>
    /// Количество детей.
    /// </summary>
    public int NumberOfChildren { get; set; }

    /// <summary>
    /// История трудоустройства.
    /// </summary>
    public List<EmploymentArchiveRecordDto> EmploymentArchive { get; set; } = [];

    /// <summary>
    /// Признак членства в профсоюзе.
    /// </summary>
    public bool IsUnionMember { get; set; }

    /// <summary>
    /// Список полученных профсоюзных льгот.
    /// </summary>
    public List<UnionBenefitDto> UnionBenefits { get; set; } = [];
}