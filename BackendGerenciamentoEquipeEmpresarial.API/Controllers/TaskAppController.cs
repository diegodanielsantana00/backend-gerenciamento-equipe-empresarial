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
    [Route("api/taskApp")]
    public class TaskAppController : ControllerBase
    {
        private readonly ITaskAppService _taskAppService;
        private readonly IUserRepository _userRepository;
        private readonly IStatusTaskRepository _statusTaskRepository;
        public TaskAppController(ITaskAppService taskAppService, IUserRepository userRepository, IStatusTaskRepository statusTaskRepository)
        {
            _taskAppService = taskAppService;
            _userRepository = userRepository;
            _statusTaskRepository = statusTaskRepository;
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
                StatusTask = await _statusTaskRepository.GetById(request.StatusTask),
                UserCreated = await _userRepository.GetById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value)),
                UserResponsible = await _userRepository.GetById(request.UserResponsible),
                PriorityTask = priority
            };

            if (taskApp.Id == 0 || taskApp.Id == null)
            {
                taskApp.Id = null;
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

    }
}
