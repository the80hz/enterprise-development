namespace Staff.Tests
{
    public class Query3ArchiveOfDismissalsTests : IClassFixture<EmployeeTestDataFixture>
    {
        [Fact]
        public void ArchiveOfDismissals_ShouldReturnCorrectRecords()
        {
            // Arrange
            var employees = EmployeeTestDataFixture.GetTestEmployees();

            // Act
            var result = employees
                .SelectMany(e => e.EmploymentArchive
                    .Where(a => a.EndDate != null)
                    .Select(a => new
                    {
                        e.RegistrationNumber,
                        FullName = $"{e.Surname} {e.Name} {e.Patronymic}",
                        e.DateOfBirth,
                        WorkshopName = e.Workshop.Name,
                        Departments = string.Join(", ", e.Departments.Select(d => d.Name)),
                        Position = a.Position.Title
                    }))
                .ToList();

            // Assert
            Assert.Single(result);
            var dismissal = result.First();
            Assert.Equal(1003, dismissal.RegistrationNumber);
            Assert.Equal("Сидоров Алексей Сидорович", dismissal.FullName);
            Assert.Equal("Цех №1", dismissal.WorkshopName);
            Assert.Contains("Отдел продаж", dismissal.Departments);
            Assert.Contains("Отдел разработки", dismissal.Departments);
            Assert.Equal("Менеджер", dismissal.Position);
        }
    }
}
