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
            CreateNewMovieEntity(title: "Aliens",
                                 releaseDate: "1989-7-18",
                                 genre: "Sci-Fi",
                                 rating: "R",
                                 posterFileName: "Aliens.jpg"),

            CreateNewMovieEntity(title: "Ant-Man",
                                 releaseDate: "2015-2-23",
                                 genre: "Superhero fiction",
                                 rating: "PG-13",
                                 posterFileName: "AntMan.jpg"),

            CreateNewMovieEntity(title: "Beetlejuice",
                                 releaseDate: "1988-3-30",
                                 genre: "Comedy",
                                 rating: "PG",
                                 posterFileName: "Beetlejuice.jpg"),

            CreateNewMovieEntity(title: "Birds of Prey",
                                 releaseDate: "2020-2-7",
                                 genre: "Superhero fiction",
                                 rating: "R",
                                 posterFileName: "BirdsOfPrey.jpg"),

            CreateNewMovieEntity(title: "Black Widow",
                                 releaseDate: "2021-7-9",
                                 genre: "Superhero fiction",
                                 rating: "PG-13",
                                 posterFileName: "BlackWidow.jpg"),

            CreateNewMovieEntity(title: "Captain America: The Winter Soldier",
                                 releaseDate: "2014-4-4",
                                 genre: "Superhero fiction",
                                 rating: "PG-13",
                                 posterFileName: "CaptainAmericaTheWinterSoldier.jpg"),

            CreateNewMovieEntity(title: "Color Out of Space",
                                 releaseDate: "2020-1-24",
                                 genre: "Horror",
                                 rating: "Unrated",
                                 posterFileName: "ColorOutOfSpace.jpg"),

            CreateNewMovieEntity(title: "Drive",
                                 releaseDate: "2011-9-16",
                                 genre: "Action",
                                 rating: "R",
                                 posterFileName: "Drive.jpg"),

            CreateNewMovieEntity(title: "F9: The Fast Saga",
                                 releaseDate: "2021-6-25",
                                 genre: "Action",
                                 rating: "PG-13",
                                 posterFileName: "F9TheFastSaga.jpg"),

            CreateNewMovieEntity(title: "Ghostbusters",
                                 releaseDate: "1984-6-8",
                                 genre: "Comedy",
                                 rating: "PG",
                                 posterFileName: "Ghostbusters.jpg"),

            CreateNewMovieEntity(title: "Ghostbusters: Frozen Empire",
                                 releaseDate: "2024-3-22",
                                 genre: "Comedy",
                                 rating: "PG-13",
                                 posterFileName: "GhostbustersFrozenEmpire.jpg"),

            CreateNewMovieEntity(title: "Guardians of the Galaxy",
                                 releaseDate: "2014-8-7",
                                 genre: "Superhero fiction",
                                 rating: "PG-13",
                                 posterFileName: "GuardiansOfTheGalaxy.jpg"),

            CreateNewMovieEntity(title: "Iron Man",
                                 releaseDate: "2008-5-2",
                                 genre: "Superhero fiction",
                                 rating: "PG-13",
                                 posterFileName: "IronMan.jpg"),

            CreateNewMovieEntity(title: "Iron Man 2",
                                 releaseDate: "2010-5-7",
                                 genre: "Superhero fiction",
                                 rating: "PG-13",
                                 posterFileName: "IronMan2.jpg"),

            CreateNewMovieEntity(title: "Iron Man 3",
                                 releaseDate: "2013-5-1",
                                 genre: "Superhero fiction",
                                 rating: "PG-13",
                                 posterFileName: "IronMan3.jpg"),

            CreateNewMovieEntity(title: "Jhon Wick",
                                 releaseDate: "2014-10-24",
                                 genre: "Action",
                                 rating: "R",
                                 posterFileName: "JohnWick.jpg"),

            CreateNewMovieEntity(title: "Jumanji",
                                 releaseDate: "2019-12-13",
                                 genre: "Comedy",
                                 rating: "PG-13",
                                 posterFileName: "JumanjiTheNextLevel.jpg"),

            CreateNewMovieEntity(title: "Jupiter Ascending",
                                 releaseDate: "2015-2-6",
                                 genre: "Sci-Fi",
                                 rating: "PG-13",
                                 posterFileName: "JupiterAscending.jpg"),

            CreateNewMovieEntity(title: "Lamborghini: The Man Behind the Legend",
                                 releaseDate: "2022-10-23",
                                 genre: "Biographical drama",
                                 rating: "R",
                                 posterFileName: "LamborghiniTheManBehindTheLegend.jpg"),

            CreateNewMovieEntity(title: "Mortal Engines",
                                 releaseDate: "2018-12-14",
                                 genre: "Adventure",
                                 rating: "PG-13",
                                 posterFileName: "MortalEngines.jpg"),

            CreateNewMovieEntity(title: "Oppenheimer",
                                 releaseDate: "2023-7-21",
                                 genre: "Biographical thriller",
                                 rating: "R",
                                 posterFileName: "Oppenheimer.jpg"),

            CreateNewMovieEntity(title: "The Dark Knight",
                                 releaseDate: "2008-7-18",
                                 genre: "Superhero fiction",
                                 rating: "PG-13",
                                 posterFileName: "TheDarkKnight.jpg"),

            CreateNewMovieEntity(title: "The Finest Hours",
                                 releaseDate: "2016-1-29",
                                 genre: "Thriller",
                                 rating: "PG-13",
                                 posterFileName: "TheFinestHours.jpg"),

            CreateNewMovieEntity(title: "The Hangover",
                                 releaseDate: "2009-6-5",
                                 genre: "Comedy",
                                 rating: "R",
                                 posterFileName: "TheHangover.jpg"),

            CreateNewMovieEntity(title: "The Lodge",
                                 releaseDate: "2019-1-25",
                                 genre: "Horror",
                                 rating: "R",
                                 posterFileName: "TheLodge.jpg"),

            CreateNewMovieEntity(title: "The Maze Runner",
                                 releaseDate: "2014-9-19",
                                 genre: "Sci-Fi",
                                 rating: "PG-13",
                                 posterFileName: "TheMazeRunner.jpg"),

            CreateNewMovieEntity(title: "The Wolf of Wall Street",
                                 releaseDate: "2013-12-25",
                                 genre: "Comedy",
                                 rating: "R",
                                 posterFileName: "TheWolfOfWallStreet.jpg"),

            CreateNewMovieEntity(title: "Thor: Love and Thunder",
                                 releaseDate: "2022-7-8",
                                 genre: "Superhero fiction",
                                 rating: "PG-13",
                                 posterFileName: "ThorLoveAndThunder.jpg"),

            CreateNewMovieEntity(title: "Vivarium",
                                 releaseDate: "2019-9-19",
                                 genre: "Thriller",
                                 rating: "R",
                                 posterFileName: "Vivarium.jpg"),

            CreateNewMovieEntity(title: "We're the Millers",
                                 releaseDate: "2013-8-7",
                                 genre: "Comedy",
                                 rating: "R",
                                 posterFileName: "WeReTheMillers.jpg"),

            CreateNewMovieEntity(title: "Who Am I",
                                 releaseDate: "2014-9-25",
                                 genre: "Superhero fiction",
                                 rating: "R",
                                 posterFileName: "WhoAmI.jpg")

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
