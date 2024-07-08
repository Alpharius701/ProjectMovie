using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectMovie.Models
{
    public class FilterViewModel
    {
        public SelectList? ReleaseDates { get; set; }
        public SelectList? Genres { get; set; }
        public SelectList? Ratings { get; set; }
        public int SelectedMovie { get; set; }
        public string SelectedTitle { get; set; }
    }
}
