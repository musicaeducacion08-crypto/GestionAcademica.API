namespace GestionAcademica.API.DTOs.Admin;

public class DocenteDTO
{
    public int IdDocente { get; set; }
    public string? NombreCompleto { get; set; }
    public string? NumeroDocumento { get; set; }
    public string? CodigoDocente { get; set; }
    public string? Especialidad { get; set; }
    public bool Estado { get; set; }
}