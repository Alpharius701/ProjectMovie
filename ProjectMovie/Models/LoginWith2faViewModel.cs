using System.ComponentModel.DataAnnotations;

namespace ProjectMovie.Models
{
    public class LoginWith2faViewModel
    {
        [Required]
        [StringLength(6, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "The {0} must be a number.")]
        [Display(Name = "Authenticator code")]
        public string? TwoFactorCode { get; set; }

        [Display(Name = "Remember this machine")]
        public bool RememberMachine { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
