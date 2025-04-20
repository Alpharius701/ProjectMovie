using System.ComponentModel.DataAnnotations;

namespace ProjectMovie.Models
{
    public class ChangeEmailViewModel
    {
        [EmailAddress]
        [Display(Name = "Current Email")]
        public string? CurrentEmail { get; set; }

        [Required]
        [EmailAddress]
        public string? NewEmail { get; set; }

        public bool IsEmailConfirmed { get; set; }
    }
}
