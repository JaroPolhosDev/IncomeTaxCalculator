namespace Customers_API.Models
{
    /// <summary>
    /// Customer Entity
    /// </summary>
    public record Customer
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Customer First Name
        /// </summary>
        public string FirstName { get; init; } 

        /// <summary>
        /// Customer Last Name
        /// </summary>
        public string LastName { get; init; }

        /// <summary>
        /// Customer Birth Date
        /// </summary>
        public DateTime BirthDate { get; init; }

        /// <summary>
        /// Customer Annual Income
        /// </summary>
        public double AnnualIncome { get; init; }   
    }
}
