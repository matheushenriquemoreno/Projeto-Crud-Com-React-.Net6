using Microsoft.AspNetCore.Identity;

namespace LoginAPI.Services
{
    public class ServicoAutentificacao : IAutentificacao
    {

        private readonly SignInManager<IdentityUser> _gerenciadorLogin;
        private readonly UserManager<IdentityUser> _gerenciadorUsuario;

        public ServicoAutentificacao(SignInManager<IdentityUser> gerenciadorLogin, UserManager<IdentityUser> gerenciadorUsuario)
        {
            _gerenciadorLogin = gerenciadorLogin;
            _gerenciadorUsuario = gerenciadorUsuario;
        }

        public async Task<bool> Atentificar(string email, string password)
        {
            var result = await _gerenciadorLogin.PasswordSignInAsync(email, password, false, false);

            return result.Succeeded;
        }

        public async Task<bool> CriarUsuario(string email, string password)
        {
            var user = new IdentityUser
            {
                UserName = email,
                Email = email,
            };

            var result = await _gerenciadorUsuario.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _gerenciadorLogin.SignInAsync(user, false);
            }

            return result.Succeeded;
        }

        public async Task logout()
        {
            await _gerenciadorLogin.SignOutAsync();
        }
    }
}
