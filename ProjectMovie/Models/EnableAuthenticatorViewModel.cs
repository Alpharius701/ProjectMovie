using System.ComponentModel.DataAnnotations;

namespace ProjectMovie.Models
{
    public class EnableAuthenticatorViewModel
    {
        public string? SharedKey { get; set; }
        public string? AuthenticatorUri { get; set; }

        [Required]
        [StringLength(7, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Verification Code")]
        public string? Code { get; set; }
    }
}
