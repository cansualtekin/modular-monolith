using Microsoft.EntityFrameworkCore;

namespace Example.Platform.Persistence
{
    public class RepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity> 
      where TKey : struct, IEquatable<TKey>
      where TEntity : EntityBase<TKey>
    {
        private readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);   
        }

        public async Task<TEntity> GetAsync(TKey key, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<TEntity>().SingleOrDefaultAsync(x => x.Id.Equals(key), cancellationToken);

            if (entity == null)
            {
                throw new RecordNotFoundException<TKey>(key);  
            }
            
            return entity;  
        }
    }
}
