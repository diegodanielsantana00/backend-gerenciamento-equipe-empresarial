
namespace BackendGerenciamentoEquipeEmpresarial.Domain.Entities
{
    public class GroupPermission
    {
       
        public virtual int Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual bool IsAdmin { get; set; }

    }
}
