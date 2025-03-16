using BackendGerenciamentoEquipeEmpresarial.API.Requests;
using BackendGerenciamentoEquipeEmpresarial.Application.Interfaces;
using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
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
        private readonly IAuthServices _authService;

        public AuthController(IJwtService jwtService, IAuthServices authService)
        {
            _jwtService = jwtService;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (
                !string.IsNullOrEmpty(request.Name) && 
                !string.IsNullOrEmpty(request.Email) && 
                !string.IsNullOrEmpty(request.Password)
                )
            {
                if (!(await _authService.IsRegisterWithEmail(request.Email)))
                {

                    User userSave = new User() { Email = request.Email, Name = request.Name };
                    userSave.SetPassword(request.Password);
                    userSave = await _authService.Register(userSave);
                    var token = _jwtService.GenerateToken(userSave.Id.ToString(), "Membro");
                    return Ok(new { success = true, token });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Usuário já cadastrado" });
                }
            }

            return Unauthorized(new { success = false, message = "Credenciais inválidas" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            User user = await _authService.Login(request.Username, request.Password);

            if (user != null)
            {
                var token = _jwtService.GenerateToken(user.Id.ToString(), "Admin");
                return Ok(new { success = true, token });
            }

            return Unauthorized(new { success = false, message = "Credenciais inválidas" });
        }

        //[Authorize]
        //[HttpGet("me")]
        //public IActionResult GetUser()
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    var role = User.FindFirst(ClaimTypes.Role)?.Value;
        //    return Ok(new { userId, role });
        //}
    }
}
