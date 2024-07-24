using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectMovie.Models;

namespace ProjectMovie.Data
{
    public class ProjectMovieContext(DbContextOptions<ProjectMovieContext> options) : IdentityDbContext(options)
    {
        public DbSet<ProjectMovie.Models.Movie> Movie { get; set; } = default!;
    }
}
