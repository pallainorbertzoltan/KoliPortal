using KoliPortal.Lib.MODEL;

namespace KoliPortal.API.INTERFACE
{
    public interface ISzobak
    {
        Task<List<Szobak>> GetAll();
    }
}
