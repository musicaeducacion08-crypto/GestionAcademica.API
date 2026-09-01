using GestionAcademica.API.DTOs.Auth;
using GestionAcademica.API.DTOs.Shared;
using GestionAcademica.API.Helpers;
using GestionAcademica.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthRepository authRepo, JwtHelper jwtHelper) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<ResponseDTO<AuthResponseDTO>>> Login([FromBody] LoginDTO dto)
    {
        // Validación de entrada para evitar CS8604 y errores de null
        if (dto == null || string.IsNullOrWhiteSpace(dto.NombreUsuario) || string.IsNullOrWhiteSpace(dto.Clave))
        {
            return BadRequest(new ResponseDTO<AuthResponseDTO>
            {
                Success = false,
                Message = "El nombre de usuario y la clave son requeridos."
            });
        }

        // Intentar autenticar
        var (idUsuario, nombre, rol) = await authRepo.LoginAsync(dto.NombreUsuario, dto.Clave);

        if (idUsuario == 0)
        {
            return Unauthorized(new ResponseDTO<AuthResponseDTO>
            {
                Success = false,
                Message = "Credenciales incorrectas."
            });
        }

        // Generar token JWT
        var token = jwtHelper.GenerarToken(idUsuario, nombre, rol);

        return Ok(new ResponseDTO<AuthResponseDTO>
        {
            Success = true,
            Message = "Autenticación exitosa.",
            Data = new AuthResponseDTO
            {
                IdUsuario = idUsuario,
                Nombre = nombre,
                Rol = rol,
                Token = token
            }
        });
    }
}