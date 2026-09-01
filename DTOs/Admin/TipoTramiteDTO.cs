namespace GestionAcademica.API.DTOs.Admin;

public class TipoTramiteDTO
{
    public int IdTipoTramite { get; set; }
    public string? NombreTipo { get; set; }
    public string? Descripcion { get; set; }
    public bool Estado { get; set; }
}