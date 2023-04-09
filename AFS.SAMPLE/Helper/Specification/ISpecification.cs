using System.Linq.Expressions;

namespace AFS.SAMPLE.Helper.Specification;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> SpecExpression { get; }
    bool IsSatisfiedBy(T obj);
}
