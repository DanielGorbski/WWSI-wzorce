public class EfCoreRepository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;
    private DbSet<T> _entities;

    public EfCoreRepository(DbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _entities.ToListAsync();

    public async Task<T> GetByIdAsync(int id) => await _entities.FindAsync(id);

    public async Task AddAsync(T entity)
    {
        await _entities.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _entities.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _entities.Remove(entity);
        await _context.SaveChangesAsync();
    }
}