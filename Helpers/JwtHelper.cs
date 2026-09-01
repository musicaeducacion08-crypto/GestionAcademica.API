using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GestionAcademica.API.Helpers;

public class JwtHelper(IConfiguration config)
{
    private readonly IConfiguration _config = config ?? throw new ArgumentNullException(nameof(config));

    public string GenerarToken(int idUsuario, string nombre, string rol)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, idUsuario.ToString()),
            new(ClaimTypes.Name, nombre ?? string.Empty),
            new(ClaimTypes.Role, rol ?? string.Empty),
            new("IdUsuario", idUsuario.ToString())
        };

        var keyString = _config["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key no configurada.");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"] ?? "480"));

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"] ?? "GestionAcademica.API",
            audience: _config["Jwt:Audience"] ?? "GestionAcademica.Client",
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}