using BackendGerenciamentoEquipeEmpresarial.API.Requests;
using BackendGerenciamentoEquipeEmpresarial.Application.Interfaces;
using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Enum;
using BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace BackendGerenciamentoEquipeEmpresarial.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IProjectService _projectService;
        public UserController(IUserRepository userRepository, IProjectService projectService)
        {
            _userRepository = userRepository;
            _projectService = projectService;
        }

        [Authorize]
        [HttpGet("GetAllUsersByProject")]
        public async Task<IActionResult> GetAllUsersByProject(int idProject)
        {
            var users = await _projectService.GetUserProjectByProject(idProject);
            return Ok(new { success = true, users });
        }

    }
}
