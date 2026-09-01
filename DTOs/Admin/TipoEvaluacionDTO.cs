namespace GestionAcademica.API.DTOs.Admin;

public class TipoEvaluacionDTO
{
    public int IdTipoEvaluacion { get; set; }
    public string? NombreTipo { get; set; }
    public string? Descripcion { get; set; }
    public bool Estado { get; set; }
}