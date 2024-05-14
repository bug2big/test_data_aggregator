using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestWebApplication.Application.Interfaces;
using TestWebApplication.Infrastructure.Persistence.Common;

namespace TestWebApplication.Infrastructure.Persistence.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    private readonly PostgresApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(PostgresApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetByCriteriaAsync(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsQueryable()
            .Where(criteria)
            .ToListAsync(cancellationToken);
    }
}
