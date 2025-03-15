namespace BackendGerenciamentoEquipeEmpresarial.Application.Interfaces
{
    public interface IAuthServices
    {
        string GenerateToken();
        Task<bool> Register();

    }
}
