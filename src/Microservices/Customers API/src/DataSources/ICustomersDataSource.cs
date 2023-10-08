using Customers_API.Models;

namespace Customers_API.DataSource
{
    public interface ICustomersDataSource
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
        /// <param name="customerId">Customer Id</param>
        /// <returns>Customer</returns>
        public Task<Customer> GetCustomerByIdAsync(int customerId);
    }
}
