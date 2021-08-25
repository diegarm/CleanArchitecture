using System.Threading.Tasks;

namespace Clean.Domain.Interfaces
{
    public interface IGeneralRepository
    {
        Task<bool> AddAsync<T>(T entity) where T : class;

        Task<bool> UpdateAsync<T>(T entity) where T : class;

        Task<bool> DeleteAsync<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

    }
}
