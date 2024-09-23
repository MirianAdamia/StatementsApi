using Microsoft.AspNetCore.Mvc;

namespace StatementsApi.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly ITokenService _tokenService;
            private readonly IConfiguration _configuration;
            public AuthController(ITokenService tokenService, IConfiguration configuration)
            {
                _tokenService = tokenService;
                _configuration = configuration;
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] LoginRequest request)
            {
            if (request.Username == _configuration["LoginCredentionals:User"] && request.Password == _configuration["LoginCredentionals:Password"])
                {
                    var token = _tokenService.GenerateToken(request.Username);
                    return Ok(new { Token = token });
                }

                return Unauthorized();
            }
        }

        public class LoginRequest
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }
    }
