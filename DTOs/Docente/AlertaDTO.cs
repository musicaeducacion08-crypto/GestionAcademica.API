namespace GestionAcademica.API.DTOs.Docente;

public class AlertaDTO
{
    public int IdAlerta { get; set; }
    public string? Estudiante { get; set; }
    public string? TipoAlerta { get; set; }
    public string? NivelRiesgo { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaGeneracion { get; set; }
    public string? Estado { get; set; }
    public string? NombreCurso { get; set; }
}