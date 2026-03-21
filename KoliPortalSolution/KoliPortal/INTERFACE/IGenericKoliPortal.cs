namespace KoliPortal.API.INTERFACE
{
    public interface IGenericKoliPortal<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
