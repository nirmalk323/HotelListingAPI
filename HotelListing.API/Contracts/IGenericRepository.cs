namespace HotelListing.API.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> Delete(int id, T entity);
        Task<T> GetAsync(int id);
        Task<T> UpdateAsync(int id, T entity);
        Task<T> AddAsync(T entity);

    }
}
