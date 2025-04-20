using System.ComponentModel.DataAnnotations;

namespace ProjectMovie.Models
{
    public class ResendEmailConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
