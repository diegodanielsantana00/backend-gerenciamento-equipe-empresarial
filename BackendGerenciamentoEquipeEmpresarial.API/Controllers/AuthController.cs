using BackendGerenciamentoEquipeEmpresarial.API.Requests;
using BackendGerenciamentoEquipeEmpresarial.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BackendGerenciamentoEquipeEmpresarial.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (
                !string.IsNullOrEmpty(request.Name) && 
                !string.IsNullOrEmpty(request.Email) && 
                !string.IsNullOrEmpty(request.Password)
                )
            {
                Console.Write("Usuario Registrado");
                var token = _jwtService.GenerateToken("1", "Admin");
                return Ok(new { success = true, token });
            }

            return Unauthorized(new { success = false, message = "Credenciais inválidas" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Username == "admin" && request.Password == "123456")
            {
                var token = _jwtService.GenerateToken("1", "Admin");
                return Ok(new { success = true, token });
            }

            return Unauthorized(new { success = false, message = "Credenciais inválidas" });
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult GetUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            return Ok(new { userId, role });
        }
    }
}
