namespace GestionAcademica.API.DTOs.Docente;

public class EstudianteNotaDTO
{
    public int IdListaEstudiante { get; set; }
    public int IdEstudiante { get; set; }
    public string? Nombres { get; set; }
    public string? ApellidoPaterno { get; set; }
    public string? ApellidoMaterno { get; set; }
    public string? NotasExistentes { get; set; } // JSON con notas existentes
    public string? AsistenciasExistentes { get; set; } // JSON con asistencias
}