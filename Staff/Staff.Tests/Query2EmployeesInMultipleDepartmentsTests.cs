namespace Staff.Tests
{
    public class Query2EmployeesInMultipleDepartmentsTests : IClassFixture<EmployeeTestDataFixture>
    {
        private readonly EmployeeTestDataFixture _fixture;

        public Query2EmployeesInMultipleDepartmentsTests(EmployeeTestDataFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void EmployeesInMultipleDepartments_ShouldBeOrderedByFullName()
        {
            // Arrange
            var employees = _fixture.GetTestEmployees();

            // Act
            var result = employees
                .Where(e => e.Departments.Count > 1)
                .OrderBy(e => e.Surname)
                .ThenBy(e => e.Name)
                .ThenBy(e => e.Patronymic)
                .ToList();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Петрова", result[0].Surname);
            Assert.Equal("Сидоров", result[1].Surname);
        }
    }
}
