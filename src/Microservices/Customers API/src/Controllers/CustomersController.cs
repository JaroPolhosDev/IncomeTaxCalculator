using Customers_API.Models;
using Customers_API.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Customers_API.Controllers
{
    /// <summary>
    /// Customers controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICustomersService _customersService;

        /// <summary>
        /// Create a new <see cref="CustomersController"/> instance
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="customersService">Customers Service</param>
        public CustomersController(ILogger<CustomersController> logger, ICustomersService customersService)
        {
            _logger = logger;
            _customersService = customersService;
        }

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="createCustomerRequest">Create Custommer Request</param>
        /// <returns>The created <see cref="Customer"/></returns>
        [HttpPost(Name = Routes.CreateCustomer)]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            _logger.LogInformation("Creating a new customer", createCustomerRequest);

            try
            {
                Customer customer = await _customersService.CreateCustomerAsync(createCustomerRequest);
                _logger.LogInformation($"Customer created: {customer.Id}");
                return this.CreatedAtRoute(Routes.CreateCustomer, customer);
            }
            catch(ValidationException e)
            {
                _logger.LogWarning($"Failed to create a new customer {createCustomerRequest}");
                return this.BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get a customer by the given id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>The customer entity</returns>
        [HttpGet("{customerId}", Name = Routes.GetById)]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomerByIdAsync(int customerId)
        {
            _logger.LogInformation($"Loading customer details with id: {customerId}");

            try
            {
                Customer result = await _customersService.GetCustomerByIdAsync(customerId);
                return this.Ok(result);
            }
            catch(KeyNotFoundException e )
            {
                _logger.LogWarning($"Couldn't find a customer with id: {customerId}", e.Message);
                return this.NotFound();
            }
        }
    }

    /// <summary>
    /// Routes class
    /// </summary>
    public static class Routes
    {
        /// <summary>
        /// GET "api/customers/1"
        /// </summary>
        public const string GetById = "Customers.GetById";

        /// <summary>
        /// POST "api/customers"
        /// </summary>
        public const string CreateCustomer = "Customers.CreateCustomer";
    }
}