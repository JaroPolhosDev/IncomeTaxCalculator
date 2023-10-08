using Customers_API.Contexts;
using Customers_API.Models;
using System.Data.Entity;

namespace Customers_API.DataSource
{
    /// <summary>
    /// Customers data source class interacting with database
    /// </summary>
    public class CustomersDataSource : ICustomersDataSource
    {

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="createCustomerRequest">Create Custommer Request</param>
        /// <returns>The created <see cref="Customer"/></returns>
        public async Task<Customer> CreateCustomerAsync(CreateCustomerRequest createCustomerRequest)
        {
            Customer customerToInsert = new Customer 
            {
                FirstName = createCustomerRequest.FirstName,
                LastName = createCustomerRequest.LastName,
                BirthDate = createCustomerRequest.BirthDate,
                AnnualIncome = createCustomerRequest.AnnualIncome
            };

            using (var db = new CustomerContext())
            {
                db.Customers.Add(customerToInsert);

                await db.SaveChangesAsync();
            }

            return customerToInsert;
        }

        /// <summary>
        /// Get customer by the requested id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>Customer</returns>
        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            Customer customer;

            using (var db = new CustomerContext())
            {
                customer = await db.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
            }

            return customer ?? throw new KeyNotFoundException($"Customer with id: {customerId} doesn't exist");
        }
    }
}
