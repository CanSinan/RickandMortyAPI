using RickAndMorty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.ResidentRepositories
{
    public class ResidentRepository : IResidentRepository
    {
        private readonly IGenericRepository<Resident> _repository;

        public ResidentRepository(IGenericRepository<Resident> repository)
        {
            _repository = repository;
        }

        public async Task<Resident> CreateAsync(Resident entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Resident>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Resident> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }

        public async Task<Resident> UpdateAsync(Resident entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
