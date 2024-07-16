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
            CreateNewMovieEntity(title: "When Harry Met Sally",
                                 releaseDate: "1989-2-12",
                                 genre: "Romantic Comedy",
                                 rating: "R",
                                 posterFileName: "WhenHarryMetSally.jpg"),

            CreateNewMovieEntity(title: "Ghostbusters",
                                 releaseDate: "1984-6-8",
                                 genre: "Comedy",
                                 rating: "R",
                                 posterFileName: "Ghostbuster.jpg"),

            CreateNewMovieEntity(title: "Ghostbusters 2",
                                 releaseDate: "1986-2-23",
                                 genre: "Comedy",
                                 rating: "R",
                                 posterFileName: "Ghostbusters2.jpg"),

            CreateNewMovieEntity(title: "Rio Bravo",
                                 releaseDate: "1959-4-15",
                                 genre: "Western",
                                 rating: "R",
                                 posterFileName: "RioBravo.jpg")
        );
        context.SaveChanges();
    }

    private static Movie CreateNewMovieEntity(string title,
                                string releaseDate,
                                string genre,
                                string rating,
                                string posterFileName)
    {
        return new Movie
        {
            Title = title,
            ReleaseDate = DateTime.Parse(releaseDate, new CultureInfo("ru-RU")),
            Genre = genre,
            Rating = rating,
            PosterFileName = posterFileName
        };
    }
}
