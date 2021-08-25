using Clean.Domain.Interfaces;
using Clean.Infrastructure.Data.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Infrastructure.Data.EntityFramework.Repository
{
    public class GeneralRepository : IGeneralRepository
    {
        public CleanContext context;

        public async Task<bool> AddAsync<T>(T entity) where T : class
        {
            context.Add(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync<T>(T entity) where T : class
        {
            context.Update(entity);
            return await SaveChangesAsync();

        }

        public async Task<bool> DeleteAsync<T>(T entity) where T : class
        {
            context.Remove(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
    }
}
