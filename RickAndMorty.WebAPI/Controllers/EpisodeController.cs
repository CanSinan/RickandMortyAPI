using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Data.Repositories.CharacterRepository;
using RickAndMorty.Data.Repositories.EpisodeRepositories;
using RickAndMorty.Data.RequestFeatures;
using RickAndMorty.Services.Models;
using RickAndMorty.Services.Models.CharacterModels;
using RickAndMorty.Services.Models.EpisodeModels;

namespace RickAndMorty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]


    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeService _service;
        private readonly IMapper _mapper;
        public EpisodeController(IEpisodeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<Response> GetCharactersWithPagination([FromQuery] PaginationModel paginationModel)
        {
            var episodes = await _service.GetAllWithPagenationAsync(paginationModel);
            var response = new Response();
            if (episodes.Episode == null && episodes.Info == null)
            {
                response.Code = 404;
                response.Message = "Episodes or Info not found";
                response.Data = null;
                response.Info = null;
                return response;
            }
            var episodeMap = _mapper.Map<IEnumerable<EpisodeModel>>(episodes.Episode);

            response.Code = 200;
            response.Message = "Success";
            response.Data = episodeMap;
            response.Info = episodes.Info;
            return response;

        }
    }
}
