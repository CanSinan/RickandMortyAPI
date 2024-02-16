using RickAndMorty.Data.Entities;

namespace RickAndMorty.Data.Repositories.CharacterRepository
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> GetAllAsync();
        Task<Character> GetByIdAsync(int id);
        Task<Character> CreateAsync(Character entity);
        Task<Character> UpdateAsync(Character entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
