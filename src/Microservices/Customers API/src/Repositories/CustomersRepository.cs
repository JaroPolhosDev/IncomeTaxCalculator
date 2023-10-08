using Customers_API.DataSource;
using Customers_API.Models;

namespace Customers_API.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly ICustomersDataSource _customersDataSource;

        /// <summary>
        /// Creates a new instance of <see cref="CustomersRepository"/>
        /// </summary>
        /// <param name="customersDataSource">Customers DataSource</param>
        public CustomersRepository(ICustomersDataSource customersDataSource)
        {
            _customersDataSource = customersDataSource;
        }

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="createCustomerRequest">Create Custommer Request</param>
        /// <returns>The created <see cref="Customer"/></returns>
        public async Task<Customer> CreateCustomerAsync(CreateCustomerRequest createCustomerRequest) => await _customersDataSource.CreateCustomerAsync(createCustomerRequest);

        /// <summary>
        /// Get customer by the requested id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Customer</returns>
        public async Task<Customer> GetCustomerByIdAsync(int id) => await _customersDataSource.GetCustomerByIdAsync(id);
    }
}
