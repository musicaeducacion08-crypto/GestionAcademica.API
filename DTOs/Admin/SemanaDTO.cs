namespace GestionAcademica.API.DTOs.Admin;

public class SemanaDTO
{
    public int IdSemana { get; set; }
    public int IdUnidad { get; set; }
    public int NumeroSemana { get; set; }
    public string? NombreSemana { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public bool Estado { get; set; }
}

public class CrearSemanaDTO
{
    public int IdUnidad { get; set; }
    public int NumeroSemana { get; set; }
    public string? NombreSemana { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
}