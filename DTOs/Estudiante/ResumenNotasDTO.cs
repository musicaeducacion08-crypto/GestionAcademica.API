namespace GestionAcademica.API.DTOs.Estudiante;

public class ResumenNotasDTO
{
    public string? NombreCurso { get; set; }
    public int NumeroUnidad { get; set; }
    public string? NombreUnidad { get; set; }
    public int NumeroSemana { get; set; }              // ⬅️ Nueva propiedad
    public string? NombreSemana { get; set; }          // ⬅️ Nueva propiedad
    public decimal Calificacion { get; set; }
    public string? NombreEvaluacion { get; set; }
    public string? TipoEvaluacion { get; set; }
}