using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.DATA;
using KoliPortal.Lib.MODEL;
using Microsoft.EntityFrameworkCore;

namespace KoliPortal.API.SERVICE
{
    public class SzobaBeosztasokService : ISzobaBeosztasok
    {
        private readonly KoliportalDBContext _context;
        public SzobaBeosztasokService(KoliportalDBContext context)
        {
            _context = context;
        }
        public async Task<SzobaBeosztasok> Add(SzobaBeosztasok entity)
        {
            _context.SzobaBeosztasok.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await _context.SzobaBeosztasok.FindAsync(id);    
            if (entity != null)
            {
                _context.SzobaBeosztasok.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SzobaBeosztasok>> GetAll()
        {
            return await _context.SzobaBeosztasok.ToListAsync();
        }

        public async Task Update(SzobaBeosztasok entity)
        {
            _context.SzobaBeosztasok.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
