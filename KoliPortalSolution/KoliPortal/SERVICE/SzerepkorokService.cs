using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.DATA;
using KoliPortal.Lib.MODEL;
using Microsoft.EntityFrameworkCore;

namespace KoliPortal.API.SERVICE
{
    public class SzerepkorokService : ISzerepkorok
    {
        private readonly KoliportalDBContext _context;

        public SzerepkorokService(KoliportalDBContext context)
        {
            _context = context;
        }

        public async Task<List<Szerepkorok>> GetAll()
        {
            return await _context.Szerepkorok.ToListAsync();
        }
    }
}
