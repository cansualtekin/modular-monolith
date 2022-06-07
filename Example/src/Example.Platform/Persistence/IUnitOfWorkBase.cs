namespace Example.Platform.Persistence
{
    public interface IUnitOfWorkBase 
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
