namespace Example.Platform.Persistence
{
    public interface IRepository<TKey, TEntity>
      where TKey : struct, IEquatable<TKey>
      where TEntity : EntityBase<TKey>
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> GetAsync(TKey key, CancellationToken cancellationToken = default);    
    }
}
