
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendGerenciamentoEquipeEmpresarial.Domain.Entities
{
    public class StatusTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual int order { get; set; }
        public virtual Project Project { get; set; }

    }
}
