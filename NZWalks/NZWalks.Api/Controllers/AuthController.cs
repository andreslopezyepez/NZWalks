using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository repository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository repository, ITokenHandler tokenHandler)
        {
            this.repository = repository;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(Models.Dto.LoginRequest request)
        {
            var user = await repository.AuthenticateAsync(request.UserName, request.Password);

            if (user is not null)
            {
                //Generate JWT Token
                var token = await tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }

            return BadRequest($"{nameof(request.UserName)} or {nameof(request.Password)} is incorrect");
        }
    }
}
