namespace GestionAcademica.API.DTOs.Admin;

public class SeccionDTO
{
    public int IdSeccion { get; set; }
    public string? NombreSeccion { get; set; }
    public string? Turno { get; set; }
    public bool Estado { get; set; }
}