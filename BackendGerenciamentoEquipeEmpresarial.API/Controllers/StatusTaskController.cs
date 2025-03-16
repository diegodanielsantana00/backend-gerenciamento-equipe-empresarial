using BackendGerenciamentoEquipeEmpresarial.API.Requests;
using BackendGerenciamentoEquipeEmpresarial.Application.Interfaces;
using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendGerenciamentoEquipeEmpresarial.API.Controllers
{
    [ApiController]
    [Route("api/statusTask")]
    public class StatusTaskController : ControllerBase
    {
        private readonly IStatusTaskService _statusTaskService;
        private readonly IProjectService _projectService;

        public StatusTaskController(IStatusTaskService statusTaskService, IProjectService projectService)
        {
            _statusTaskService = statusTaskService;
            _projectService = projectService;
        }

        [Authorize]
        [HttpPost("createOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] CreateStatusTakRequest request)
        {
            StatusTask statusSave = new StatusTask() { 
                Id = request.Id,
                Name = request.Name,
                Project = await _projectService.GetProjectById(request.Project),
                order = request.Id
            };
            if (request.Id == 0 || request.Id == null)
            {
                StatusTask taskAppSave = await _statusTaskService.Create(statusSave);
                if (taskAppSave != null)
                {
                    return Ok(new { success = true, msg = "Status criado com sucesso!" });
                }
            }
            else
            {
                StatusTask taskAppSave = await _statusTaskService.Update(statusSave);
                if (taskAppSave != null)
                {
                    return Ok(new { success = true, msg = "Status atualizado com sucesso!" });
                }
            }

            return BadRequest(new { success = false, message = "Credenciais inválidas" });
        }

        [Authorize]
        [HttpGet("getAllStatusByProject")]
        public async Task<IActionResult> getAllStatusByProject(int idProject)
        {
            var status = await _statusTaskService.GetAllStatusByProject(idProject);
            return Ok(new { success = true, status });
        }
    }
}
