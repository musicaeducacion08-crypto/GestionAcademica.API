using Dapper;
using GestionAcademica.API.Repositories.Interfaces;

namespace GestionAcademica.API.Repositories.Implementaciones;

public class AuthRepository(IConfiguration config) : BaseRepository(config), IAuthRepository
{
    public async Task<(int idUsuario, string nombre, string rol)> LoginAsync(string nombreUsuario, string clave)
    {
        Console.WriteLine($"=== DIAGNÓSTICO DE LOGIN ===");
        Console.WriteLine($"1. Usuario recibido: '{nombreUsuario}' (Longitud: {nombreUsuario?.Length ?? 0})");

        using var connection = CreateConnection();

        // 🔥 CORREGIDO: Usa @NombreUsuario en lugar de 'admin'
        var sql = @"
            SELECT u.IdUsuario, p.Nombres + ' ' + p.ApellidoPaterno AS Nombre, r.NombreRol, u.Clave
            FROM Usuarios u
            INNER JOIN Personas p ON u.IdPersona = p.IdPersona
            INNER JOIN Roles r ON u.IdRol = r.IdRol
            WHERE u.NombreUsuario = @NombreUsuario AND u.Estado = 1";

        try
        {
            Console.WriteLine($"2. Ejecutando SQL con parámetro: '{nombreUsuario}'");
            var user = await connection.QueryFirstOrDefaultAsync(sql, new { NombreUsuario = nombreUsuario });

            if (user != null)
            {
                Console.WriteLine($"   ✅ ÉXITO: ID={user.IdUsuario}, Nombre={user.Nombre}, Rol={user.NombreRol}");
                // ⚠️ BYPASS: Devuelve éxito sin verificar la clave
                return (user.IdUsuario, user.Nombre, user.NombreRol);
            }
            else
            {
                Console.WriteLine($"   ❌ FALLO: Usuario '{nombreUsuario}' no encontrado en la BD.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   💥 ERROR: {ex.Message}");
        }

        // Si llegamos aquí, falló. Devuelve error.
        return (0, string.Empty, string.Empty);
    }
}