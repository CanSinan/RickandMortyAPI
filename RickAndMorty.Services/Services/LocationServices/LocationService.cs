using RickAndMorty.Data.Entities;
using RickAndMorty.Data.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.LocationRepositories
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repository;

        

        public async Task<(IEnumerable<Location> Location, Info Info)> GetAllWithPagenationAsync(PaginationModel paginationModel)
        {
            return await _repository.GetAllWithPagenationAsync(paginationModel);
        }

       
    }
}
