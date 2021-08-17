using Clean.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Interfaces
{
    public interface IPersonService : IGeneralService
    {
        Task<IEnumerable<PersonViewModel>> GetAllPersonByNameAsync(string name);

        Task<IEnumerable<PersonViewModel>> GetAllPersonAsync();

    }
}
