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
        TitleAsc,    // по имени по возрастанию
        TitleDesc,   // по имени по убыванию
        RatingAsc, // по возрасту по возрастанию
        RatingDesc,    // по возрасту по убыванию
        ReleaseDateAsc, // по компании по возрастанию
        ReleaseDateDesc, // по компании по убыванию
        GenreAsc,
        GenreDesc,
    }
}
