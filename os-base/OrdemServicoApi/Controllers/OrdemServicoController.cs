using Microsoft.AspNetCore.Mvc;
using OrdemServicoApi.Data;
using OrdemServicoApi.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace OrdemServicoApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdemServicoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdemServicoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] OrdemServico os)
        {
            try
            {
                var userEmail = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userEmail))
                    return Unauthorized("Usuário não identificado no token.");

                var usuario = _context.Users.FirstOrDefault(u => u.Email == userEmail);

                if (usuario == null)
                    return Unauthorized("Usuário não encontrado no banco de dados.");

                os.UserId = usuario.Id;

                await _context.OrdensServico.AddAsync(os);
                await _context.SaveChangesAsync();

                return Ok(os);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Erro ao criar OS: {ex.Message}" });
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var ordens = _context.OrdensServico.ToList();
            return Ok(ordens);
        }
    }
}
