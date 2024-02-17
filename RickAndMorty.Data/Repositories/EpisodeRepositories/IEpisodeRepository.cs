using RickAndMorty.Data.Entities;
using RickAndMorty.Data.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.EpisodeRepositories
{
    public interface IEpisodeRepository : IGenericRepository<Episode>
    {
        Task<(IEnumerable<Episode> Episode, Info Info)> GetAllWithPagenationAsync(PaginationModel paginationModel);

    }
}
