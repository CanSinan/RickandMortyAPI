using RickAndMorty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.EpisodeRepositories
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly IGenericRepository<Episode> _repository;

        public EpisodeRepository(IGenericRepository<Episode> repository)
        {
            _repository = repository;
        }

        public async Task<Episode> CreateAsync(Episode entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Episode>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Episode> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }

        public async Task<Episode> UpdateAsync(Episode entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
