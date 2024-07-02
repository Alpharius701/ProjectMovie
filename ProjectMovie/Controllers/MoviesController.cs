using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMovie.Data;
using ProjectMovie.Models;

namespace ProjectMovie.Controllers
{
    public class MoviesController(ProjectMovieContext context, IWebHostEnvironment hostEnvironment) : Controller
    {
        private readonly ProjectMovieContext _context = context;
        private readonly IWebHostEnvironment _hostEnvironment = hostEnvironment;

        // GET: Movies
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            if (_context.Movie == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            var genreQuery = _context.Movie
                .OrderBy(m => m.Genre)
                .Select(m => m.Genre);
            var movies = _context.Movie.Select(m => m);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                movies = movies.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrWhiteSpace(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from over-posting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Rating,PosterName,PosterFormFile")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                // Save poster image to wwwroot/Posters
                string wwwwRootPath = _hostEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(movie.PosterFormFile!.FileName);
                string extension = Path.GetExtension(movie.PosterFormFile.FileName);
                movie.PosterName = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwwRootPath, "Posters", filename);

                await using (FileStream fileStream = new(path, FileMode.Create))
                {
                    await movie.PosterFormFile.CopyToAsync(fileStream);
                }

                // Insert record
                await _context.AddAsync(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from over-posting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Rating,PosterName,PosterFormFile")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Delete poster image
                    string posterPath = Path.Combine(_hostEnvironment.WebRootPath, "Posters", movie.PosterName!);
                    if (System.IO.File.Exists(posterPath))
                        System.IO.File.Delete(posterPath);

                    // Save poster image
                    string wwwwRootPath = _hostEnvironment.WebRootPath;
                    string filename = Path.GetFileNameWithoutExtension(movie.PosterFormFile!.FileName);
                    string extension = Path.GetExtension(movie.PosterFormFile.FileName);
                    movie.PosterName = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwwRootPath, "Posters", filename);

                    await using (FileStream fileStream = new(path, FileMode.Create))
                    {
                        await movie.PosterFormFile.CopyToAsync(fileStream);
                    }

                    // Update the record
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) when (!MovieExists(movie.Id))
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                // Delete poster image
                string posterPath = Path.Combine(_hostEnvironment.WebRootPath, "Posters", movie.PosterName!);
                if (System.IO.File.Exists(posterPath))
                    System.IO.File.Delete(posterPath);

                // Delete the record
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
