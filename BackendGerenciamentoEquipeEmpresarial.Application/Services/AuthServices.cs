using BackendGerenciamentoEquipeEmpresarial.Application.Interfaces;
using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces;

namespace BackendGerenciamentoEquipeEmpresarial.Application.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IGroupPermissionRepository _groupPermissionRepository;

        public AuthServices(IUserRepository userRepository, IGroupPermissionRepository groupPermissionRepository)
        {
            _userRepository = userRepository;
            _groupPermissionRepository = groupPermissionRepository;
        }
        public async Task<bool> IsRegisterWithEmail(string email)
        {
            User user = await _userRepository.GetByEmail(email);
            return user != null;
        }
        
        public async Task<User> Register(User user)
        {
            //user.GroupPermission = await _groupPermissionRepository.GetById(user.GroupPermission.Id);
            return await _userRepository.Save(user);
        }

        public async Task<User> Login(string email, string password)
        {
            string passwordCripto = BCrypt.Net.BCrypt.HashPassword(password); ;
            User user =  await _userRepository.GetByEmail(email);
            if (user != null && user.CheckPassword(password))
            {
                return user;
            }
            return null;
        }
    }
}
