using Clean.Domain.Entities;
using Clean.Infrastructure.Data.EntityFramework.Context;
using Clean.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Infrastructure.Data.EntityFramework.Repository
{
    public class PersonRepository : IPersonRepository
    {

        private readonly CleanContext context;

        public PersonRepository(CleanContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Person>> GetAllPersonAsync()
        {
            IQueryable<Person> query = context.Person
                                   .AsNoTracking(); //Disabling change tracking is useful for read-only scenarios

            query = query
                        .OrderBy(e => e.Name);

            return await query.ToArrayAsync();

        }

        public async Task<IEnumerable<Person>> GetAllPersonByNameAsync(string name)
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
