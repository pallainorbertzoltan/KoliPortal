using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.DATA;
using KoliPortal.Lib.MODEL;
using Microsoft.EntityFrameworkCore;

namespace KoliPortal.API.SERVICE
{
    public class KarbantartasStatuszokService : IKarbantartasStatuszok
    {
        private readonly KoliportalDBContext _context;
        public KarbantartasStatuszokService(KoliportalDBContext context)
        {
            _context = context;
        }

        public async Task<List<KarbantartasStatuszok>> GetAll()
        {
            return await _context.KarbantartasStatuszok.ToListAsync();
        }
    }
}
