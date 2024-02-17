using RickAndMorty.Data.Entities;
using RickAndMorty.Data.RequestFeatures;

namespace RickAndMorty.Data.Repositories.LocationRepositories
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repository;

        public LocationService(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<(IEnumerable<Location> Location, Info Info)> GetAllWithPagenationAsync(PaginationModel paginationModel)
        {
            return await _repository.GetAllWithPagenationAsync(paginationModel);
        }


    }
}
