using System.Linq.Expressions;
using Application.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Repositories;

internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    protected Repository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(object id)
        => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _dbSet.ToListAsync();

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        => await _dbSet.Where(predicate).ToListAsync();

    public async Task AddAsync(TEntity entity)
        => await _dbSet.AddAsync(entity);

    public void Update(TEntity entity)
        => _dbSet.Update(entity);

    public void Delete(TEntity entity)
        => _dbSet.Remove(entity);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}