using GestionAcademica.API.DTOs.Admin;

namespace GestionAcademica.API.Repositories.Interfaces;

public interface IAdminRepository
{
    // ============================================================
    // CURSOS
    // ============================================================
    Task<IEnumerable<CursoDTO>> ListarCursosAsync();
    Task<CursoDTO?> ObtenerCursoPorIdAsync(int idCurso);
    Task<int> InsertarCursoAsync(CursoDTO dto, int idUsuario);
    Task ActualizarCursoAsync(CursoDTO dto, int idUsuario);
    Task CambiarEstadoCursoAsync(int idCurso, bool estado, int idUsuario);

    // ============================================================
    // GRADOS
    // ============================================================
    Task<IEnumerable<GradoDTO>> ListarGradosAsync();
    Task<GradoDTO?> ObtenerGradoPorIdAsync(int idGrado);
    Task<int> InsertarGradoAsync(GradoDTO dto, int idUsuario);
    Task ActualizarGradoAsync(GradoDTO dto, int idUsuario);
    Task CambiarEstadoGradoAsync(int idGrado, bool estado, int idUsuario);

    // ============================================================
    // SECCIONES
    // ============================================================
    Task<IEnumerable<SeccionDTO>> ListarSeccionesAsync();
    Task<SeccionDTO?> ObtenerSeccionPorIdAsync(int idSeccion);
    Task<int> InsertarSeccionAsync(SeccionDTO dto, int idUsuario);
    Task ActualizarSeccionAsync(SeccionDTO dto, int idUsuario);
    Task CambiarEstadoSeccionAsync(int idSeccion, bool estado, int idUsuario);

    // ============================================================
    // PERIODOS
    // ============================================================
    Task<IEnumerable<PeriodoDTO>> ListarPeriodosAsync();
    Task<PeriodoDTO?> ObtenerPeriodoPorIdAsync(int idPeriodo);
    Task<int> InsertarPeriodoAsync(PeriodoDTO dto, int idUsuario);
    Task ActualizarPeriodoAsync(PeriodoDTO dto, int idUsuario);
    Task CambiarEstadoPeriodoAsync(int idPeriodo, bool estado, int idUsuario);

    // ============================================================
    // TIPOS DE TRÁMITE
    // ============================================================
    Task<IEnumerable<TipoTramiteDTO>> ListarTiposTramiteAsync();
    Task<TipoTramiteDTO?> ObtenerTipoTramitePorIdAsync(int idTipoTramite);
    Task<int> InsertarTipoTramiteAsync(TipoTramiteDTO dto, int idUsuario);
    Task ActualizarTipoTramiteAsync(TipoTramiteDTO dto, int idUsuario);
    Task CambiarEstadoTipoTramiteAsync(int idTipoTramite, bool estado, int idUsuario);

    // ============================================================
    // ESTADOS DE TRÁMITE
    // ============================================================
    Task<IEnumerable<EstadoTramiteDTO>> ListarEstadosTramiteAsync();
    Task<EstadoTramiteDTO?> ObtenerEstadoTramitePorIdAsync(int idEstadoTramite);
    Task<int> InsertarEstadoTramiteAsync(EstadoTramiteDTO dto, int idUsuario);
    Task ActualizarEstadoTramiteAsync(EstadoTramiteDTO dto, int idUsuario);
    Task CambiarEstadoEstadoTramiteAsync(int idEstadoTramite, bool estado, int idUsuario);

    // ============================================================
    // TIPOS DE EVALUACIÓN
    // ============================================================
    Task<IEnumerable<TipoEvaluacionDTO>> ListarTiposEvaluacionAsync();
    Task<TipoEvaluacionDTO?> ObtenerTipoEvaluacionPorIdAsync(int idTipoEvaluacion);
    Task<int> InsertarTipoEvaluacionAsync(TipoEvaluacionDTO dto, int idUsuario);
    Task ActualizarTipoEvaluacionAsync(TipoEvaluacionDTO dto, int idUsuario);
    Task CambiarEstadoTipoEvaluacionAsync(int idTipoEvaluacion, bool estado, int idUsuario);

    // ============================================================
    // ESTUDIANTES
    // ============================================================
    Task<IEnumerable<EstudianteDTO>> ListarEstudiantesAsync();
    Task<EstudianteDTO?> ObtenerEstudiantePorIdAsync(int idEstudiante);
    Task CambiarEstadoEstudianteAsync(int idEstudiante, bool estado, int idUsuario);

    // ============================================================
    // DOCENTES
    // ============================================================
    Task<IEnumerable<DocenteDTO>> ListarDocentesAsync();
    Task<DocenteDTO?> ObtenerDocentePorIdAsync(int idDocente);
    Task CambiarEstadoDocenteAsync(int idDocente, bool estado, int idUsuario);

    // ============================================================
    // GRADO-SECCION
    // ============================================================
    Task<IEnumerable<GradoSeccionDTO>> ListarGradoSeccionAsync();
    Task<int> InsertarGradoSeccionAsync(CrearGradoSeccionDTO dto, int idUsuario);
    Task EliminarGradoSeccionAsync(int idGradoSeccion, int idUsuario);

    // ============================================================
    // USUARIOS (COMPLETO)
    // ============================================================
    Task<IEnumerable<UsuarioDTO>> ListarUsuariosAsync();
    Task<UsuarioDTO?> ObtenerUsuarioPorIdAsync(int idUsuario);
    Task<int> CrearUsuarioAsync(CrearUsuarioDTO dto, int idUsuarioAdmin);
    Task ActualizarUsuarioAsync(UsuarioDTO dto, int idUsuarioAdmin);
    Task CambiarEstadoUsuarioAsync(int idUsuario, bool estado, int idUsuarioAdmin);

    // ============================================================
    // PERSONAS
    // ============================================================
    Task<IEnumerable<PersonaDTO>> ListarPersonasAsync(string? busqueda = null);
    Task<PersonaDTO?> ObtenerPersonaPorIdAsync(int idPersona);
    Task<int> InsertarPersonaAsync(PersonaDTO dto, int idUsuario);
    Task ActualizarPersonaAsync(PersonaDTO dto, int idUsuario);
    Task CambiarEstadoPersonaAsync(int idPersona, bool estado, int idUsuario);

    // ============================================================
    // SESIONES
    // ============================================================
    Task<IEnumerable<SesionDTO>> ListarSesionesAsync();
    Task<SesionDTO?> ObtenerSesionPorIdAsync(int idSesion);
    Task CambiarEstadoSesionAsync(int idSesion, bool estado, int idUsuario);

    // ============================================================
    // UNIDADES
    // ============================================================
    Task<IEnumerable<UnidadDTO>> ListarUnidadesPorAsignacionAsync(int idAsignacion);
    Task<int> InsertarUnidadAsync(CrearUnidadDTO dto, int idUsuario);
    Task ActualizarUnidadAsync(UnidadDTO dto, int idUsuario);

    // ============================================================
    // LISTA ESTUDIANTES
    // ============================================================
    Task<IEnumerable<ListaEstudianteDTO>> ListarListaEstudiantesPorAsignacionAsync(int idAsignacion);
    Task<int> InsertarListaEstudianteAsync(CrearListaEstudianteDTO dto, int idUsuario);
    Task CambiarEstadoListaEstudianteAsync(int idListaEstudiante, bool estado, int idUsuario);

    // ============================================================
    // HORARIOS
    // ============================================================
    Task<IEnumerable<HorarioDTO>> ListarHorariosAsync(int? idAsignacion = null);
    Task<HorarioDTO?> ObtenerHorarioPorIdAsync(int idHorario);
    Task<int> InsertarHorarioAsync(CrearHorarioDTO dto, int idUsuario);
    Task ActualizarHorarioAsync(HorarioDTO dto, int idUsuario);
    Task EliminarHorarioAsync(int idHorario, int idUsuario);

    // ============================================================
    // ASIGNACIONES
    // ============================================================
    Task<IEnumerable<AsignacionDTO>> ListarAsignacionesAsync();
    Task<AsignacionDTO?> ObtenerAsignacionPorIdAsync(int idAsignacion);
    Task<int> InsertarAsignacionAsync(CrearAsignacionDTO dto, int idUsuario);
    Task CambiarEstadoAsignacionAsync(int idAsignacion, bool estado, int idUsuario);

    // ============================================================
    // MATRÍCULAS PERIODO
    // ============================================================
    Task<IEnumerable<MatriculaPeriodoDTO>> ListarMatriculasPeriodoAsync();
    Task<int> InsertarMatriculaPeriodoAsync(CrearMatriculaPeriodoDTO dto, int idUsuario);
    Task CambiarEstadoMatriculaPeriodoAsync(int idMatricula, string estadoMatricula, int idUsuario);

    // Repositories/Interfaces/IAdminRepository.cs (agrega al final)

    // SEMANAS
    Task<IEnumerable<SemanaDTO>> ListarSemanasPorUnidadAsync(int idUnidad);
    Task<int> InsertarSemanaAsync(CrearSemanaDTO dto, int idUsuario);
    Task ActualizarSemanaAsync(SemanaDTO dto, int idUsuario);
    Task EliminarSemanaAsync(int idSemana, int idUsuario);
}