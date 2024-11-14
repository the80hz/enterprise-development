﻿using Staff.Domain.Enums;
using Staff.Domain.Models;

namespace Staff.Tests.Tests;

/// <summary>
/// Тесты для запроса 6: Вывод топ 5 сотрудников, имеющих наибольший стаж работы на предприятии.
/// </summary>
public class Query6_Top5EmployeesByTenureTests
{
    /// <summary>
    /// Создает тестовые данные.
    /// </summary>
    /// <returns>Список сотрудников.</returns>
    private List<Employee> GetTestEmployees()
    {
        // Создаем отделы
        var departmentSales = new Department { DepartmentId = 1, Name = "Отдел продаж" };
        var departmentDevelopment = new Department { DepartmentId = 2, Name = "Отдел разработки" };
        var departmentHR = new Department { DepartmentId = 3, Name = "Отдел кадров" };

        // Создаем цеха
        var workshop1 = new Workshop { WorkshopId = 1, Name = "Цех №1" };
        var workshop2 = new Workshop { WorkshopId = 2, Name = "Цех №2" };

        // Создаем должности
        var positionManager = new Position { PositionId = 1, Title = "Менеджер" };
        var positionDeveloper = new Position { PositionId = 2, Title = "Разработчик" };
        var positionHRSpecialist = new Position { PositionId = 3, Title = "HR-специалист" };

        // Создаем адреса
        var address1 = new Address
        {
            Street = "Ленина",
            HouseNumber = "10",
            City = "Москва",
            PostalCode = "101000",
            Country = "Россия"
        };

        var address2 = new Address
        {
            Street = "Пушкина",
            HouseNumber = "20",
            City = "Санкт-Петербург",
            PostalCode = "190000",
            Country = "Россия"
        };

        var address3 = new Address
        {
            Street = "Гагарина",
            HouseNumber = "5",
            City = "Новосибирск",
            PostalCode = "630000",
            Country = "Россия"
        };

        // Создаем сотрудников
        var employees = new List<Employee>
        {
            new Employee
            {
                RegistrationNumber = 1001,
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович",
                DateOfBirth = new DateTime(1985, 5, 20),
                Gender = Gender.Male,
                DateOfHire = new DateTime(2010, 3, 15),
                Departments = new List<Department> { departmentSales },
                Workshop = workshop1,
                Position = positionManager,
                Address = address1,
                WorkPhone = "123-45-67",
                HomePhone = "890-12-34",
                MaritalStatus = MaritalStatus.Married,
                FamilySize = 4,
                NumberOfChildren = 2,
                EmploymentArchive = new List<EmploymentArchiveRecord>
                {
                    new EmploymentArchiveRecord
                    {
                        StartDate = new DateTime(2010, 3, 15),
                        EndDate = null,
                        Position = positionManager
                    }
                },
                IsUnionMember = true,
                UnionBenefits = new List<UnionBenefit>
                {
                    new UnionBenefit
                    {
                        UnionBenefitId = 1,
                        BenefitType = BenefitType.SanatoriumVoucher,
                        DateReceived = DateTime.Now.AddMonths(-6)
                    }
                }
            },
            new Employee
            {
                RegistrationNumber = 1002,
                Surname = "Петрова",
                Name = "Мария",
                Patronymic = "Петровна",
                DateOfBirth = new DateTime(1990, 8, 12),
                Gender = Gender.Female,
                DateOfHire = new DateTime(2015, 7, 1),
                Departments = new List<Department> { departmentDevelopment, departmentHR },
                Workshop = workshop2,
                Position = positionDeveloper,
                Address = address2,
                WorkPhone = "234-56-78",
                HomePhone = "890-23-45",
                MaritalStatus = MaritalStatus.Single,
                FamilySize = 1,
                NumberOfChildren = 0,
                EmploymentArchive = new List<EmploymentArchiveRecord>
                {
                    new EmploymentArchiveRecord
                    {
                        StartDate = new DateTime(2015, 7, 1),
                        EndDate = null,
                        Position = positionDeveloper
                    }
                },
                IsUnionMember = false
            },
            new Employee
            {
                RegistrationNumber = 1003,
                Surname = "Сидоров",
                Name = "Алексей",
                Patronymic = "Сидорович",
                DateOfBirth = new DateTime(1975, 11, 30),
                Gender = Gender.Male,
                DateOfHire = new DateTime(2000, 1, 20),
                Departments = new List<Department> { departmentSales, departmentDevelopment },
                Workshop = workshop1,
                Position = positionHRSpecialist,
                Address = address3,
                WorkPhone = "345-67-89",
                HomePhone = "890-34-56",
                MaritalStatus = MaritalStatus.Divorced,
                FamilySize = 3,
                NumberOfChildren = 1,
                EmploymentArchive = new List<EmploymentArchiveRecord>
                {
                    new EmploymentArchiveRecord
                    {
                        StartDate = new DateTime(2000, 1, 20),
                        EndDate = new DateTime(2010, 3, 15),
                        Position = positionManager
                    },
                    new EmploymentArchiveRecord
                    {
                        StartDate = new DateTime(2010, 3, 16),
                        EndDate = null,
                        Position = positionHRSpecialist
                    }
                },
                IsUnionMember = true,
                UnionBenefits = new List<UnionBenefit>
                {
                    new UnionBenefit
                    {
                        UnionBenefitId = 2,
                        BenefitType = BenefitType.HolidayHomeVoucher,
                        DateReceived = DateTime.Now.AddMonths(-14) // Более года назад
                    },
                    new UnionBenefit
                    {
                        UnionBenefitId = 3,
                        BenefitType = BenefitType.PioneerCampVoucher,
                        DateReceived = DateTime.Now.AddMonths(-2)
                    }
                }
            }
        };

        return employees;
    }

    [Fact]
    public void Top5EmployeesByTenure_ShouldReturnCorrectOrder()
    {
        // Arrange
        var employees = GetTestEmployees();
        var currentDate = DateTime.Now;

        // Act
        var result = employees
            .Select(e => new
            {
                Employee = e,
                Tenure = (currentDate - e.DateOfHire).TotalDays
            })
            .OrderByDescending(e => e.Tenure)
            .Take(5)
            .Select(e => new
            {
                e.Employee.RegistrationNumber,
                FullName = $"{e.Employee.Surname} {e.Employee.Name} {e.Employee.Patronymic}",
                TenureYears = e.Tenure / 365.25
            })
            .ToList();

        // Assert
        Assert.Equal(3, result.Count); // У нас 3 сотрудника

        // Проверка порядка сотрудников по стажу
        Assert.Equal(1003, result[0].RegistrationNumber); // Сидоров (2000)
        Assert.Equal(1001, result[1].RegistrationNumber); // Иванов (2010)
        Assert.Equal(1002, result[2].RegistrationNumber); // Петрова (2015)
    }
}
