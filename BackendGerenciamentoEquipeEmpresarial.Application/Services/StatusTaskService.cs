using BackendGerenciamentoEquipeEmpresarial.Application.Interfaces;
using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces;

namespace BackendGerenciamentoEquipeEmpresarial.Application.Services
{
    public class StatusTaskService : IStatusTaskService
    {
        private readonly IStatusTaskRepository _statusTaskRepository;

        public StatusTaskService(IStatusTaskRepository statusTaskRepository)
        {
            _statusTaskRepository = statusTaskRepository;
        }

        public async Task<StatusTask> Create(StatusTask task)
        {
            return await _statusTaskRepository.Create(task);
        }

        public Task<StatusTask> Update(StatusTask task)
        {
            return _statusTaskRepository.Update(task);
        }

        public async Task<IEnumerable<StatusTask>> GetAllStatusByProject(int idProject)
        {
            return await _statusTaskRepository.GetAllStatusByProject(idProject);
        }

    }
}
