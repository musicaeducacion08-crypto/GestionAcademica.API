using GestionAcademica.API.DTOs.Admin;
using GestionAcademica.API.DTOs.Docente;

namespace GestionAcademica.API.Repositories.Interfaces;

public interface IDocenteRepository
{
    Task<IEnumerable<CursoDocenteDTO>> ObtenerCursosAsync(int idUsuario);
    Task<IEnumerable<EstudianteNotaDTO>> ObtenerEstudiantesAsync(int idAsignacion, int idUsuario);
    Task GuardarNotaAsync(GuardarNotaDTO dto, int idUsuario);
    Task GuardarAsistenciaAsync(GuardarAsistenciaDTO dto, int idUsuario);
    Task<IEnumerable<AlertaDTO>> ObtenerAlertasAsync(int idUsuario);
    Task RegistrarSeguimientoAsync(SeguimientoAlertaDTO dto, int idUsuario);
    Task<KPIDocenteDTO> ObtenerKPIsAsync(int idUsuario);
    Task<IEnumerable<UnidadDTO>> ObtenerUnidadesAsync(int idAsignacion, int idUsuario);
    Task<IEnumerable<TipoEvaluacionDTO>> ObtenerTiposEvaluacionAsync();
    Task<IEnumerable<EstadoAsistenciaDTO>> ObtenerEstadosAsistenciaAsync();

}