using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.DATA;
using KoliPortal.Lib.MODEL;
using Microsoft.EntityFrameworkCore;

namespace KoliPortal.API.SERVICE
{
    public class KarbantartasiKeresekService : IKarbantartasiKeresek
    {
        private readonly KoliportalDBContext _context;
        public KarbantartasiKeresekService(KoliportalDBContext context)
        {
            _context = context;
        }
        public async Task<KarbantartasiKeresek> Add(KarbantartasiKeresek entity)
        {
            _context.KarbantartasiKeresek.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await _context.KarbantartasiKeresek.FindAsync(id);
            if(entity != null)
            {
                _context.KarbantartasiKeresek.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<KarbantartasiKeresek>> GetAll()
        {
            return await _context.KarbantartasiKeresek.ToListAsync();
        }

        public async Task Update(KarbantartasiKeresek entity)
        {
            _context.KarbantartasiKeresek.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
