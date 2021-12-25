using MongoDB.Driver;
using System.Linq.Expressions;

namespace Application.Data.Infrastructure
{
    internal abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDatabase Database;
        protected readonly IMongoCollection<TEntity> DbSet;

        protected RepositoryBase(IMongoContext context)
        {
            Database = context.Database;
            DbSet = Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<TEntity> Add(TEntity obj)
        {
            await DbSet.InsertOneAsync(obj);
            return obj;
        }

        public virtual async Task<TEntity> GetById(string id)
        {
            var data = await DbSet.Find(FilterId(id)).SingleOrDefaultAsync();
            return data;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual async Task<TEntity> Update(string id, TEntity obj)
        {
            await DbSet.ReplaceOneAsync(FilterId(id), obj);
            return obj;
        }

        public virtual async Task<bool> Remove(string id)
        {
            var result = await DbSet.DeleteOneAsync(FilterId(id));
            return result.IsAcknowledged;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private static FilterDefinition<TEntity> FilterId(string key)
        {
            return Builders<TEntity>.Filter.Eq("Id", key);
        }

        public async Task<TEntity> GetById(Expression<Func<TEntity, bool>>? predicate = null)
        {
            var set = CreateSet();
            var query = (predicate == null ? set : set.Where(predicate));

            return query.SingleOrDefault();
        }

        public Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? condition = null, Func<TEntity, string>? order = null)
        {
            var set = CreateSet();
            if (condition != null)
            {
                set = set.Where(condition);
            }

            if (order != null)
            {
                return set;
            }

            return set.ToList();
        }

        private IQueryable<TEntity> CreateSet()
        {
            return DbSet.AsQueryable<TEntity>();
        }
    }
}