namespace GestionAcademica.API.DTOs.Estudiante;

public class TramiteDTO
{
    public int IdTramite { get; set; }
    public string? NumeroTramite { get; set; }
    public string? TipoTramite { get; set; }
    public string? Estado { get; set; }
    public string? Asunto { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaRegistro { get; set; }
    public DateTime? FechaActualizacion { get; set; }
    public string? RutaPDF { get; set; }
    public int DiasTranscurridos { get; set; }
}

public class SolicitarTramiteDTO
{
    public int IdTipoTramite { get; set; }
    public string? Asunto { get; set; }
    public string? Descripcion { get; set; }
    public string? NombreArchivo { get; set; }
    public string? RutaArchivo { get; set; }
    public long TamanoArchivo { get; set; }
}