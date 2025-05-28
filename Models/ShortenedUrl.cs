namespace Shortener.Models
{
    public class ShortenedUrl
    {
        public Guid Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.Now;
        public string Code { get; set; }
    }
}
