using KoliPortal.Lib.MODEL;

namespace KoliPortal.API.INTERFACE
{
    public interface IKollegium
    {
        Task<List<Kollegium>> GetAll();
    }
}
