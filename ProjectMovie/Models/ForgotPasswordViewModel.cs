using System.ComponentModel.DataAnnotations;

namespace ProjectMovie.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
