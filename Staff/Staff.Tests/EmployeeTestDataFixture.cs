using Staff.Domain.Models;
using Staff.Domain.Enums;

namespace Staff.Tests
{
    public class EmployeeTestDataFixture
    {
        public static List<Employee> GetTestEmployees()
        {
            // Создание отделов
            var departmentSales = new Department { DepartmentId = 1, Name = "Отдел продаж" };
            var departmentDevelopment = new Department { DepartmentId = 2, Name = "Отдел разработки" };
            var departmentHr = new Department { DepartmentId = 3, Name = "Отдел кадров" };

            // Создание цехов
            var workshop1 = new Workshop { WorkshopId = 1, Name = "Цех №1" };
            var workshop2 = new Workshop { WorkshopId = 2, Name = "Цех №2" };

            // Создание должностей
            var positionManager = new Position { PositionId = 1, Title = "Менеджер" };
            var positionDeveloper = new Position { PositionId = 2, Title = "Разработчик" };
            var positionHrSpecialist = new Position { PositionId = 3, Title = "HR-специалист" };

            // Создание адресов
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

            // Создание сотрудников
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
                    Departments = [departmentSales],
                    Workshop = workshop1,
                    Position = positionManager,
                    Address = address1,
                    WorkPhone = "123-45-67",
                    HomePhone = "890-12-34",
                    MaritalStatus = MaritalStatus.Married,
                    FamilySize = 4,
                    NumberOfChildren = 2,
                    EmploymentArchive =
                    [
                        new EmploymentArchiveRecord
                        {
                            StartDate = new DateTime(2010, 3, 15),
                            EndDate = null,
                            Position = positionManager
                        }
                    ],
                    IsUnionMember = true,
                    UnionBenefits =
                    [
                        new UnionBenefit
                        {
                            UnionBenefitId = 1,
                            BenefitType = BenefitType.SanatoriumVoucher,
                            DateReceived = DateTime.Now.AddMonths(-6)
                        }
                    ]
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
                    Departments = [departmentDevelopment, departmentHr],
                    Workshop = workshop2,
                    Position = positionDeveloper,
                    Address = address2,
                    WorkPhone = "234-56-78",
                    HomePhone = "890-23-45",
                    MaritalStatus = MaritalStatus.Single,
                    FamilySize = 1,
                    NumberOfChildren = 0,
                    EmploymentArchive =
                    [
                        new EmploymentArchiveRecord
                        {
                            StartDate = new DateTime(2015, 7, 1),
                            EndDate = null,
                            Position = positionDeveloper
                        }
                    ],
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
                    Departments = [departmentSales, departmentDevelopment],
                    Workshop = workshop1,
                    Position = positionHrSpecialist,
                    Address = address3,
                    WorkPhone = "345-67-89",
                    HomePhone = "890-34-56",
                    MaritalStatus = MaritalStatus.Divorced,
                    FamilySize = 3,
                    NumberOfChildren = 1,
                    EmploymentArchive =
                    [
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
                            Position = positionHrSpecialist
                        }
                    ],
                    IsUnionMember = true,
                    UnionBenefits =
                    [
                        new UnionBenefit
                        {
                            UnionBenefitId = 2,
                            BenefitType = BenefitType.HolidayHomeVoucher,
                            DateReceived = DateTime.Now.AddMonths(-14)
                        },
                        new UnionBenefit
                        {
                            UnionBenefitId = 3,
                            BenefitType = BenefitType.PioneerCampVoucher,
                            DateReceived = DateTime.Now.AddMonths(-2)
                        }
                    ]
                }
            };

            return employees;
        }
    }
}
