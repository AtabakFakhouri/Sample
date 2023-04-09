namespace AFS.SAMPLE.Helper.Repository;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    Task CommitAsync();
    void Rollback();
}
