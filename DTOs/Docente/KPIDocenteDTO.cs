namespace GestionAcademica.API.DTOs.Docente;

public class KPIDocenteDTO
{
    public decimal PromedioNotas { get; set; }
    public decimal PorcentajeAsistencia { get; set; }
    public int AlertasPendientes { get; set; }
}