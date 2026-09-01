using Dapper;
using GestionAcademica.API.DTOs.Admin;
using GestionAcademica.API.Repositories.Interfaces;
using System.Data;

namespace GestionAcademica.API.Repositories.Implementaciones;

public class AdminRepository : BaseRepository, IAdminRepository
{
    public AdminRepository(IConfiguration config) : base(config) { }

    // ============================================================
    // CURSOS
    // ============================================================
    public async Task<IEnumerable<CursoDTO>> ListarCursosAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<CursoDTO>("usp_Admin_Curso_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<CursoDTO?> ObtenerCursoPorIdAsync(int idCurso)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<CursoDTO>("usp_Admin_Curso_ObtenerPorId",
            new { IdCurso = idCurso }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarCursoAsync(CursoDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@CodigoCurso", dto.CodigoCurso);
        parameters.Add("@NombreCurso", dto.NombreCurso);
        parameters.Add("@Descripcion", dto.Descripcion);
        parameters.Add("@HorasSemanales", dto.HorasSemanales);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdCurso", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Curso_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdCurso");
    }

    public async Task ActualizarCursoAsync(CursoDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdCurso", dto.IdCurso);
        parameters.Add("@CodigoCurso", dto.CodigoCurso);
        parameters.Add("@NombreCurso", dto.NombreCurso);
        parameters.Add("@Descripcion", dto.Descripcion);
        parameters.Add("@HorasSemanales", dto.HorasSemanales);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Curso_Actualizar", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task CambiarEstadoCursoAsync(int idCurso, bool estado, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdCurso", idCurso);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Curso_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // GRADOS
    // ============================================================
    public async Task<IEnumerable<GradoDTO>> ListarGradosAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<GradoDTO>("usp_Admin_Grado_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<GradoDTO?> ObtenerGradoPorIdAsync(int idGrado)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<GradoDTO>("usp_Admin_Grado_ObtenerPorId",
            new { IdGrado = idGrado }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarGradoAsync(GradoDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@NombreGrado", dto.NombreGrado);
        parameters.Add("@NumeroGrado", dto.NumeroGrado);
        parameters.Add("@Nivel", dto.Nivel);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdGrado", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Grado_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdGrado");
    }

    public async Task ActualizarGradoAsync(GradoDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdGrado", dto.IdGrado);
        parameters.Add("@NombreGrado", dto.NombreGrado);
        parameters.Add("@NumeroGrado", dto.NumeroGrado);
        parameters.Add("@Nivel", dto.Nivel);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Grado_Actualizar", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task CambiarEstadoGradoAsync(int idGrado, bool estado, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdGrado", idGrado);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Grado_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // SECCIONES
    // ============================================================
    public async Task<IEnumerable<SeccionDTO>> ListarSeccionesAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<SeccionDTO>("usp_Admin_Seccion_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<SeccionDTO?> ObtenerSeccionPorIdAsync(int idSeccion)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<SeccionDTO>("usp_Admin_Seccion_ObtenerPorId",
            new { IdSeccion = idSeccion }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarSeccionAsync(SeccionDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@NombreSeccion", dto.NombreSeccion);
        parameters.Add("@Turno", dto.Turno);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdSeccion", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Seccion_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdSeccion");
    }

    public async Task ActualizarSeccionAsync(SeccionDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdSeccion", dto.IdSeccion);
        parameters.Add("@NombreSeccion", dto.NombreSeccion);
        parameters.Add("@Turno", dto.Turno);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Seccion_Actualizar", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task CambiarEstadoSeccionAsync(int idSeccion, bool estado, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdSeccion", idSeccion);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Seccion_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // PERIODOS
    // ============================================================
    public async Task<IEnumerable<PeriodoDTO>> ListarPeriodosAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<PeriodoDTO>("usp_Admin_Periodo_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<PeriodoDTO?> ObtenerPeriodoPorIdAsync(int idPeriodo)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<PeriodoDTO>("usp_Admin_Periodo_ObtenerPorId",
            new { IdPeriodo = idPeriodo }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarPeriodoAsync(PeriodoDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@NombrePeriodo", dto.NombrePeriodo);
        parameters.Add("@FechaInicio", dto.FechaInicio);
        parameters.Add("@FechaFin", dto.FechaFin);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdPeriodo", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Periodo_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdPeriodo");
    }

    public async Task ActualizarPeriodoAsync(PeriodoDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdPeriodo", dto.IdPeriodo);
        parameters.Add("@NombrePeriodo", dto.NombrePeriodo);
        parameters.Add("@FechaInicio", dto.FechaInicio);
        parameters.Add("@FechaFin", dto.FechaFin);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Periodo_Actualizar", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task CambiarEstadoPeriodoAsync(int idPeriodo, bool estado, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdPeriodo", idPeriodo);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Periodo_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // TIPOS DE TRÁMITE
    // ============================================================
    public async Task<IEnumerable<TipoTramiteDTO>> ListarTiposTramiteAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<TipoTramiteDTO>("usp_Admin_TipoTramite_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<TipoTramiteDTO?> ObtenerTipoTramitePorIdAsync(int idTipoTramite)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<TipoTramiteDTO>("usp_Admin_TipoTramite_ObtenerPorId",
            new { IdTipoTramite = idTipoTramite }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarTipoTramiteAsync(TipoTramiteDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@NombreTipo", dto.NombreTipo);
        parameters.Add("@Descripcion", dto.Descripcion);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdTipoTramite", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_TipoTramite_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdTipoTramite");
    }

    public async Task ActualizarTipoTramiteAsync(TipoTramiteDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdTipoTramite", dto.IdTipoTramite);
        parameters.Add("@NombreTipo", dto.NombreTipo);
        parameters.Add("@Descripcion", dto.Descripcion);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_TipoTramite_Actualizar", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task CambiarEstadoTipoTramiteAsync(int idTipoTramite, bool estado, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdTipoTramite", idTipoTramite);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_TipoTramite_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // ESTADOS DE TRÁMITE
    // ============================================================
    public async Task<IEnumerable<EstadoTramiteDTO>> ListarEstadosTramiteAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<EstadoTramiteDTO>("usp_Admin_EstadoTramite_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<EstadoTramiteDTO?> ObtenerEstadoTramitePorIdAsync(int idEstadoTramite)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<EstadoTramiteDTO>("usp_Admin_EstadoTramite_ObtenerPorId",
            new { IdEstadoTramite = idEstadoTramite }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarEstadoTramiteAsync(EstadoTramiteDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@NombreEstado", dto.NombreEstado);
        parameters.Add("@Descripcion", dto.Descripcion);
        parameters.Add("@OrdenEstado", dto.OrdenEstado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdEstadoTramite", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_EstadoTramite_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdEstadoTramite");
    }

    public async Task ActualizarEstadoTramiteAsync(EstadoTramiteDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdEstadoTramite", dto.IdEstadoTramite);
        parameters.Add("@NombreEstado", dto.NombreEstado);
        parameters.Add("@Descripcion", dto.Descripcion);
        parameters.Add("@OrdenEstado", dto.OrdenEstado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_EstadoTramite_Actualizar", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task CambiarEstadoEstadoTramiteAsync(int idEstadoTramite, bool estado, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdEstadoTramite", idEstadoTramite);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_EstadoTramite_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // TIPOS DE EVALUACIÓN
    // ============================================================
    public async Task<IEnumerable<TipoEvaluacionDTO>> ListarTiposEvaluacionAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<TipoEvaluacionDTO>("usp_Admin_TipoEvaluacion_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<TipoEvaluacionDTO?> ObtenerTipoEvaluacionPorIdAsync(int idTipoEvaluacion)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<TipoEvaluacionDTO>("usp_Admin_TipoEvaluacion_ObtenerPorId",
            new { IdTipoEvaluacion = idTipoEvaluacion }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarTipoEvaluacionAsync(TipoEvaluacionDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@NombreTipo", dto.NombreTipo);
        parameters.Add("@Descripcion", dto.Descripcion);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdTipoEvaluacion", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_TipoEvaluacion_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdTipoEvaluacion");
    }

    public async Task ActualizarTipoEvaluacionAsync(TipoEvaluacionDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdTipoEvaluacion", dto.IdTipoEvaluacion);
        parameters.Add("@NombreTipo", dto.NombreTipo);
        parameters.Add("@Descripcion", dto.Descripcion);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_TipoEvaluacion_Actualizar", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task CambiarEstadoTipoEvaluacionAsync(int idTipoEvaluacion, bool estado, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdTipoEvaluacion", idTipoEvaluacion);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_TipoEvaluacion_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // ESTUDIANTES
    // ============================================================
    public async Task<IEnumerable<EstudianteDTO>> ListarEstudiantesAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<EstudianteDTO>("usp_Admin_Estudiante_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<EstudianteDTO?> ObtenerEstudiantePorIdAsync(int idEstudiante)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<EstudianteDTO>("usp_Admin_Estudiante_ObtenerPorId",
            new { IdEstudiante = idEstudiante }, commandType: CommandType.StoredProcedure);
    }

    public async Task CambiarEstadoEstudianteAsync(int idEstudiante, bool estado, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdEstudiante", idEstudiante);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Estudiante_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // DOCENTES
    // ============================================================
    public async Task<IEnumerable<DocenteDTO>> ListarDocentesAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<DocenteDTO>("usp_Admin_Docente_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<DocenteDTO?> ObtenerDocentePorIdAsync(int idDocente)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<DocenteDTO>("usp_Admin_Docente_ObtenerPorId",
            new { IdDocente = idDocente }, commandType: CommandType.StoredProcedure);
    }

    public async Task CambiarEstadoDocenteAsync(int idDocente, bool estado, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdDocente", idDocente);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Docente_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // GRADO-SECCION
    // ============================================================
    public async Task<IEnumerable<GradoSeccionDTO>> ListarGradoSeccionAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<GradoSeccionDTO>("usp_Admin_GradoSeccion_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarGradoSeccionAsync(CrearGradoSeccionDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdGrado", dto.IdGrado);
        parameters.Add("@IdSeccion", dto.IdSeccion);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdGradoSeccion", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_GradoSeccion_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdGradoSeccion");
    }

    public async Task EliminarGradoSeccionAsync(int idGradoSeccion, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdGradoSeccion", idGradoSeccion);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_GradoSeccion_Eliminar", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // USUARIOS
    // ============================================================
    public async Task<IEnumerable<UsuarioDTO>> ListarUsuariosAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<UsuarioDTO>("usp_Admin_Usuario_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<UsuarioDTO?> ObtenerUsuarioPorIdAsync(int idUsuario)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<UsuarioDTO>("usp_Admin_Usuario_ObtenerPorId",
            new { IdUsuario = idUsuario }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> CrearUsuarioAsync(CrearUsuarioDTO dto, int idUsuarioAdmin)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@TipoDocumento", dto.TipoDocumento);
        parameters.Add("@NumeroDocumento", dto.NumeroDocumento);
        parameters.Add("@Nombres", dto.Nombres);
        parameters.Add("@ApellidoPaterno", dto.ApellidoPaterno);
        parameters.Add("@ApellidoMaterno", dto.ApellidoMaterno);
        parameters.Add("@FechaNacimiento", dto.FechaNacimiento);
        parameters.Add("@Sexo", dto.Sexo);
        parameters.Add("@Direccion", dto.Direccion);
        parameters.Add("@Telefono", dto.Telefono);
        parameters.Add("@Correo", dto.Correo);
        parameters.Add("@NombreUsuario", dto.NombreUsuario);
        parameters.Add("@Clave", dto.Clave);
        parameters.Add("@IdRol", dto.IdRol);
        parameters.Add("@CodigoInstitucional", dto.CodigoInstitucional);
        parameters.Add("@Especialidad", dto.Especialidad);
        parameters.Add("@IdUsuarioAdmin", idUsuarioAdmin);
        parameters.Add("@IdPersona", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@IdUsuarioNuevo", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Usuario_Crear", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdUsuarioNuevo");
    }

    public async Task ActualizarUsuarioAsync(UsuarioDTO dto, int idUsuarioAdmin)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdUsuario", dto.IdUsuario);
        parameters.Add("@NombreUsuario", dto.NombreUsuario);
        parameters.Add("@IdRol", dto.IdRol);
        parameters.Add("@Estado", dto.Estado);
        parameters.Add("@IdUsuarioAdmin", idUsuarioAdmin);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Usuario_Actualizar", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task CambiarEstadoUsuarioAsync(int idUsuario, bool estado, int idUsuarioAdmin)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuarioAdmin", idUsuarioAdmin);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Usuario_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // PERSONAS
    // ============================================================
    public async Task<IEnumerable<PersonaDTO>> ListarPersonasAsync(string? busqueda = null)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<PersonaDTO>("usp_Admin_Persona_Listar",
            new { Busqueda = busqueda }, commandType: CommandType.StoredProcedure);
    }

    public async Task<PersonaDTO?> ObtenerPersonaPorIdAsync(int idPersona)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<PersonaDTO>("usp_Admin_Persona_ObtenerPorId",
            new { IdPersona = idPersona }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarPersonaAsync(PersonaDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@TipoDocumento", dto.TipoDocumento);
        parameters.Add("@NumeroDocumento", dto.NumeroDocumento);
        parameters.Add("@Nombres", dto.Nombres);
        parameters.Add("@ApellidoPaterno", dto.ApellidoPaterno);
        parameters.Add("@ApellidoMaterno", dto.ApellidoMaterno);
        parameters.Add("@FechaNacimiento", dto.FechaNacimiento);
        parameters.Add("@Sexo", dto.Sexo);
        parameters.Add("@Direccion", dto.Direccion);
        parameters.Add("@Telefono", dto.Telefono);
        parameters.Add("@Correo", dto.Correo);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdPersona", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Persona_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdPersona");
    }

    public async Task ActualizarPersonaAsync(PersonaDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdPersona", dto.IdPersona);
        parameters.Add("@TipoDocumento", dto.TipoDocumento);
        parameters.Add("@NumeroDocumento", dto.NumeroDocumento);
        parameters.Add("@Nombres", dto.Nombres);
        parameters.Add("@ApellidoPaterno", dto.ApellidoPaterno);
        parameters.Add("@ApellidoMaterno", dto.ApellidoMaterno);
        parameters.Add("@FechaNacimiento", dto.FechaNacimiento);
        parameters.Add("@Sexo", dto.Sexo);
        parameters.Add("@Direccion", dto.Direccion);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Persona_Actualizar", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task CambiarEstadoPersonaAsync(int idPersona, bool estado, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdPersona", idPersona);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Persona_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // SESIONES
    // ============================================================
    public async Task<IEnumerable<SesionDTO>> ListarSesionesAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<SesionDTO>("usp_Admin_Sesion_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<SesionDTO?> ObtenerSesionPorIdAsync(int idSesion)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<SesionDTO>("usp_Admin_Sesion_ObtenerPorId",
            new { IdSesion = idSesion }, commandType: CommandType.StoredProcedure);
    }

    public async Task CambiarEstadoSesionAsync(int idSesion, bool estado, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdSesion", idSesion);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuarioAdmin", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Sesion_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // UNIDADES
    // ============================================================
    public async Task<IEnumerable<UnidadDTO>> ListarUnidadesPorAsignacionAsync(int idAsignacion)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<UnidadDTO>("usp_Admin_Unidad_ListarPorAsignacion",
            new { IdAsignacion = idAsignacion }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarUnidadAsync(CrearUnidadDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdAsignacion", dto.IdAsignacion);
        parameters.Add("@NumeroUnidad", dto.NumeroUnidad);
        parameters.Add("@NombreUnidad", dto.NombreUnidad);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdUnidad", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Unidad_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdUnidad");
    }

    public async Task ActualizarUnidadAsync(UnidadDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdUnidad", dto.IdUnidad);
        parameters.Add("@NombreUnidad", dto.NombreUnidad);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Unidad_Actualizar", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // LISTA ESTUDIANTES
    // ============================================================
    public async Task<IEnumerable<ListaEstudianteDTO>> ListarListaEstudiantesPorAsignacionAsync(int idAsignacion)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<ListaEstudianteDTO>("usp_Admin_ListaEstudiantes_ListarPorAsignacion",
            new { IdAsignacion = idAsignacion }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarListaEstudianteAsync(CrearListaEstudianteDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdEstudiante", dto.IdEstudiante);
        parameters.Add("@IdAsignacion", dto.IdAsignacion);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdListaEstudiante", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_ListaEstudiantes_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdListaEstudiante");
    }

    public async Task CambiarEstadoListaEstudianteAsync(int idListaEstudiante, bool estado, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdListaEstudiante", idListaEstudiante);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_ListaEstudiantes_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // HORARIOS
    // ============================================================
    public async Task<IEnumerable<HorarioDTO>> ListarHorariosAsync(int? idAsignacion = null)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<HorarioDTO>("usp_Admin_Horario_Listar",
            new { IdAsignacion = idAsignacion }, commandType: CommandType.StoredProcedure);
    }
    public async Task<HorarioDTO?> ObtenerHorarioPorIdAsync(int idHorario)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<HorarioDTO>("usp_Admin_Horario_ObtenerPorId",
            new { IdHorario = idHorario }, commandType: CommandType.StoredProcedure);
    }
   

    public async Task<int> InsertarHorarioAsync(CrearHorarioDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdAsignacion", dto.IdAsignacion);
        parameters.Add("@IdDiaSemana", dto.IdDiaSemana);
        parameters.Add("@HoraInicio", dto.HoraInicio);
        parameters.Add("@HoraFin", dto.HoraFin);
        parameters.Add("@Aula", dto.Aula);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdHorario", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Horario_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdHorario");
    }

    public async Task ActualizarHorarioAsync(HorarioDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdHorario", dto.IdHorario);
        parameters.Add("@IdDiaSemana", dto.IdDiaSemana);
        parameters.Add("@HoraInicio", dto.HoraInicio);
        parameters.Add("@HoraFin", dto.HoraFin);
        parameters.Add("@Aula", dto.Aula);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Horario_Actualizar", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task EliminarHorarioAsync(int idHorario, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdHorario", idHorario);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Horario_Eliminar", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // ASIGNACIONES
    // ============================================================
    public async Task<IEnumerable<AsignacionDTO>> ListarAsignacionesAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<AsignacionDTO>("usp_Admin_Asignacion_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<AsignacionDTO?> ObtenerAsignacionPorIdAsync(int idAsignacion)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<AsignacionDTO>("usp_Admin_Asignacion_ObtenerPorId",
            new { IdAsignacion = idAsignacion }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarAsignacionAsync(CrearAsignacionDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdDocente", dto.IdDocente);
        parameters.Add("@IdCurso", dto.IdCurso);
        parameters.Add("@IdPeriodo", dto.IdPeriodo);
        parameters.Add("@IdGradoSeccion", dto.IdGradoSeccion);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdAsignacion", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Asignacion_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdAsignacion");
    }

    public async Task CambiarEstadoAsignacionAsync(int idAsignacion, bool estado, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdAsignacion", idAsignacion);
        parameters.Add("@Estado", estado);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Asignacion_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }

    // ============================================================
    // MATRÍCULAS PERIODO
    // ============================================================
    public async Task<IEnumerable<MatriculaPeriodoDTO>> ListarMatriculasPeriodoAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<MatriculaPeriodoDTO>("usp_Admin_MatriculaPeriodo_Listar", commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarMatriculaPeriodoAsync(CrearMatriculaPeriodoDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdEstudiante", dto.IdEstudiante);
        parameters.Add("@IdPeriodo", dto.IdPeriodo);
        parameters.Add("@IdGradoSeccion", dto.IdGradoSeccion);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdMatricula", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_MatriculaPeriodo_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdMatricula");
    }

    public async Task CambiarEstadoMatriculaPeriodoAsync(int idMatricula, string estadoMatricula, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdMatricula", idMatricula);
        parameters.Add("@EstadoMatricula", estadoMatricula);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_MatriculaPeriodo_CambiarEstado", parameters, commandType: CommandType.StoredProcedure);
    }
    // Repositories/Implementaciones/AdminRepository.cs (agrega al final)

    public async Task<IEnumerable<SemanaDTO>> ListarSemanasPorUnidadAsync(int idUnidad)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<SemanaDTO>("usp_Admin_Semana_ListarPorUnidad",
            new { IdUnidad = idUnidad }, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> InsertarSemanaAsync(CrearSemanaDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdUnidad", dto.IdUnidad);
        parameters.Add("@NumeroSemana", dto.NumeroSemana);
        parameters.Add("@NombreSemana", dto.NombreSemana);
        parameters.Add("@FechaInicio", dto.FechaInicio);
        parameters.Add("@FechaFin", dto.FechaFin);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@IdSemana", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Semana_Insertar", parameters, commandType: CommandType.StoredProcedure);
        return parameters.Get<int>("@IdSemana");
    }

    public async Task ActualizarSemanaAsync(SemanaDTO dto, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdSemana", dto.IdSemana);
        parameters.Add("@NombreSemana", dto.NombreSemana);
        parameters.Add("@FechaInicio", dto.FechaInicio);
        parameters.Add("@FechaFin", dto.FechaFin);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Semana_Actualizar", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task EliminarSemanaAsync(int idSemana, int idUsuario)
    {
        using var connection = CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("@IdSemana", idSemana);
        parameters.Add("@IdUsuario", idUsuario);
        parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

        await connection.ExecuteAsync("usp_Admin_Semana_Eliminar", parameters, commandType: CommandType.StoredProcedure);
    }
}