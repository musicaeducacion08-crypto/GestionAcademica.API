using Dapper;
using GestionAcademica.API.DTOs.Admin;
using GestionAcademica.API.DTOs.Docente;
using GestionAcademica.API.DTOs.Estudiante;
using GestionAcademica.API.Repositories.Interfaces;
using System.Data;

namespace GestionAcademica.API.Repositories.Implementaciones;

public class EstudianteRepository : BaseRepository, IEstudianteRepository
{
    public EstudianteRepository(IConfiguration config) : base(config) { }

    public async Task<PerfilDTO?> ObtenerPerfilAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<PerfilDTO>("usp_Estudiante_ObtenerPerfil",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    public async Task ActualizarPerfilAsync(int idUsuario, string? telefono, string? correo, string? direccion)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Telefono", telefono);
        parameters.Add("@Correo", correo);
        parameters.Add("@Direccion", direccion);
        await connection.ExecuteAsync("usp_Estudiante_ActualizarPerfil", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<NotaEstudianteDTO>> ObtenerNotasAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<NotaEstudianteDTO>("usp_Estudiante_ObtenerNotas",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<ResumenNotasDTO>> ObtenerResumenNotasAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<ResumenNotasDTO>("usp_Estudiante_ObtenerResumenNotas",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<AsistenciaEstudianteDTO>> ObtenerAsistenciasAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<AsistenciaEstudianteDTO>("usp_Estudiante_ObtenerAsistencias",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<HorarioEstudianteDTO>> ObtenerHorarioAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<HorarioEstudianteDTO>("usp_Estudiante_ObtenerHorario",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<AlertaDTO>> ObtenerAlertasAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<AlertaDTO>("usp_Estudiante_ObtenerAlertas",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> SolicitarTramiteAsync(SolicitarTramiteDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdTipoTramite", dto.IdTipoTramite);
        parameters.Add("@Asunto", dto.Asunto);
        parameters.Add("@Descripcion", dto.Descripcion);
        parameters.Add("@NombreArchivo", dto.NombreArchivo);
        parameters.Add("@RutaArchivo", dto.RutaArchivo);
        parameters.Add("@TamanoArchivo", dto.TamanoArchivo);
        parameters.Add("@IdTramite", dbType: DbType.Int32, direction: ParameterDirection.Output);
        await connection.ExecuteAsync("usp_Estudiante_SolicitarTramite", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdTramite");
    }

    public async Task<IEnumerable<TramiteDTO>> ObtenerTramitesAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<TramiteDTO>("usp_Estudiante_ObtenerTramites",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<HistorialTramiteDTO>> ObtenerHistorialTramitesAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<HistorialTramiteDTO>("usp_Estudiante_ObtenerHistorialTramites",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<TipoTramiteDTO>> ObtenerTiposTramiteAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<TipoTramiteDTO>("usp_Estudiante_ObtenerTiposTramite", commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<PeriodoEstudianteDTO>> ObtenerPeriodosAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<PeriodoEstudianteDTO>("usp_Estudiante_ObtenerPeriodos",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    public async Task<PromedioGeneralDTO> ObtenerPromedioGeneralAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<PromedioGeneralDTO>("usp_Estudiante_ObtenerPromedioGeneral",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure) ?? new PromedioGeneralDTO();
    }

    public async Task CambiarClaveAsync(int idUsuario, string claveActual, string nuevaClave)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@ClaveActual", claveActual);
        parameters.Add("@NuevaClave", nuevaClave);
        await connection.ExecuteAsync("usp_Estudiante_CambiarClave", parameters, commandType: CommandType.StoredProcedure);
    }
    public async Task<IEnumerable<PromedioUnidadDTO>> ObtenerPromedioUnidadAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<PromedioUnidadDTO>("usp_Estudiante_ObtenerPromedioUnidad",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }
}