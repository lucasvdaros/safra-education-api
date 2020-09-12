using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafraEducacional.Domain.Interface.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task AddRange(ICollection<TEntity> entities);
        Task<IEnumerable<TEntity>> GetAll(int skip = 0, int take = 0);
        Task<TEntity> GetById(int id);
        Task Remove(int id);
        void Remove(TEntity entity);
        Task RemoveRange(ICollection<int> ids);
        void RemoveRange(ICollection<TEntity> entities);
        Task Update(TEntity entity);
        void UpdateRange(ICollection<TEntity> entities);
    } 
}