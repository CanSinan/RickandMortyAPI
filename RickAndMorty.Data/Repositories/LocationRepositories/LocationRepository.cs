using Microsoft.EntityFrameworkCore;
using RickAndMorty.Data.Contexts;
using RickAndMorty.Data.Entities;
using RickAndMorty.Data.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.LocationRepositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly RickAndMortyDbContext _context;

        public LocationRepository(RickAndMortyDbContext context)
        {
            _context = context;
        }

       
        public async Task<(IEnumerable<Location> Location, Info Info)> GetAllWithPagenationAsync(PaginationModel paginationModel)
        {
            var baseUrl = "https://localhost:7026/api/Location";
            var info = new Info();
            var startIndex = (paginationModel.PageNumber - 1) * paginationModel.PageSize;
            var locations = await _context.Locations.Include(x => x.Residents).ToListAsync();

            if (!string.IsNullOrWhiteSpace(paginationModel.SearchTerm))
            {
                locations = locations.Where(x => x.Name.Contains(paginationModel.SearchTerm.ToLower())).ToList();
            }

            var tablesOnPage = locations
                .OrderBy(x => x.Id)
                .Skip(startIndex)
                .Take(paginationModel.PageSize).ToList();
            var totalCount = await _context.Locations.CountAsync();

            info.Count = totalCount;

            info.Pages = (int)Math.Ceiling((double)totalCount / paginationModel.PageSize);

            info.Prev = paginationModel.PageNumber > 1 ? $"{baseUrl}?PageNumber={paginationModel.PageNumber - 1}PageSize={paginationModel.PageSize}" : null;

            info.Next = paginationModel.PageNumber < info.Pages ? $"{baseUrl}?PageNumber={paginationModel.PageNumber + 1}PageSize={paginationModel.PageSize}" : null;

            return (tablesOnPage, info);
        }

    }
}
