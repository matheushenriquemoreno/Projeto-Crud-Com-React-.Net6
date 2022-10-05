namespace LoginAPI.Services
{
    public interface IAutentificacao
    {
        Task<bool> Atentificar(string email, string password);
        Task<bool> CriarUsuario(string email, string password);
        Task logout();
    }
}
