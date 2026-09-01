namespace GestionAcademica.API.DTOs.Admin;

public class AsignacionDTO
{
    public int IdAsignacion { get; set; }
    public string? Docente { get; set; }
    public string? NombreCurso { get; set; }
    public string? NombrePeriodo { get; set; }
    public string? NombreGrado { get; set; }
    public string? NombreSeccion { get; set; }
    public bool Estado { get; set; }
}

public class CrearAsignacionDTO
{
    public int IdDocente { get; set; }
    public int IdCurso { get; set; }
    public int IdPeriodo { get; set; }
    public int IdGradoSeccion { get; set; }
}