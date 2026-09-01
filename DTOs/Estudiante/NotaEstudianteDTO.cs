namespace GestionAcademica.API.DTOs.Estudiante;

public class NotaEstudianteDTO
{
    public string? NombreCurso { get; set; }
    public string? CodigoCurso { get; set; }
    public string? NombreGrado { get; set; }
    public string? NombreSeccion { get; set; }
    public string? NombrePeriodo { get; set; }
    public string? NombreUnidad { get; set; }
    public int NumeroUnidad { get; set; }
    public int NumeroNota { get; set; }
    public decimal Calificacion { get; set; }
    public string? NombreEvaluacion { get; set; }
    public string? TipoEvaluacion { get; set; }
    public DateTime FechaEvaluacion { get; set; }
}