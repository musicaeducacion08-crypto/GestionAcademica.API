namespace GestionAcademica.API.DTOs.Admin;

public class EstadoTramiteDTO
{
    public int IdEstadoTramite { get; set; }
    public string? NombreEstado { get; set; }
    public string? Descripcion { get; set; }
    public int OrdenEstado { get; set; }
    public bool Estado { get; set; }
}