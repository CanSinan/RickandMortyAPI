using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Entities
{
    public class Origin : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
