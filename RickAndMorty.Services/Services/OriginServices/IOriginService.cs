using RickAndMorty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.OriginRepositories
{
    public interface IOriginService
    {
        Task<IEnumerable<Origin>> GetAllAsync();
        Task<Origin> GetByIdAsync(int id);
        Task<Origin> CreateAsync(Origin entity);
        Task<Origin> UpdateAsync(Origin entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
