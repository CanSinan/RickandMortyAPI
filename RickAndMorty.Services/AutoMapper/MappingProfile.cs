using AutoMapper;
using RickAndMorty.Data.Entities;
using RickAndMorty.Services.Models.CharacterModels;
using RickAndMorty.Services.Models.EpisodeModels;
using RickAndMorty.Services.Models.LocationModels;
using RickAndMorty.Services.Models.OriginModels;
using RickAndMorty.Services.Models.ResidentModels;

namespace RickAndMorty.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region CHARACTER

            CreateMap<Character, CharacterModel>().ReverseMap();
            CreateMap<Character, CharacterModelForGetEpisode>().ReverseMap();

            #endregion

            #region EPISODE

            CreateMap<Episode, EpisodeModelForGetCharacter>().ReverseMap();
            CreateMap<Episode, EpisodeModel>().ReverseMap();

            #endregion

            #region LOCATION

            CreateMap<Location, LocationModelForGetCharacter>().ReverseMap();
            CreateMap<Location, LocationModel>().ReverseMap();

            #endregion

            #region ORIGIN

            CreateMap<Origin, OriginModelForGetCharacter>().ReverseMap();

            #endregion

            #region RESIDENT

            CreateMap<Resident, ResidentModelForGetLocation>().ReverseMap();

            #endregion
            

        }
    }
}
