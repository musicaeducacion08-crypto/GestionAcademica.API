namespace GestionAcademica.API.DTOs.Admin;

public class MatriculaPeriodoDTO
{
    public int IdMatricula { get; set; }
    public string? Estudiante { get; set; }
    public string? NombrePeriodo { get; set; }
    public string? NombreGrado { get; set; }
    public string? NombreSeccion { get; set; }
    public string? EstadoMatricula { get; set; }
    public DateTime FechaMatricula { get; set; }
}

public class CrearMatriculaPeriodoDTO
{
    public int IdEstudiante { get; set; }
    public int IdPeriodo { get; set; }
    public int IdGradoSeccion { get; set; }
}