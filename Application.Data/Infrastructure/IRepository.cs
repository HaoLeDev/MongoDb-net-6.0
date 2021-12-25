using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Infrastructure
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<TEntity> GetById(Expression<Func<TEntity, bool>>? predicate = null);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? condition = null, Func<TEntity, string>? order = null);
        Task<TEntity> Update(string id, TEntity obj);
        Task<bool> Remove(string id);
    }
}
