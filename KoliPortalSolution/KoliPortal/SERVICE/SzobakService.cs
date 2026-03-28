using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.DATA;
using KoliPortal.Lib.MODEL;
using Microsoft.EntityFrameworkCore;

namespace KoliPortal.API.SERVICE
{
    public class SzobakService : ISzobak
    {
        private readonly KoliportalDBContext _context;
        public SzobakService(KoliportalDBContext context)
        {
            _context = context;
        }

        public async Task<List<Szobak>> GetAll()
        {
            return await _context.Szobak.ToListAsync();
        }
    }
}
