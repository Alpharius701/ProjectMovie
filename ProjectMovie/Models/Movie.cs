using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$")]
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(7)]
        [Required]
        public string? Rating { get; set; }
        [DisplayName("Poster")]
        public string? PosterFileName { get; set; }
        [NotMapped]
        [DisplayName("Upload poster image")]
        [Required]
        public IFormFile? PosterFormFile { get; set; }
    }
}
