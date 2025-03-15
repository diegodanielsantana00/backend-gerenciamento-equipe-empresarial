
namespace BackendGerenciamentoEquipeEmpresarial.Domain.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual required string Name { get; set; }
        public virtual required string Email { get; set; }
        public virtual required string Password { get; set; }
        public virtual required GroupPermission GroupPermission { get; set; }
    }
}
