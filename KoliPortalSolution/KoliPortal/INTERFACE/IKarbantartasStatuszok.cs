using KoliPortal.Lib.MODEL;

namespace KoliPortal.API.INTERFACE
{
    public interface IKarbantartasStatuszok
    {
            Task<List<KarbantartasStatuszok>> GetAll();
    }
}
