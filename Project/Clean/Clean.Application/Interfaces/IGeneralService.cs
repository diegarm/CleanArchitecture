using System.Threading.Tasks;

namespace Clean.Application.Interfaces
{
    public interface IGeneralService
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
    }
}