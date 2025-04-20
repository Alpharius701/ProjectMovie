using System.ComponentModel.DataAnnotations;

namespace ProjectMovie.Models
{
    public class ProfileViewModel
    {
        public string? Username { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }
    }
}
