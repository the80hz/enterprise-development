namespace Staff.Tests;

public class Query5EmployeesReceivedUnionBenefitsLastYearTests : IClassFixture<EmployeeTestDataFixture>
{
    [Fact]
    public void EmployeesReceivedUnionBenefitsLastYear_ShouldReturnCorrectEmployees()
    {
        // Arrange
        var employees = EmployeeTestDataFixture.GetTestEmployees();
        var lastYear = DateTime.Now.AddYears(-1);

        // Act
        var result = employees
            .Where(e => e.IsUnionMember &&
                        e.UnionBenefits.Any(b => b.DateReceived >= lastYear))
            .Select(e => new
            {
                e.RegistrationNumber,
                FullName = $"{e.Surname} {e.Name} {e.Patronymic}",
                Benefits = e.UnionBenefits
                    .Where(b => b.DateReceived >= lastYear)
                    .Select(b => b.BenefitType.ToString())
                    .ToList()
            })
            .ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, e => e.FullName == "Иванов Иван Иванович" && e.Benefits.Contains("SanatoriumVoucher"));
        Assert.Contains(result, e => e.FullName == "Сидоров Алексей Сидорович" && e.Benefits.Contains("PioneerCampVoucher"));
    }
}
