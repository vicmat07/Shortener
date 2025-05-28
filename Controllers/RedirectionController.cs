using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shortener.Persistence;

namespace Shortener.Controllers
{
    [Route("r")]
    [ApiController]
    public class RedirectionController(ApplicationDbContext context) : ControllerBase
    {
        [HttpGet("{code}")]
        public async Task<IActionResult> RedirectToOrignal([FromRoute] string code)
        {
            var shortenedUrl = await context.ShortenedUrls.FirstOrDefaultAsync(x => x.Code == code);

            if(shortenedUrl is null)
            {
                return NotFound();
            }

            return Redirect(shortenedUrl.OriginalUrl);
        }
    }
}
