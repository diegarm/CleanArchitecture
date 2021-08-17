using Clean.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clean.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonByNameAsync(string name);

        Task<IEnumerable<Person>> GetAllPersonAsync();
    }
}
