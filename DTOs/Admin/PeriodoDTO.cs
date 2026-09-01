namespace GestionAcademica.API.DTOs.Admin;

public class PeriodoDTO
{
    public int IdPeriodo { get; set; }
    public string? NombrePeriodo { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public bool Estado { get; set; }
}