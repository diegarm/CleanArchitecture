using Clean.Domain.Entities;
using Clean.Domain.Entities.Enum;
using Clean.Infrastructure.Data.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Clean.Infrastructure.Data.EntityFramework.Context
{
    /// <summary>
    /// A DbContext instance represents a session with the database and can be used to
    //     query and save instances of your entities. DbContext is a combination of the
    //     Unit Of Work and Repository patterns.
    /// </summary>
    public class CleanContext : DbContext
    {
        public CleanContext(DbContextOptions<CleanContext> options) : base(options) 
        { 
        }

        /// <summary>
        /// DBSet representing the table Person in the database 
        /// </summary>
        public DbSet<Person> Person { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanContext).Assembly);
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            base.OnModelCreating(modelBuilder);     

        }

    }
}
