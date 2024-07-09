namespace ProjectMovie.Models
{
    public class SortViewModel(SortState sortOrder)
    {
        public SortState TitleSort { get; } = sortOrder
            == SortState.TitleAsc ? SortState.TitleDesc : SortState.TitleAsc;
        public SortState RatingSort { get; } = sortOrder
            == SortState.RatingAsc ? SortState.RatingDesc : SortState.RatingAsc;
        public SortState ReleaseDateSort { get; } = sortOrder
            == SortState.ReleaseDateAsc ? SortState.ReleaseDateDesc : SortState.ReleaseDateAsc;
        public SortState GenreSort { get; } = sortOrder
            == SortState.GenreAsc ? SortState.GenreDesc : SortState.GenreAsc;
        public SortState Current { get; } = sortOrder;
    }

    public enum SortState
    {
        TitleAsc,    // by title ascending
        TitleDesc,   // by title descending
        RatingAsc,    // by rating ascending
        RatingDesc,    // by rating descending
        ReleaseDateAsc,    // by release date ascending
        ReleaseDateDesc,   // by release date descending
        GenreAsc,    // by genre ascending
        GenreDesc,    // by genre descending
    }
}
