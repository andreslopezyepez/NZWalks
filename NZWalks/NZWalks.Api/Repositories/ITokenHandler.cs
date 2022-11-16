using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
