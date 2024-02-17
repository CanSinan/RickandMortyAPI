using RickAndMorty.Data.Entities;
using RickAndMorty.Data.RequestFeatures;

namespace RickAndMorty.Data.Repositories.CharacterRepository
{
    public interface ICharacterRepository : IGenericRepository<Character>
    {
        //public Task<string> GetInfo(string page); 
        Task<(IEnumerable<Character> Character, Info Info)> GetAllWithPagenationAsync(PaginationModel paginationModel);
    }
}
