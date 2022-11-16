using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User?> AuthenticateAsync(string username, string password);
    }
}
