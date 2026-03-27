using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.DATA;
using KoliPortal.Lib.MODEL;
using Microsoft.EntityFrameworkCore;

namespace KoliPortal.API.SERVICE
{
    public class DiakAdatokService : IDiakAdatok
    {
        private readonly KoliportalDBContext _context;
        public DiakAdatokService(KoliportalDBContext context)
        {
            _context = context;
        }

        public async Task<DiakAdatok> Add(DiakAdatok entity)
        {
            _context.DiakAdatok.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await _context.DiakAdatok.FindAsync(id);
            if (entity != null)
            {
                _context.DiakAdatok.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DiakAdatok>> GetAll()
        {
            return await _context.DiakAdatok.ToListAsync();
        }

        public async Task Update(DiakAdatok entity)
        {
            _context.DiakAdatok.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}