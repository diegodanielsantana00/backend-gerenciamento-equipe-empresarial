using BackendGerenciamentoEquipeEmpresarial.Application.Interfaces;
using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces;

namespace BackendGerenciamentoEquipeEmpresarial.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IGroupPermissionRepository _groupPermissionRepository;

        public ProjectService(IProjectRepository projectRepository, IGroupPermissionRepository groupPermissionRepository)
        {
            _projectRepository = projectRepository;
            _groupPermissionRepository = groupPermissionRepository;
        }

        public async Task<UserProject> AddUserInProject(User user, Project project, GroupPermission groupPermission)
        {
            return await _projectRepository.AddUserInProject(user, project, groupPermission);
        }

        public async Task<IEnumerable<Project>> GetAllByIdUser(int idUser)
        {
            return await _projectRepository.GetAllByIdUser(idUser);
        }

        public async Task<Project> Save(Project project)
        {
            var projectSave = await _projectRepository.Save(project);
            if (projectSave != null)
            {
               var groupPemission = await _groupPermissionRepository.GetById(1);
               await _projectRepository.AddUserInProject(project.UserOnwer, project, groupPemission);
            }
            return projectSave;
        }

        public async Task<Project> Update(Project project)
        {
            return await _projectRepository.Update(project);
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _projectRepository.GetProjectById(id);
        }
    }
}
