using System.Threading.Tasks;

namespace Clean.Application.Interfaces
{
    public interface IGeneralService
    {
        Task<bool> Add<T>(T entity) where T : class;

        Task<bool> Update<T>(T entity) where T : class;

        Task<bool> Delete<T>(T entity) where T : class;

    }
}