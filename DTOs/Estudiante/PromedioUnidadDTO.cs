namespace GestionAcademica.API.DTOs.Estudiante;

public class PromedioUnidadDTO
{
    public string? NombreCurso { get; set; }
    public int NumeroUnidad { get; set; }
    public string? NombreUnidad { get; set; }
    public decimal PromedioUnidad { get; set; }
    public int TotalSemanas { get; set; }
}