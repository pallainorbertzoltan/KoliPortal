using KoliPortal.Lib.MODEL;

namespace KoliPortal.API.INTERFACE
{
    public interface ISzerepkorok
    {
            Task<List<Szerepkorok>> GetAll();
    }
}
