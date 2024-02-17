using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Entities
{
    public class User : BaseEntity
    {
        [StringLength(50)]
        public string? FirstName { get; set; }
        [StringLength(80)]
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? AccessTokenCreateDate { get; set; }
        public UserRole Role { get; set; }
    }
}
