namespace GestionAcademica.API.DTOs.Docente;

public class SeguimientoAlertaDTO
{
    public int IdAlerta { get; set; }
    public string? AccionRealizada { get; set; }
    public string? Comentario { get; set; }
    public bool MarcarDesercion { get; set; }
}