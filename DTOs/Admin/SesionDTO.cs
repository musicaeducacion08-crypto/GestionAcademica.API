namespace GestionAcademica.API.DTOs.Admin;

public class SesionDTO
{
    public int IdSesion { get; set; }
    public string? TokenSesion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaExpiracion { get; set; }
    public string? DireccionIP { get; set; }
    public string? UserAgent { get; set; }
    public bool Estado { get; set; }
    public int IdUsuario { get; set; }
    public string? NombreUsuario { get; set; }
}