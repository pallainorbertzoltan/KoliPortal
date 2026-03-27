using KoliPortal.Lib.MODEL;

namespace KoliPortal.API.INTERFACE
{
    public interface IFelhasznalok
    {
        Task<List<Felhasznalok>> GetAll();
        Task<Felhasznalok> Add(Felhasznalok entity);
        Task Update(Felhasznalok entity);
        Task Delete(int id);
    }
}
