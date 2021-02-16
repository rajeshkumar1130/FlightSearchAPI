
using System.ComponentModel.DataAnnotations;

namespace FlightSearch.API.Data.Dto.Auth
{
    public class UserRegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
