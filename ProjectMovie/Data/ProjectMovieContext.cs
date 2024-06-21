using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectMovie.Models;

namespace ProjectMovie.Data
{
    public class ProjectMovieContext : DbContext
    {
        public ProjectMovieContext (DbContextOptions<ProjectMovieContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectMovie.Models.Movie> Movie { get; set; } = default!;
    }
}
