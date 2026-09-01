using Dapper;
using GestionAcademica.API.DTOs.Admin;
using GestionAcademica.API.DTOs.Docente;
using GestionAcademica.API.Repositories.Interfaces;
using System.Data;

namespace GestionAcademica.API.Repositories.Implementaciones;

public class DocenteRepository : BaseRepository, IDocenteRepository
{
    public DocenteRepository(IConfiguration config) : base(config) { }

    public async Task<IEnumerable<CursoDocenteDTO>> ObtenerCursosAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<CursoDocenteDTO>("usp_Docente_ObtenerCursos",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<EstudianteNotaDTO>> ObtenerEstudiantesAsync(int idAsignacion, int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<EstudianteNotaDTO>("usp_Docente_ObtenerEstudiantes",
            new { IdAsignacion = idAsignacion, IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    // ✅ USANDO IdSemana
    public async Task GuardarNotaAsync(GuardarNotaDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdListaEstudiante", dto.IdListaEstudiante);
        parameters.Add("@IdSemana", dto.IdSemana);
        parameters.Add("@Calificacion", dto.Calificacion);
        parameters.Add("@IdTipoEvaluacion", dto.IdTipoEvaluacion);
        parameters.Add("@NombreEvaluacion", dto.NombreEvaluacion);
        parameters.Add("@IdUsuario", idUsuario);

        await connection.ExecuteAsync("usp_Docente_GuardarNota", parameters, commandType: CommandType.StoredProcedure);
    }

    // ✅ GUARDAR ASISTENCIA
    public async Task GuardarAsistenciaAsync(GuardarAsistenciaDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdListaEstudiante", dto.IdListaEstudiante);
        parameters.Add("@NumeroUnidad", dto.NumeroUnidad);
        parameters.Add("@IdEstadoAsistencia", dto.IdEstadoAsistencia);
        parameters.Add("@FechaAsistencia", dto.FechaAsistencia);
        parameters.Add("@Observacion", dto.Observacion);
        parameters.Add("@IdUsuario", idUsuario);

        await connection.ExecuteAsync("usp_Docente_GuardarAsistencia", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<AlertaDTO>> ObtenerAlertasAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<AlertaDTO>("usp_Docente_ObtenerAlertas",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    public async Task RegistrarSeguimientoAsync(SeguimientoAlertaDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdAlerta", dto.IdAlerta);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@AccionRealizada", dto.AccionRealizada);
        parameters.Add("@Comentario", dto.Comentario);
        parameters.Add("@MarcarDesercion", dto.MarcarDesercion);

        await connection.ExecuteAsync("usp_Docente_RegistrarSeguimiento", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<KPIDocenteDTO> ObtenerKPIsAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<KPIDocenteDTO>("usp_Docente_ObtenerKPIs",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure) ?? new KPIDocenteDTO();
    }

    public async Task<IEnumerable<UnidadDTO>> ObtenerUnidadesAsync(int idAsignacion, int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<UnidadDTO>("usp_Docente_ObtenerUnidades",
            new { IdAsignacion = idAsignacion, IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<TipoEvaluacionDTO>> ObtenerTiposEvaluacionAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<TipoEvaluacionDTO>("usp_Docente_ObtenerTiposEvaluacion", commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<EstadoAsistenciaDTO>> ObtenerEstadosAsistenciaAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<EstadoAsistenciaDTO>("usp_Docente_ObtenerEstadosAsistencia", commandType: CommandType.StoredProcedure);
    }
}