using RickAndMorty.Data.Entities;
using RickAndMorty.Data.Repositories.CharacterRepository;
using RickAndMorty.Data.RequestFeatures;
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


        public async Task<(IEnumerable<Character> Character, Info Info)> GetAllWithPagenationAsync(PaginationModel paginationModel)
        {
            return await _repository.GetAllWithPagenationAsync(paginationModel);
        }

    }
}
