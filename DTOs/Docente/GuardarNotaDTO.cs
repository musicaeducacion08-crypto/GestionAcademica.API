namespace GestionAcademica.API.DTOs.Docente;

public class GuardarNotaDTO
{
    public int IdListaEstudiante { get; set; }
    public int IdSemana { get; set; }          // ⬅️ Ahora usa IdSemana
    public decimal Calificacion { get; set; }
    public int IdTipoEvaluacion { get; set; }
    public string? NombreEvaluacion { get; set; }
}