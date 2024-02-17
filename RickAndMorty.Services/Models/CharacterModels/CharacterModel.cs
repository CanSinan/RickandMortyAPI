using RickAndMorty.Data.Entities;
using RickAndMorty.Services.Models.EpisodeModels;
using RickAndMorty.Services.Models.LocationModels;
using RickAndMorty.Services.Models.OriginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Services.Models.CharacterModels
{
    public class CharacterModel : BaseEpisodeModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public OriginModelForGetCharacter Origin { get; set; }
        public LocationModelForGetCharacter Location { get; set; }
        public string Image { get; set; }
        public ICollection<EpisodeModelForGetCharacter> Episode { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
    }
}
