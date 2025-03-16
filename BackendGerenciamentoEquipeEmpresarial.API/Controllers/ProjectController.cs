using BackendGerenciamentoEquipeEmpresarial.API.Requests;
using BackendGerenciamentoEquipeEmpresarial.Application.Interfaces;
using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Enum;
using BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BackendGerenciamentoEquipeEmpresarial.API.Controllers
{
    [ApiController]
    [Route("api/project")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IUserRepository _userRepository;

        public ProjectController(IProjectService projectService, IUserRepository userRepository)
        {
            _projectService = projectService;
            _userRepository = userRepository;
        }

        [Authorize]
        [HttpPost("createOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] CreateProjectRequest request)
        {
            Enum.TryParse<ActiveEnum>(request.Active.ToString(), true, out ActiveEnum active);


            Project project = new Project()
            {
                Id = request.Id,
                UserOnwer = await _userRepository.GetById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value)),
                Active = active,
                Name = request.Name
            };

            if (project.Id == 0 || project.Id == null)
            {
                project.Id = null;
                Project taskAppSave = await _projectService.Save(project);
                if (taskAppSave != null)
                {
                    return Ok(new { success = true, msg = "Projet salvo com sucesso!" });
                }
            }
            else
            {
                Project taskAppSave = await _projectService.Update(project);
                if (taskAppSave != null)
                {
                    return Ok(new { success = true, msg = "Projet atualizado com sucesso!" });
                }
            }


            return BadRequest(new { success = false, message = "Credenciais inválidas" });
        }

        [Authorize]
        [HttpGet("getAllByUser")]
        public async Task<IActionResult> getAllByUser()
        {
            var UserOnwer = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var projects = await _projectService.GetAllByIdUser(UserOnwer);
            return Ok(new { success = true, projects });
        }


    }
}
