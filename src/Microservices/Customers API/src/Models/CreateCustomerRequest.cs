namespace Customers_API.Models
{
    /// <summary>
    /// Create a new customer request
    /// </summary>
    public record CreateCustomerRequest
    {
        /// <summary>
        /// Customer First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Customer Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Customer Birth Date
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Customer Annual Income
        /// </summary>
        public double AnnualIncome { get; set; }
    }
}
