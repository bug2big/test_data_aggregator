using System.Linq.Expressions;

namespace TestWebApplication.Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetByCriteriaAsync(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default);
}
