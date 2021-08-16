using Clean.Domain.Entities;
using Clean.Infrastructure.Data.EntityFramework.Context;
using Clean.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Infrastructure.Data.EntityFramework.Repository
{
    public class PersonRepository : IPersonData
    {

        private readonly CleanContext context;

        public PersonRepository(CleanContext _context)
        {
            context = _context;
        }

        public async Task<Person[]> GetAllPersonAsync()
        {
            IQueryable<Person> query = context.Person
                                   .AsNoTracking(); //Disabling change tracking is useful for read-only scenarios

            query = query
                        .OrderBy(e => e.Name);

            return await query.ToArrayAsync();

        }

        public async Task<Person[]> GetAllPersonByNameAsync(string name)
        {
            IQueryable<Person> query = context.Person
                                   .AsNoTracking(); //Disabling change tracking is useful for read-only scenarios

            query = query
                        .Where(e => e.Name == name)
                        .OrderBy(e => e.Name);

            return await query.ToArrayAsync();
        }
    }
}
