using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectMovie.Data;
using ProjectMovie.Models;
using System;
using System.Globalization;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new ProjectMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ProjectMovieContext>>());
        // Look for any movies.
        if (context.Movie.Any())
        {
            return;   // DB has been seeded
        }
        context.Movie.AddRange(
            new Movie
            {
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989-2-12", new CultureInfo("ru-RU")),
                Genre = "Romantic Comedy",
                Rating = "R",
                PosterFileName = "WhenHarryMetSally.jpg"
            },
            new Movie
            {
                Title = "Ghostbusters",
                ReleaseDate = DateTime.Parse("1984-3-13", new CultureInfo("ru-RU")),
                Genre = "Comedy",
                Rating = "R",
                PosterFileName = "ghostbuster_poster.jpg"
            },
            new Movie
            {
                Title = "Ghostbusters 2",
                ReleaseDate = DateTime.Parse("1986-2-23", new CultureInfo("ru-RU")),
                Genre = "Comedy",
                Rating = "R",
                PosterFileName = "Ghostbusters2.jpg"
            },
            new Movie
            {
                Title = "Rio Bravo",
                ReleaseDate = DateTime.Parse("1959-4-15", new CultureInfo("ru-RU")),
                Genre = "Western",
                Rating = "R",
                PosterFileName = "RioBravo.jpg"
            }
        );
        context.SaveChanges();
    }
}
