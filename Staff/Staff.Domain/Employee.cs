namespace Staff.Domain;

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
    public string Surname { get; set; }

    /// <summary>
    /// Имя сотрудника.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Отчество сотрудника.
    /// </summary>
    public string Patronymic { get; set; }

    /// <summary>
    /// Дата рождения сотрудника.
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Пол сотрудника.
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Дата поступления на работу.
    /// </summary>
    public DateTime DateOfHire { get; set; }

    /// <summary>
    /// Список отделов, в которых числится сотрудник.
    /// </summary>
    public List<Department> Departments { get; set; } = new List<Department>();

    /// <summary>
    /// Цех, в котором работает сотрудник.
    /// </summary>
    public Workshop Workshop { get; set; }

    /// <summary>
    /// Занимаемая должность.
    /// </summary>
    public Position Position { get; set; }

    /// <summary>
    /// Домашний адрес сотрудника.
    /// </summary>
    public Address Address { get; set; }

    /// <summary>
    /// Рабочий телефон сотрудника.
    /// </summary>
    public string WorkPhone { get; set; }

    /// <summary>
    /// Домашний телефон сотрудника.
    /// </summary>
    public string HomePhone { get; set; }

    /// <summary>
    /// Семейное положение сотрудника.
    /// </summary>
    public MaritalStatus MaritalStatus { get; set; }

    /// <summary>
    /// Число человек в семье.
    /// </summary>
    public int FamilySize { get; set; }

    /// <summary>
    /// Число детей.
    /// </summary>
    public int NumberOfChildren { get; set; }

    /// <summary>
    /// Архив данных о трудовой деятельности сотрудника.
    /// </summary>
    public List<EmploymentArchiveRecord> EmploymentArchive { get; set; } = new List<EmploymentArchiveRecord>();

    /// <summary>
    /// Указывает, является ли сотрудник членом профсоюза.
    /// </summary>
    public bool IsUnionMember { get; set; }

    /// <summary>
    /// Список льготных профсоюзных путевок, полученных сотрудником.
    /// </summary>
    public List<UnionBenefit> UnionBenefits { get; set; } = new List<UnionBenefit>();
}
