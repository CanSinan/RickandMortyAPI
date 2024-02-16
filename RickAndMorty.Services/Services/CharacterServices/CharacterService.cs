using RickAndMorty.Data.Entities;
using RickAndMorty.Data.Repositories.CharacterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.CharacterRepositories
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _repository;

        public CharacterService(ICharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task<Character> CreateAsync(Character entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Character> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }

        public async Task<Character> UpdateAsync(Character entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
