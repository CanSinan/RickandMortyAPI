using RickAndMorty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.EpisodeRepositories
{
    public interface IEpisodeService 
    {
        Task<IEnumerable<Episode>> GetAllAsync();
        Task<Episode> GetByIdAsync(int id);
        Task<Episode> CreateAsync(Episode entity);
        Task<Episode> UpdateAsync(Episode entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
