namespace GestionAcademica.API.DTOs.Docente;

public class GuardarAsistenciaDTO
{
    public int IdListaEstudiante { get; set; }
    public int NumeroUnidad { get; set; }
    public int IdEstadoAsistencia { get; set; }
    public DateTime FechaAsistencia { get; set; }
    public string? Observacion { get; set; }
}