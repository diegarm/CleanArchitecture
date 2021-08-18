using Clean.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clean.Domain.Interfaces
{
    public interface IPersonRepository : IGeneralRepository
    {
        Task<IEnumerable<Person>> GetAllPersonByNameAsync(string name);

        Task<IEnumerable<Person>> GetAllPersonAsync();
        Task<Person> GetPersonById(int id);
    }
}
