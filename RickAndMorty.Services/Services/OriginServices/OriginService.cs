using RickAndMorty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.OriginRepositories
{
    public class OriginService : IOriginService
    {
        private readonly IOriginRepository _repository;

        public OriginService(IOriginRepository repository)
        {
            _repository = repository;
        }

        public async Task<Origin> CreateAsync(Origin entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Origin>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Origin> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }

        public async Task<Origin> UpdateAsync(Origin entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
