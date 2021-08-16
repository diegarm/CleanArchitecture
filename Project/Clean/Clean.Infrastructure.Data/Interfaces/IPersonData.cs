using Clean.Domain.Entities;
using System.Collections.Generic;

namespace Clean.Infrastructure.Data.Interfaces
{
    public interface IPersonData
    {
        IEnumerable<Person> GetAllPersonByNameAsync(string name);

        IEnumerable<Person> GetAllPersonAsync();
    }
}
