
using BackendGerenciamentoEquipeEmpresarial.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendGerenciamentoEquipeEmpresarial.Domain.Entities
{
    public class TaskApp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int? Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual User UserCreated { get; set; }
        public virtual User UserResponsible { get; set; }
        public virtual StatusTask StatusTask { get; set; }
        public virtual Project Project { get; set; }
        public virtual PriorityTaskEnum PriorityTask { get; set; }
        

    }
}
