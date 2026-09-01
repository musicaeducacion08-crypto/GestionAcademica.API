namespace GestionAcademica.API.DTOs.Estudiante;

public class HorarioEstudianteDTO
{
    public string? NombreDia { get; set; }
    public int NumeroDia { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
    public string? NombreCurso { get; set; }
    public string? Docente { get; set; }
    public string? Aula { get; set; }
    public string? NombreGrado { get; set; }
    public string? NombreSeccion { get; set; }
}