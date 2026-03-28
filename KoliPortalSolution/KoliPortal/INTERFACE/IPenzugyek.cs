using KoliPortal.Lib.MODEL;

namespace KoliPortal.API.INTERFACE
{
    public interface IPenzugyek
    {
            Task<List<Penzugyek>> GetAll();
            Task<Penzugyek> Add(Penzugyek entity);
            Task Update(Penzugyek entity);
            Task Delete(int id);
    }
}
