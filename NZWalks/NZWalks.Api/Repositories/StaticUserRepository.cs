using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> Users = new List<User>
        {
            //new User
            //{
            //    Id = Guid.NewGuid(),
            //    UserName = "readonly@user.com",
            //    Password = "readonly@user.com",
            //    Email = "readonly@user.com",
            //    FirstName = "read",
            //    LastName = "only",
            //    Roles = new List<string> { "reader" }
            //},
            //new User
            //{
            //    Id = Guid.NewGuid(),
            //    UserName = "readwrite@user.com",
            //    Password = "readwrite@user.com",
            //    Email = "readwrite@user.com",
            //    FirstName = "read",
            //    LastName = "write",
            //    Roles = new List<string> { "reader", "writer" }
            //}
        };

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = Users.Find(x => x.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);

            return user!;
        }
    }
}
