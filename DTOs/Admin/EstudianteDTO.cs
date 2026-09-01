namespace GestionAcademica.API.DTOs.Admin;

public class EstudianteDTO
{
    public int IdEstudiante { get; set; }
    public string? NombreCompleto { get; set; }
    public string? NumeroDocumento { get; set; }
    public string? CodigoEstudiante { get; set; }
    public DateTime FechaIngreso { get; set; }
    public bool Estado { get; set; }
    public int MatriculasActivas { get; set; }
}