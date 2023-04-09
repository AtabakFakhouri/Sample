using AFS.SAMPLE.DataAccess;
using AFS.SAMPLE.Helper.Repository;

namespace AFS.SAMPLE.InfrastructureLayer
{
    public class MemoryRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly Context _context;

        public MemoryRepository(Context context)
        {
            _context = context;
        }
        protected static List<TEntity> entities = new List<TEntity>();

        public TEntity FindById(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetQueryble(Func<TEntity,bool> predict)
        {
            return GetQueryble().Where(predict);
        }
        public IQueryable<TEntity> GetQueryble()
        {
            return _context.Set<TEntity>();
        }

        public TEntity Get(Func<TEntity, bool> predict)
        {
            return GetQueryble(predict).FirstOrDefault();
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);

        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }
    }
}
