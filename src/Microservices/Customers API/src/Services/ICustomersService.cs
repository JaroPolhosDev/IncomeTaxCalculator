using Customers_API.Models;

namespace Customers_API.Services
{
    public interface ICustomersService
    {
        /// <summary>
        /// Get customer by the requested id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Customer</returns>
        public Task<Customer> GetCustomerByIdAsync(int id);

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="createCustomerRequest">Create Custommer Request</param>
        /// <returns>The created <see cref="Customer"/></returns>
        public Task<Customer> CreateCustomerAsync(CreateCustomerRequest createCustomerRequest);
    }
}
