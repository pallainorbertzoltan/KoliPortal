using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.DATA;
using Microsoft.EntityFrameworkCore;

namespace KoliPortal.API.SERVICE
{
    public class GenericKoliPortalService<T> : IGenericKoliPortal<T> where T : class
    {
        private readonly KoliportalDBContext _context;
        private readonly DbSet<T> _set;

        public GenericKoliPortalService(KoliportalDBContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _set.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            _set.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await _set.FindAsync(id);
            if (entity != null)
            {
                _set.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(T entity)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
