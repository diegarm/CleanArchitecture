using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data.EntityFramework.Context
{
    /// <summary>
    /// A DbContext instance represents a session with the database and can be used to
    //     query and save instances of your entities. DbContext is a combination of the
    //     Unit Of Work and Repository patterns.
    /// </summary>
    public class CleanContext : DbContext
    {
        public CleanContext(DbContextOptions<CleanContext> options) : base(options) { }

        /// <summary>
        /// DBSet representing the table Person in the database 
        /// </summary>
        public DbSet<Person> Person { get; set; }

        
    }
}
