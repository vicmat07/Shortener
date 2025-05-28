using Microsoft.AspNetCore.Mvc;
using Shortener.DTOs;
using Shortener.Models;
using Shortener.Persistence;
using Shortener.Services;

namespace Shortener.Controllers
{
    [Route("api/shortener")]
    [ApiController]
    public class ShortenerController(IUniqueCodeManager urlShortenerService, ApplicationDbContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ShortenUrl([FromBody] ShortenUrlRequest request)
        {
            if (!Uri.TryCreate(request.Url, UriKind.Absolute, out _))
            {
                return BadRequest($"Invalid Url {request.Url}");
            }

            var uniqueCode = await urlShortenerService.GenerateUniqueCode();
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var shortenedUrl = $"{baseUrl}/r/{uniqueCode}";
            var entry = new ShortenedUrl
            {
                ShortUrl = shortenedUrl,
                OriginalUrl = request.Url,
                Code = uniqueCode
            };

            await context.ShortenedUrls.AddAsync(entry);
            await context.SaveChangesAsync();

            return Ok(new { ShortenedUrl = shortenedUrl });
        }
    }
}
