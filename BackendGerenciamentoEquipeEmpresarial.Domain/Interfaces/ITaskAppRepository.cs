using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;

namespace BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces
{
    public interface ITaskAppRepository
    {
        Task<TaskApp> Create(TaskApp task);
        Task<TaskApp> Update(TaskApp task);
        Task<TaskApp> GetById(int id);
        Task<List<TaskApp>> GetAllTask(int idProject, int page, int status, int orderBy);
        Task Delete(int id);


    }
}
