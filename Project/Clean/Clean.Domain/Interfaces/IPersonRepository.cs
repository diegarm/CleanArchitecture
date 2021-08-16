using Clean.Domain.Entities;
using System.Threading.Tasks;

namespace Clean.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person[]> GetAllPersonByNameAsync(string name);

        Task<Person[]> GetAllPersonAsync();
    }
}
