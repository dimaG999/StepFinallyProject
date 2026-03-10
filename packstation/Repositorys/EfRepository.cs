
using Microsoft.EntityFrameworkCore;
using packstation.Data;

namespace packstation.Repositorys
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _db;
        public EfRepository(AppDbContext db)
        {
            _db = db; 
        }
        public async Task AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _db.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<T> GetBySendingNumberAsync(string sendingNumber)
        {
            return await _db.Set<T>()
         .FirstOrDefaultAsync(p => EF.Property<string>(p, "SendingNumber") == sendingNumber);
        }

        public IQueryable<T> Query()
        {
            return _db.Set<T>().AsQueryable();
        }
        public async Task<int> SaveChangeAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public async void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }
    }
}
