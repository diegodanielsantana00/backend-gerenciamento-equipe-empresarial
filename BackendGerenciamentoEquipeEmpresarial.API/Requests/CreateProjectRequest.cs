using BackendGerenciamentoEquipeEmpresarial.Domain.Enum;

namespace BackendGerenciamentoEquipeEmpresarial.API.Requests
{
    public class CreateProjectRequest
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Active { get; set; }
    }
}