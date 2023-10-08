using Customers_API.Models;
using System.Data.Entity;

namespace Customers_API.Contexts
{
    /// <summary>
    /// Customer Context entity
    /// </summary>
    public class CustomerContext : DbContext
    {
        /// <summary>
        /// Customers
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
    }
}
