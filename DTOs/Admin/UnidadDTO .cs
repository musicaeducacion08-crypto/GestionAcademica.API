namespace GestionAcademica.API.DTOs.Admin;

public class UnidadDTO
{
    public int IdUnidad { get; set; }
    public int IdAsignacion { get; set; }
    public int NumeroUnidad { get; set; }
    public string? NombreUnidad { get; set; }
    public bool Estado { get; set; }
}