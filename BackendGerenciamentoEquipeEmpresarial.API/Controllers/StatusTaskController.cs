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

        public StatusTaskController(IStatusTaskService statusTaskService)
        {
            _statusTaskService = statusTaskService;
        }

        [Authorize]
        [HttpPost("createOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] StatusTask request)
        {

            if (request.Id == 0 || request.Id == null)
            {
                StatusTask taskAppSave = await _statusTaskService.Create(request);
                if (taskAppSave != null)
                {
                    return Ok(new { success = true, msg = "Status criado com sucesso!" });
                }
            }
            else
            {
                StatusTask taskAppSave = await _statusTaskService.Update(request);
                if (taskAppSave != null)
                {
                    return Ok(new { success = true, msg = "Status atualizado com sucesso!" });
                }
            }

            return BadRequest(new { success = false, message = "Credenciais inválidas" });
        }
    }
}
