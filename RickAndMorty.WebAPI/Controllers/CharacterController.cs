using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Data.Repositories.CharacterRepository;
using RickAndMorty.Data.RequestFeatures;
using RickAndMorty.Services.Models;
using RickAndMorty.Services.Models.CharacterModels;

namespace RickAndMorty.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;
        private readonly IMapper _mapper;
        public CharacterController(ICharacterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<Response> GetCharactersWithPagination([FromQuery] PaginationModel paginationModel)
        {
            var characters = await _service.GetAllWithPagenationAsync(paginationModel);
            var response = new Response();
            if (characters.Character == null && characters.Info == null)
            {
                response.Code = 404;
                response.Message = "Characters or Info not found";
                response.Data = null;
                response.Info = null;
                return response;
            }
            var characterMap = _mapper.Map<IEnumerable<CharacterModel>>(characters.Character);

            response.Code = 200;
            response.Message = "Success";
            response.Data = characterMap;
            response.Info = characters.Info;
            return response;

        }
    }
}
