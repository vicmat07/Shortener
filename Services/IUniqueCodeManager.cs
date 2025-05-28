namespace Shortener.Services
{
    public interface IUniqueCodeManager
    {
        Task<string> GenerateUniqueCode();
    }
}
