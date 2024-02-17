using Microsoft.EntityFrameworkCore;
using RickAndMorty.Data.Contexts;
using RickAndMorty.Data.Entities;
using RickAndMorty.Data.Repositories.CharacterRepository;
using RickAndMorty.Data.RequestFeatures;

namespace RickAndMorty.Data.Repositories.CharacterRepositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly RickAndMortyDbContext _context;
        public CharacterRepository(RickAndMortyDbContext context)
        {
           
            _context = context;
        }



        public async Task<(IEnumerable<Character> Character, Info Info)> GetAllWithPagenationAsync(PaginationModel paginationModel)
        {

            var characters = await GetCharactersAsync(paginationModel);
            var totalCount = await _context.Characters.CountAsync();

            var info = GenerateInfo(paginationModel, totalCount);

            return (characters, info);
        }

        private async Task<List<Character>> GetCharactersAsync(PaginationModel paginationModel)
        {
            if (paginationModel.PageNumber == 0)
            {
                return await _context.Characters.Include(x => x.Origin).Include(x => x.Location).Include(x => x.Episode).ToListAsync();
            }

            var startIndex = (paginationModel.PageNumber - 1) * paginationModel.PageSize;

            var characters = await _context.Characters.Include(x => x.Origin).Include(x => x.Location).Include(x => x.Episode).ToListAsync();

            if (!string.IsNullOrWhiteSpace(paginationModel.SearchTerm))
            {
                characters = characters.Where(x => x.Name.Contains(paginationModel.SearchTerm.ToLower())).ToList();
            }

            return characters
                .OrderBy(x => x.Id)
                .Skip(startIndex)
                .Take(paginationModel.PageSize).ToList();
        }

        private Info GenerateInfo(PaginationModel paginationModel, int totalCount)
        {
            var baseUrl = "https://localhost:7026/api/Character";
            var info = new Info();
            if (paginationModel.PageNumber == 0)
            {
                info.Count = 0;
                info.Pages = 0;
                info.Prev = null;
                info.Next = null;
                return info;

            }

            info.Count = totalCount;
            info.Pages = (int)Math.Ceiling((double)totalCount / paginationModel.PageSize);
            info.Prev = paginationModel.PageNumber > 1 ? $"{baseUrl}?PageNumber={paginationModel.PageNumber - 1}&PageSize={paginationModel.PageSize}" : null;
            info.Next = paginationModel.PageNumber < info.Pages ? $"{baseUrl}?PageNumber={paginationModel.PageNumber + 1}&PageSize={paginationModel.PageSize}" : null;

            return info;
        }


    }
}
