
using BackendGerenciamentoEquipeEmpresarial.Domain.Enum;

namespace BackendGerenciamentoEquipeEmpresarial.Domain.Entities
{
    public class TaskApp
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual User UserCreated { get; set; }
        public virtual User UserResponsible { get; set; }
        public virtual StatusTask StatusTask { get; set; }
        public virtual PriorityTaskEnum PriorityTask { get; set; }
        

    }
}
