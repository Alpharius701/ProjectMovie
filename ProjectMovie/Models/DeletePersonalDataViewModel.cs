using System.ComponentModel.DataAnnotations;

namespace ProjectMovie.Models
{
    public class DeletePersonalDataViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
