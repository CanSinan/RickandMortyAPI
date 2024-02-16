using RickAndMorty.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.ResidentRepositories
{
    public interface IResidentService 
    {
        Task<IEnumerable<Resident>> GetAllAsync();
        Task<Resident> GetByIdAsync(int id);
        Task<Resident> CreateAsync(Resident entity);
        Task<Resident> UpdateAsync(Resident entity);
        Task<bool> DeleteAsync(int id);
        Task SaveAsync();
    }
}
