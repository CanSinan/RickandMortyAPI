using RickAndMorty.Data.Entities;
using RickAndMorty.Data.RequestFeatures;

namespace RickAndMorty.Data.Repositories.LocationRepositories
{
    public interface ILocationService
    {
        

        Task<(IEnumerable<Location> Location, Info Info)> GetAllWithPagenationAsync(PaginationModel paginationModel);
    }
}
