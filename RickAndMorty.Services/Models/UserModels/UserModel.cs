using RickAndMorty.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace RickAndMorty.Services.Models.UserModels
{
    public class UserModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? AccessTokenCreateDate { get; set; }
        public int UserRoleId{ get; set; }
    }
}
