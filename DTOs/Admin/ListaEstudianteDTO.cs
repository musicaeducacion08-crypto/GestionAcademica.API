namespace GestionAcademica.API.DTOs.Admin;

public class ListaEstudianteDTO
{
    public int IdListaEstudiante { get; set; }
    public string? Estudiante { get; set; }
    public DateTime FechaRegistro { get; set; }
    public bool Estado { get; set; }
}