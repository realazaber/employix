using Employix.Domain.Models.Entities;
using Employix.Domain.Repositories;
using Employix.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Employix.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(string Id)
        {
            await _dbContext.Set<T>().Where(e => e.Id.ToString() == Id).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<T>> GetAsync(int pageNum, int pageSize)
        {
            return await _dbContext.Set<T>()
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(string Id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id.ToString() == Id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await Task.Run(() =>
            {
                _dbContext.Set<T>().Update(entity);
                _dbContext.SaveChanges();
                return entity;
            });
        }
    }
}
