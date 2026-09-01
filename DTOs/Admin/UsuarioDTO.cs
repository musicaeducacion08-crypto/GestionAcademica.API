namespace GestionAcademica.API.DTOs.Admin;

public class UsuarioDTO
{
    public int IdUsuario { get; set; }
    public string? NombreCompleto { get; set; }
    public string? NumeroDocumento { get; set; }
    public string? NombreUsuario { get; set; }
    public int IdRol { get; set; }              // ⬅️ AGREGADO (necesario para ActualizarUsuarioAsync)
    public string? NombreRol { get; set; }
    public bool Estado { get; set; }
    public DateTime FechaRegistro { get; set; }
    public DateTime? UltimoAcceso { get; set; }
}

public class CrearUsuarioDTO
{
    public string? TipoDocumento { get; set; }
    public string? NumeroDocumento { get; set; }
    public string? Nombres { get; set; }
    public string? ApellidoPaterno { get; set; }
    public string? ApellidoMaterno { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string? Sexo { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public string? NombreUsuario { get; set; }
    public string? Clave { get; set; }
    public int IdRol { get; set; }
    public string? CodigoInstitucional { get; set; }
    public string? Especialidad { get; set; }
}