namespace ProjectMovie.Models
{
    public class IndexViewModel(IEnumerable<Movie> movies, PageViewModel pageViewModel,
            FilterViewModel filterViewModel, SortViewModel sortViewModel)
    {
        public IEnumerable<Movie> Movies { get; } = movies;
        public PageViewModel PageViewModel { get; } = pageViewModel;
        public FilterViewModel FilterViewModel { get; } = filterViewModel;
        public SortViewModel SortViewModel { get; } = sortViewModel;
    }
}
