using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;

namespace BackendGerenciamentoEquipeEmpresarial.Application.Interfaces
{
    public interface IProjectService
    {
        Task<Project> Save(Project project);
        Task<Project> Update(Project project);
        Task<IEnumerable<Project>> GetAllByIdUser(int idUser);
        Task<UserProject> AddUserInProject(User user, Project project, GroupPermission groupPermission);
    }
}
