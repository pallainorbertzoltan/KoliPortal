using KoliPortal.Lib.MODEL;

namespace KoliPortal.API.INTERFACE
{
    public interface ISzobaBeosztasok
    {
        Task<List<SzobaBeosztasok>> GetAll();
        Task<SzobaBeosztasok> Add(SzobaBeosztasok entity);
        Task Update(SzobaBeosztasok entity);
        Task Delete(int id);
    }
}
