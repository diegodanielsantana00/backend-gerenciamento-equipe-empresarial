using BackendGerenciamentoEquipeEmpresarial.API.Requests;
using BackendGerenciamentoEquipeEmpresarial.Application.Interfaces;
using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace BackendGerenciamentoEquipeEmpresarial.API.Controllers
{
    [ApiController]
    [Route("api/taskApp")]
    public class TaskAppController : ControllerBase
    {
        private readonly ITaskAppService _taskAppService;

        public TaskAppController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        [Authorize]
        [HttpPost("createOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] CreateTaskAppRequest request)
        {
            Enum.TryParse<PriorityTaskEnum>(request.PriorityTask.ToString(), true, out PriorityTaskEnum priority);

            TaskApp taskApp = new TaskApp()
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                UserCreated = new User() { Id = request.UserCreated },
                UserResponsible = new User() { Id = request.UserResponsible },
                PriorityTask = priority
            };
            if (taskApp.Id == 0 && taskApp.Id == null)
            {
                TaskApp taskAppSave = await _taskAppService.Create(taskApp);
                if (taskAppSave != null)
                {
                    return Ok(new { success = true, msg = "Tarefa criada com sucesso!" });
                }
            }
            else
            {
                TaskApp taskAppSave = await _taskAppService.Update(taskApp);
                if (taskAppSave != null)
                {
                    return Ok(new { success = true, msg = "Tarefa atualizada com sucesso!" });
                }
            }


                return BadRequest(new { success = false, message = "Credenciais inválidas" });
        }

        [Authorize]
        [HttpPatch("updateStatus")]
        public async Task<IActionResult> updateStatus([FromBody] int idTask, int status)
        {
            
            if (await _taskAppService.UpdateStatus(idTask, status))
            {
                return Ok(new { success = true, msg = "Status da tarefa atualizada com sucesso!" });
            }

            return BadRequest(new { success = false, message = "Credenciais inválidas" });
        }

        //
        //[HttpGet("me")]
        //public IActionResult GetUser()
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    var role = User.FindFirst(ClaimTypes.Role)?.Value;
        //    return Ok(new { userId, role });
        //}
    }
}
