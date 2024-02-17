using RickAndMorty.Data.Entities;
using RickAndMorty.Data.RequestFeatures;

namespace RickAndMorty.Data.Repositories.LocationRepositories
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        Task<(IEnumerable<Location> Location, Info Info)> GetAllWithPagenationAsync(PaginationModel paginationModel);

    }
}
