namespace GestionAcademica.API.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<(int idUsuario, string nombre, string rol)> LoginAsync(string nombreUsuario, string clave);
}