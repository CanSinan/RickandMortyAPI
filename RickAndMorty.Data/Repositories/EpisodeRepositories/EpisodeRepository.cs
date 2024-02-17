﻿using Microsoft.EntityFrameworkCore;
using RickAndMorty.Data.Contexts;
using RickAndMorty.Data.Entities;
using RickAndMorty.Data.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Repositories.EpisodeRepositories
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly RickAndMortyDbContext _context;

        public EpisodeRepository(RickAndMortyDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Episode> Episode, Info Info)> GetAllWithPagenationAsync(PaginationModel paginationModel)
        {

            var episodes = await GetEpisodesAsync(paginationModel);
            var totalCount = await _context.Episodes.CountAsync();

            var info = GenerateInfo(paginationModel, totalCount);

            return (episodes, info);
        }

        private async Task<List<Episode>> GetEpisodesAsync(PaginationModel paginationModel)
        {
            if (paginationModel.PageNumber == 0)
            {
                return await _context.Episodes.Include(x => x.Characters).ToListAsync();
            }

            var startIndex = (paginationModel.PageNumber - 1) * paginationModel.PageSize;

            var episodes = await _context.Episodes.Include(x => x.Characters).ToListAsync();

            if (!string.IsNullOrWhiteSpace(paginationModel.SearchTerm))
            {
                episodes = episodes.Where(x => x.Name.Contains(paginationModel.SearchTerm.ToLower())).ToList();
            }

            return episodes
                .OrderBy(x => x.Id)
                .Skip(startIndex)
                .Take(paginationModel.PageSize).ToList();
        }

        private Info GenerateInfo(PaginationModel paginationModel, int totalCount)
        {
            var baseUrl = "https://localhost:7026/api/Episode";
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
