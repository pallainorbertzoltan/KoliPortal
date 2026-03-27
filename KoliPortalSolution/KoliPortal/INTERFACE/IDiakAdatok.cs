using KoliPortal.Lib.MODEL;

namespace KoliPortal.API.INTERFACE
{
    public interface IDiakAdatok
    {
        Task<List<DiakAdatok>> GetAll();
        Task<DiakAdatok> Add(DiakAdatok entity);
        Task Update(DiakAdatok entity);
        Task Delete(int id);
    }
}
