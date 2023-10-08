using Customers_API.Models;

namespace Customers_API.Repositories
{
    public interface ICustomersRepository
    {

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="createCustomerRequest">Create Custommer Request</param>
        /// <returns>The created <see cref="Customer"/></returns>
        public Task<Customer> CreateCustomerAsync(CreateCustomerRequest createCustomerRequest);

        /// <summary>
        /// Get customer by the requested id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Customer</returns>
        public Task<Customer> GetCustomerByIdAsync(int id);
    }
}
