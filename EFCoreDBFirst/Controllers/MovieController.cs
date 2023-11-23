using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDBFirst.Controllers
{
        [ApiController]
        [Route("api/movies")]
    public class MovieController : Controller
    {
        private readonly MOVIES_W3Context _context;

        public MovieController(MOVIES_W3Context context) 
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return Ok(movies);
        }
    }
}
