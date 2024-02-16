using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Entities
{
    public class Location : BaseEntity
    {
        public Location()
        {
            Residents = new List<Resident>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Dimension { get; set; }
        public List<Resident> Residents { get; set; }
        public string Url { get; set; }
        public string Created { get; set; }
    }
}
