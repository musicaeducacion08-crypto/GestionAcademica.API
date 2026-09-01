namespace GestionAcademica.API.DTOs.Estudiante;

public class AsistenciaEstudianteDTO
{
    public string? NombreCurso { get; set; }
    public string? CodigoCurso { get; set; }
    public string? NombreGrado { get; set; }
    public string? NombreSeccion { get; set; }
    public int NumeroUnidad { get; set; }
    public DateTime FechaAsistencia { get; set; }
    public string? Estado { get; set; }
    public string? Observacion { get; set; }
    public string? NombreDia { get; set; }
    public TimeSpan? HoraInicio { get; set; }
    public TimeSpan? HoraFin { get; set; }
}