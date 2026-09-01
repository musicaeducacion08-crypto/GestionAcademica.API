namespace GestionAcademica.API.DTOs.Admin;

public class GradoDTO
{
    public int IdGrado { get; set; }
    public string? NombreGrado { get; set; }
    public int NumeroGrado { get; set; }
    public string? Nivel { get; set; }
    public bool Estado { get; set; }
}