using AutoFixture;
using Customers_API.Controllers;
using Customers_API.Models;
using Customers_API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CustomersApi.UnitTests
{
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomersService> _mockCustomersService;
        private readonly Mock<ILogger<CustomersController>> _mockLogger;
        private readonly CustomersController _controller;
        private readonly IFixture _fixture;

        public CustomerControllerTests()
        {
            _mockLogger = new Mock<ILogger<CustomersController>>();
            _mockCustomersService= new Mock<ICustomersService>();
            _fixture = new Fixture();
            _controller = new CustomersController(_mockLogger.Object, _mockCustomersService.Object);
        }

        [Fact]
        public async void CreateCustomerAsync_ValidCustomerDetails_CreatesCustomer()
        {
            CreateCustomerRequest request = _fixture.Create<CreateCustomerRequest>();

            Customer expectedCustomer = _fixture.Build<Customer>()
                                        .With(x => x.FirstName, request.FirstName)
                                        .With(x => x.LastName, request.LastName)
                                        .With(x => x.BirthDate, request.BirthDate)
                                        .With(x => x.AnnualIncome, request.AnnualIncome)
                                        .Create();

            _mockCustomersService.Setup(x => x.CreateCustomerAsync(request)).ReturnsAsync(expectedCustomer);

            var result = await _controller.CreateCustomerAsync(request) as ObjectResult;

            result.StatusCode.Should().Be(201);
            result.Value.Should().BeEquivalentTo(expectedCustomer);
        }

        [Fact]
        public async void CreateCustomerAsync_InvalidCustomerDetails_CreatesCustomer()
        {
            CreateCustomerRequest request = _fixture.Create<CreateCustomerRequest>();

            _mockCustomersService.Setup(x => x.CreateCustomerAsync(request)).ThrowsAsync(new KeyNotFoundException());

            Func<Task> action = () => _controller.CreateCustomerAsync(request);

            await action.Should().ThrowAsync<KeyNotFoundException>();
        }
    }
}