using KoliPortal.Lib.MODEL;

namespace KoliPortal.API.INTERFACE
{
    public interface IFizetesTipusok
    {
            Task<List<FizetesTipusok>> GetAll();
    }
}
