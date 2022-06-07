using Microsoft.EntityFrameworkCore;

namespace Example.Platform.Persistence
{
    public class UnitOfWorkBase : IUnitOfWorkBase
    {
        private readonly DbContext _dbContext;

        public UnitOfWorkBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           return await _dbContext.SaveChangesAsync(cancellationToken);   
        }
    }
}