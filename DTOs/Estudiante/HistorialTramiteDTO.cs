namespace GestionAcademica.API.DTOs.Estudiante;

public class HistorialTramiteDTO
{
    public int IdTramite { get; set; }
    public string? NumeroTramite { get; set; }
    public string? TipoTramite { get; set; }
    public string? NombreEstadoAnterior { get; set; }
    public string? NombreEstadoNuevo { get; set; }
    public DateTime FechaCambio { get; set; }
    public string? UsuarioModificador { get; set; }
    public string? Observacion { get; set; }
}