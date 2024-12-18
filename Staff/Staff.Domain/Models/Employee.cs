using Staff.Domain.Enums;

namespace Staff.Domain.Models;

/// <summary>
/// Представляет сотрудника предприятия.
/// </summary>
public class Employee
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
    /// Дата рождения сотрудника.
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Пол сотрудника (мужской, женский, другой).
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Дата поступления на работу.
    /// </summary>
    public DateTime DateOfHire { get; set; }

    /// <summary>
    /// Отделы, в которых числится сотрудник.
    /// </summary>
    public List<Department> Departments { get; set; } = [];

    /// <summary>
    /// Идентификатор цеха, в котором работает сотрудник.
    /// </summary>
    public int WorkshopId { get; set; }

    /// <summary>
    /// Цех, в котором работает сотрудник.
    /// </summary>
    public required Workshop Workshop { get; set; }

    /// <summary>
    /// Идентификатор должности сотрудника.
    /// </summary>
    public int PositionId { get; set; }

    /// <summary>
    /// Должность, занимаемая сотрудником.
    /// </summary>
    public required Position Position { get; set; }

    /// <summary>
    /// Идентификатор домашнего адреса сотрудника.
    /// </summary>
    public int AddressId { get; set; }

    /// <summary>
    /// Домашний адрес сотрудника.
    /// </summary>
    public required Address Address { get; set; }

    /// <summary>
    /// Рабочий телефон сотрудника.
    /// </summary>
    public required string WorkPhone { get; set; }

    /// <summary>
    /// Домашний телефон сотрудника.
    /// </summary>
    public required string HomePhone { get; set; }

    /// <summary>
    /// Семейное положение сотрудника.
    /// </summary>
    public MaritalStatus MaritalStatus { get; set; }

    /// <summary>
    /// Общее число человек в семье сотрудника.
    /// </summary>
    public int FamilySize { get; set; }

    /// <summary>
    /// Число детей в семье сотрудника.
    /// </summary>
    public int NumberOfChildren { get; set; }

    /// <summary>
    /// Архив записей о трудовой деятельности сотрудника.
    /// </summary>
    public List<EmploymentArchiveRecord> EmploymentArchive { get; set; } = [];

    /// <summary>
    /// Признак членства в профсоюзе.
    /// </summary>
    public bool IsUnionMember { get; set; }

    /// <summary>
    /// Список льготных профсоюзных путевок, полученных сотрудником.
    /// </summary>
    public List<UnionBenefit> UnionBenefits { get; set; } = [];
}
