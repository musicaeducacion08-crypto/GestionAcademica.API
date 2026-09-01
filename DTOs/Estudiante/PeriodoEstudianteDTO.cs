namespace GestionAcademica.API.DTOs.Estudiante;

public class PeriodoEstudianteDTO
{
    public int IdPeriodo { get; set; }
    public string? NombrePeriodo { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string? EstadoMatricula { get; set; }
    public string? NombreGrado { get; set; }
    public string? NombreSeccion { get; set; }
}