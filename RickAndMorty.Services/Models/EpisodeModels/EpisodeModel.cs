using RickAndMorty.Data.Entities;
using RickAndMorty.Services.Models.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Services.Models.EpisodeModels
{
    public class EpisodeModel : BaseEpisodeModel
    {
        public string Name { get; set; }
        public string AirDate { get; set; }
        public string EpisodeCode { get; set; }
        public ICollection<CharacterModelForGetEpisode> Characters { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
    }
}
