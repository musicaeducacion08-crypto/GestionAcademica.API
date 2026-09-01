namespace GestionAcademica.API.DTOs.Admin;

public class EstadoAsistenciaDTO
{
    public int IdEstadoAsistencia { get; set; }
    public string? NombreEstado { get; set; }
    public string? Descripcion { get; set; }
    public bool Estado { get; set; }
}