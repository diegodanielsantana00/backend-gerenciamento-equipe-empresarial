
using BackendGerenciamentoEquipeEmpresarial.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendGerenciamentoEquipeEmpresarial.Domain.Entities
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int? Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual User UserOnwer { get; set; }
        public virtual ActiveEnum Active { get; set; }

    }
}
