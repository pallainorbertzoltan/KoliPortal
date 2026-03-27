using KoliPortal.API.INTERFACE;
using KoliPortal.Lib.DATA;
using KoliPortal.Lib.MODEL;
using Microsoft.EntityFrameworkCore;

namespace KoliPortal.API.SERVICE
{
    public class FizetesTipusokService : IFizetesTipusok
    {
        private readonly KoliportalDBContext _context;
        public FizetesTipusokService(KoliportalDBContext context)
        {
            _context = context;
        }
        public async Task<List<FizetesTipusok>> GetAll()
        {
            return await _context.FizetesTipusok.ToListAsync();
        }
    }
}
