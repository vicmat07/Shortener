
using Shortener.Persistence;

namespace Shortener.Services
{
    public class UniqueCodeManager(ApplicationDbContext context) : IUniqueCodeManager
    {
        public async Task<string> GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString()[..6];
        }
    }
}
