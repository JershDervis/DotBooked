using DotBooked.Application.Features.Customers.Queries.GetCustomers;
using DotBooked.Application.IntegrationTests.TestHelpers;

namespace DotBooked.Application.IntegrationTests.Features.Customers;

public class GetCustomersQueryTests : IntegrationTestBase
{
    [Fact]
    public async Task GetCustomers_WithDefaults_ReturnData()
    {
        // Act
        var customers = await Mediator.Send(new GetCustomersQuery());

        // Assert
    }

    public GetCustomersQueryTests(TestingDatabaseFixture fixture) : base(fixture)
    {
    }
}