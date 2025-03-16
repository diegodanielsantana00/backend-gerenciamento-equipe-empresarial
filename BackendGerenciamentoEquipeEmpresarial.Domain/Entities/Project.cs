
using BackendGerenciamentoEquipeEmpresarial.Domain.Enum;

namespace BackendGerenciamentoEquipeEmpresarial.Domain.Entities
{
    public class Project
    {
       
        public virtual int? Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual User UserOnwer { get; set; }
        public virtual ActiveEnum Active { get; set; }

    }
}
