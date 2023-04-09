namespace AFS.SAMPLE.Helper.Domain;
public abstract class TransactionRoot<T>
{
    public T Id { get; set; }
    public long CreateId { get; set; }
    public DateTime CreateDate { get; set; }
    public long? EditId { get; set; }
    public DateTime? EditDate { get; set; }
    public long? DeleteId { get; set; }
    public DateTime? DeleteDate { get; set; }
}
