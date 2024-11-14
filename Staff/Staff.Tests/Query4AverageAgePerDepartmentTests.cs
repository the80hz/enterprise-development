using System;
using System.Linq;
using Xunit;

namespace Staff.Tests
{
    public class Query4AverageAgePerDepartmentTests : IClassFixture<EmployeeTestDataFixture>
    {
        private readonly EmployeeTestDataFixture _fixture;

        public Query4AverageAgePerDepartmentTests(EmployeeTestDataFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void AverageAgePerDepartment_ShouldReturnCorrectAverages()
        {
            // Arrange
            var employees = _fixture.GetTestEmployees();
            var currentDate = DateTime.Now;

            // Act
            var result = employees
                .SelectMany(e => e.Departments, (e, d) => new { Employee = e, Department = d })
                .GroupBy(ed => ed.Department.Name)
                .Select(g => new
                {
                    Department = g.Key,
                    AverageAge = g.Average(ed => (currentDate - ed.Employee.DateOfBirth).TotalDays / 365.25)
                })
                .ToList();

            // Assert
            Assert.Equal(3, result.Count);

            // Проверка "Отдел продаж"
            var salesDept = result.FirstOrDefault(r => r.Department == "Отдел продаж");
            Assert.NotNull(salesDept);
            double expectedAgeSales = ((currentDate - new DateTime(1985, 5, 20)).TotalDays / 365.25 +
                                       (currentDate - new DateTime(1975, 11, 30)).TotalDays / 365.25) / 2;
            Assert.InRange(salesDept.AverageAge, expectedAgeSales - 1, expectedAgeSales + 1);

            // Проверка "Отдел разработки"
            var developmentDept = result.FirstOrDefault(r => r.Department == "Отдел разработки");
            Assert.NotNull(developmentDept);
            double expectedAgeDevelopment = ((currentDate - new DateTime(1990, 8, 12)).TotalDays / 365.25 +
                                             (currentDate - new DateTime(1975, 11, 30)).TotalDays / 365.25) / 2;
            Assert.InRange(developmentDept.AverageAge, expectedAgeDevelopment - 1, expectedAgeDevelopment + 1);

            // Проверка "Отдел кадров"
            var hrDept = result.FirstOrDefault(r => r.Department == "Отдел кадров");
            Assert.NotNull(hrDept);
            double expectedAgeHR = (currentDate - new DateTime(1990, 8, 12)).TotalDays / 365.25;
            Assert.InRange(hrDept.AverageAge, expectedAgeHR - 1, expectedAgeHR + 1);
        }
    }
}
