namespace Staff.Tests
{
    public class Query6Top5EmployeesByTenureTests : IClassFixture<EmployeeTestDataFixture>
    {
        private readonly EmployeeTestDataFixture _fixture;

        public Query6Top5EmployeesByTenureTests(EmployeeTestDataFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Top5EmployeesByTenure_ShouldReturnCorrectOrder()
        {
            // Arrange
            var employees = EmployeeTestDataFixture.GetTestEmployees();
            var currentDate = DateTime.Now;

            // Act
            var result = employees
                .Select(e => new
                {
                    e.RegistrationNumber,
                    FullName = $"{e.Surname} {e.Name} {e.Patronymic}",
                    TenureYears = (currentDate - e.DateOfHire).TotalDays / 365.25
                })
                .OrderByDescending(e => e.TenureYears)
                .Take(5)
                .ToList();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(1003, result[0].RegistrationNumber); // Сидоров
            Assert.Equal(1001, result[1].RegistrationNumber); // Иванов
            Assert.Equal(1002, result[2].RegistrationNumber); // Петрова
        }
    }
}
