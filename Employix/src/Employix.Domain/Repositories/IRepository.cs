using Employix.Domain.Models.Entities;

namespace Employix.Domain.Repositories
{
    public interface IRepository<TEntity>
    where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(String Id);

        Task<List<TEntity>> GetAsync(int pageNum, int pageSize);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(String Id);
    }
}
