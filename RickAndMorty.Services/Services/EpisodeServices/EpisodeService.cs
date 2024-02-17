using RickAndMorty.Data.Entities;
using RickAndMorty.Data.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.EpisodeRepositories
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeRepository _repository;

        public EpisodeService(IEpisodeRepository repository)
        {
            _repository = repository;
        }


        public async Task<(IEnumerable<Episode> Episode, Info Info)> GetAllWithPagenationAsync(PaginationModel paginationModel)
        {
            return await _repository.GetAllWithPagenationAsync(paginationModel);
        }

      
    }
}
