using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Data.Repositories.EpisodeRepositories;
using RickAndMorty.Data.Repositories.LocationRepositories;
using RickAndMorty.Data.RequestFeatures;
using RickAndMorty.Services.Models;
using RickAndMorty.Services.Models.EpisodeModels;
using RickAndMorty.Services.Models.LocationModels;

namespace RickAndMorty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _service;
        private readonly IMapper _mapper;
        public LocationController(ILocationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<Response> GetCharactersWithPagination([FromQuery] PaginationModel paginationModel)
        {
            var locations = await _service.GetAllWithPagenationAsync(paginationModel);
            var response = new Response();
            if (locations.Location == null && locations.Info == null)
            {
                response.Code = 404;
                response.Message = "Locations or Info not found";
                response.Data = null;
                response.Info = null;
                return response;
            }
            var locationMap = _mapper.Map<IEnumerable<LocationModel>>(locations.Location);

            response.Code = 200;
            response.Message = "Success";
            response.Data = locationMap;
            response.Info = locations.Info;
            return response;

        }
    }
}
