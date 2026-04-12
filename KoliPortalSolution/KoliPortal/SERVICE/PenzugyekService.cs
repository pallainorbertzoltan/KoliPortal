using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.DATA;
using KoliPortal.Lib.MODEL;
using Microsoft.EntityFrameworkCore;

namespace KoliPortal.API.SERVICE
{
    public class PenzugyekService : IPenzugyek
    {
        private readonly KoliportalDBContext _context;
        public PenzugyekService(KoliportalDBContext context)
        {
            _context = context;
        }

        public async Task<Penzugyek> Add(Penzugyek entity)
        {
            _context.Penzugyek.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Penzugyek.FindAsync(id);
            if (entity != null)
            {
                _context.Penzugyek.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public Task<List<Penzugyek>> GetAll()
        {
            return _context.Penzugyek.ToListAsync();
        }

        public async Task Update(Penzugyek entity)
        {
            _context.Penzugyek.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
