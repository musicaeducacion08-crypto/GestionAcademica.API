namespace GestionAcademica.API.DTOs.Estudiante;

public class PromedioGeneralDTO
{
    public decimal PromedioGeneral { get; set; }
    public int TotalCursos { get; set; }
    public int TotalNotas { get; set; }
}