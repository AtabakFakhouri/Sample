using AFS.SAMPLE.DataAccess;
using AFS.SAMPLE.Helper.Repository;

namespace AFS.SAMPLE.InfrastructureLayer
{
    public class MemoryUnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public MemoryUnitOfWork(Context context)
        {
            _context = context;
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            //rollback
        }

        public void Dispose()
        {
            //dispose
        }
    }
}
