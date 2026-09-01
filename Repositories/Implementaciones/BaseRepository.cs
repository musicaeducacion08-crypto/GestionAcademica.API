using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GestionAcademica.API.Repositories.Implementaciones;

public abstract class BaseRepository(IConfiguration config)
{
    private readonly string _connectionString = config?.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException(nameof(config), "La cadena de conexión no está configurada.");

    protected IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}