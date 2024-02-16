using RickAndMorty.Data.Entities;
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

        public LocationService(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Location> CreateAsync(Location entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Location> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }

        public async Task<Location> UpdateAsync(Location entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
