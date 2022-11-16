using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NZWalksDbContext context;

        public UserRepository(NZWalksDbContext context)
        {
            this.context = context;
        }
        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower() && x.Password == password);

            if (user is null) return null!;

            var userRoles = await context.UserRoles.Where(x => x.UserId == user.Id).ToListAsync();

            if (userRoles.Any())
            {
                user.Roles = new List<string>();

                foreach (var role in userRoles)
                {
                    var r = await context.Roles.FirstOrDefaultAsync(x => x.Id == role.RoleId);
                    if (r is not null)
                        user.Roles.Add(r.Name);
                }
            }

            user.Password = null!;
            return user;
        }
    }
}
