using KoliPortal.Lib.MODEL;

namespace KoliPortal.API.INTERFACE
{
    public interface IKarbantartasiKeresek
    {
        Task<List<KarbantartasiKeresek>> GetAll();
        Task<KarbantartasiKeresek> Add(KarbantartasiKeresek entity);
        Task Update(KarbantartasiKeresek entity);
        Task Delete(int id);
    }
}
