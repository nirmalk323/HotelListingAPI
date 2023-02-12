using HotelListing.API.Contracts;
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListingDbContext _dbContext;
        public GenericRepository(HotelListingDbContext hotelListingDbContext) 
        {
            _dbContext = hotelListingDbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id, T entityToDelete)
        {
            var entity = await GetAsync(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entityToDelete);
                await _dbContext.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entity = await _dbContext.Set<T>().Select(x => x).ToListAsync<T>();

            return entity;
        }

        public async Task<T> GetAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);

            return entity;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            //var entity = await _dbContext.Set<T>().FindAsync(id);

            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
