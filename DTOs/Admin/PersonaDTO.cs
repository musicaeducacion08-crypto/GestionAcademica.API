namespace GestionAcademica.API.DTOs.Admin;

public class PersonaDTO
{
    public int IdPersona { get; set; }
    public string? TipoDocumento { get; set; }
    public string? NumeroDocumento { get; set; }
    public string? Nombres { get; set; }
    public string? ApellidoPaterno { get; set; }
    public string? ApellidoMaterno { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string? Sexo { get; set; }
    public string? Direccion { get; set; }
    public bool Estado { get; set; }
    public string? Telefono { get; set; }      // Para inserción/actualización (coincide con SP)
    public string? Correo { get; set; }        // Para inserción/actualización (coincide con SP)
    public string? Telefonos { get; set; }     // Para listar (del SP, plural)
    public string? Correos { get; set; }       // Para listar (del SP, plural)
}