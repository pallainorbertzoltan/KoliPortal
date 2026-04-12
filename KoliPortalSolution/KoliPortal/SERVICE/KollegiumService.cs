using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.DATA;
using KoliPortal.Lib.MODEL;
using Microsoft.EntityFrameworkCore;

namespace KoliPortal.API.SERVICE
{
    public class KollegiumService : IKollegium
    {
        private readonly KoliportalDBContext _context;

        public KollegiumService(KoliportalDBContext context)
        {
            _context = context;
        }
        public async Task<List<Kollegium>> GetAll()
        {
            return await _context.Kollegium.ToListAsync();
        }
    }
}
