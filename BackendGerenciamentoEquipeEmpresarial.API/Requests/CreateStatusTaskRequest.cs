using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Enum;

namespace BackendGerenciamentoEquipeEmpresarial.API.Requests
{
    public class CreateStatusTakRequest
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int order { get; set; }
        public virtual int Project { get; set; }

    }
}