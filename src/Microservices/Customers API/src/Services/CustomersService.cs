using Customers_API.Models;
using Customers_API.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace Customers_API.Services
{
    /// <summary>
    /// Customers Service
    /// </summary>
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IValidator<Customer> _validator;

        /// <summary>
        /// Create a new instance of the <see cref="CustomersService"/> class
        /// </summary>
        /// <param name="customersRepository">Customers Repository</param>
        /// <param name="validator">Validator</param>
        public CustomersService(ICustomersRepository customersRepository, IValidator<Customer> validator)
        {
            _customersRepository = customersRepository;
            _validator = validator;
        }

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="createCustomerRequest">Create Custommer Request</param>
        /// <returns>The created <see cref="Customer"/></returns>
        public async Task<Customer> CreateCustomerAsync(CreateCustomerRequest createCustomerRequest)
        {
            Customer customer = new Customer 
            { 
                FirstName = createCustomerRequest.FirstName,
                LastName = createCustomerRequest.LastName,
                BirthDate= createCustomerRequest.BirthDate,
                AnnualIncome = createCustomerRequest.AnnualIncome
            };

            ValidationResult validationResult = await _validator.ValidateAsync(customer, options => options.IncludeRuleSets(CustomerValidator.Create));

            if(!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            Customer createdCustomer = await _customersRepository.CreateCustomerAsync(createCustomerRequest);
            return createdCustomer;
        }

        /// <summary>
        /// Get customer by the requested id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Customer</returns>
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer result = await _customersRepository.GetCustomerByIdAsync(id);
            return result;
        }
    }
}
