namespace Staff.Tests
{
    public class Query1EmployeesInSelectedDepartmentTests : IClassFixture<EmployeeTestDataFixture>
    {
        private readonly EmployeeTestDataFixture _fixture;

        public Query1EmployeesInSelectedDepartmentTests(EmployeeTestDataFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void EmployeesInSelectedDepartment_ShouldReturnCorrectEmployees()
        {
            // Arrange
            var employees = EmployeeTestDataFixture.GetTestEmployees();
            const string selectedDepartmentName = "Отдел продаж";

            // Act
            var result = employees
                .Where(e => e.Departments.Any(d => d.Name == selectedDepartmentName))
                .ToList();

            // Assert
            Assert.Equal(2, result.Count); // Иванов и Сидоров
            Assert.Contains(result, e => e.Surname == "Иванов");
            Assert.Contains(result, e => e.Surname == "Сидоров");
        }
    }
}
