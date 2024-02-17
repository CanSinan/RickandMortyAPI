using RickAndMorty.Data.Entities;
using RickAndMorty.Services.Models.ResidentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Services.Models.LocationModels
{
    public class LocationModel : BaseLocationModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Dimension { get; set; }
        public ICollection<ResidentModelForGetLocation> Residents { get; set; }
        public string Url { get; set; }
        public string Created { get; set; }
    }
}
