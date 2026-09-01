namespace GestionAcademica.API.DTOs.Docente;

public class CursoDocenteDTO
{
    public int IdAsignacion { get; set; }
    public string? NombreCurso { get; set; }
    public string? CodigoCurso { get; set; }
    public string? NombreGrado { get; set; }
    public string? NombreSeccion { get; set; }
    public string? NombrePeriodo { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int TotalEstudiantes { get; set; }
}