using RickAndMorty.Data.Entities;

namespace RickAndMorty.Data.Repositories.LocationRepositories
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllAsync();
        Task<Location> GetByIdAsync(int id);
        Task<Location> CreateAsync(Location entity);
        Task<Location> UpdateAsync(Location entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
