using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OrdemServicoApi.Models;
using OrdemServicoApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrdemServicoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IConfiguration _config;

        public AuthController(AuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var loggedUser = _authService.Login(user.Email, user.Password);
            if (loggedUser == null)
                return Unauthorized(new { message = "Credenciais inválidas" });

            var token = GenerateJwtToken(loggedUser);

            return Ok(new
            {
                user = loggedUser,
                token = token
            });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var newUser = _authService.Register(user);
            return Ok(newUser);
        }

        private string GenerateJwtToken(User user)
        {
            var jwtKey = _config["Jwt:Key"] ?? "chave-super-secreta-123";
            var jwtIssuer = _config["Jwt:Issuer"] ?? "OrdemServicoApi";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("userId", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtIssuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(4),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
