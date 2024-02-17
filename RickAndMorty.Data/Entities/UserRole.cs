using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Entities
{
    public class UserRole : BaseEntity
    {
        [StringLength(50)]
        public string RoleName { get; set; }
        public ICollection<User> User { get; set; }
    }
}
