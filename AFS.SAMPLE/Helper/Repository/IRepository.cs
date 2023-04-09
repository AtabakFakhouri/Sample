namespace AFS.SAMPLE.Helper.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity Get(Func<TEntity, bool> predict);
        IEnumerable<TEntity> GetQueryble(Func<TEntity, bool> predict);
        IQueryable<TEntity> GetQueryble();
        TEntity FindById(object id);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
