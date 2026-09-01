namespace GestionAcademica.API.DTOs.Auth;

public class AuthResponseDTO
{
    public int IdUsuario { get; set; }
    public string? Nombre { get; set; }
    public string? Rol { get; set; }
    public string? Token { get; set; }
}