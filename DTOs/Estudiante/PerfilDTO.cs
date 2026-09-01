namespace GestionAcademica.API.DTOs.Estudiante;

public class PerfilDTO
{
    public int IdEstudiante { get; set; }
    public string? TipoDocumento { get; set; }
    public string? NumeroDocumento { get; set; }
    public string? Nombres { get; set; }
    public string? ApellidoPaterno { get; set; }
    public string? ApellidoMaterno { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string? Sexo { get; set; }
    public string? Direccion { get; set; }
    public string? CodigoEstudiante { get; set; }
    public DateTime FechaIngreso { get; set; }
    public string? Telefonos { get; set; }
    public string? Correos { get; set; }
    public int? PeriodoActivo { get; set; }
    public string? GradoActual { get; set; }
    public string? SeccionActual { get; set; }
}