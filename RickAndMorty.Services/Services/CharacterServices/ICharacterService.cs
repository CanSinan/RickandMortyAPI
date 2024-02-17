using RickAndMorty.Data.Entities;
using RickAndMorty.Data.RequestFeatures;

namespace RickAndMorty.Data.Repositories.CharacterRepository
{
    public interface ICharacterService
    {
        
        Task<(IEnumerable<Character> Character, Info Info)> GetAllWithPagenationAsync(PaginationModel paginationModel);

    }
}
