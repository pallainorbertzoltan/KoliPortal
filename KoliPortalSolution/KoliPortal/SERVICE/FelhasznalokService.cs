using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.DATA;
using KoliPortal.Lib.MODEL;
using Microsoft.EntityFrameworkCore;

namespace KoliPortal.API.SERVICE
{
    public class FelhasznalokService : IFelhasznalok
    {
        private readonly KoliportalDBContext _context;
        public FelhasznalokService(KoliportalDBContext context)
        {
            _context = context;
        }
        public async Task<Felhasznalok> Add(Felhasznalok entity)
        {
            _context.Felhasznalok.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = _context.Felhasznalok.Find(id);
            if (entity != null)
            {
                _context.Felhasznalok.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Felhasznalok>> GetAll()
        {
            return await _context.Felhasznalok.ToListAsync();
        }

        public async Task Update(Felhasznalok entity)
        {
            _context.Felhasznalok.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
