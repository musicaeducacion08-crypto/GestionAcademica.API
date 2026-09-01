using GestionAcademica.API.DTOs.Admin;
using GestionAcademica.API.DTOs.Docente;
using GestionAcademica.API.DTOs.Estudiante;

namespace GestionAcademica.API.Repositories.Interfaces;

public interface IEstudianteRepository
{
    Task<PerfilDTO?> ObtenerPerfilAsync(int idUsuario);
    Task ActualizarPerfilAsync(int idUsuario, string? telefono, string? correo, string? direccion);
    Task<IEnumerable<NotaEstudianteDTO>> ObtenerNotasAsync(int idUsuario);
    Task<IEnumerable<ResumenNotasDTO>> ObtenerResumenNotasAsync(int idUsuario);
    Task<IEnumerable<AsistenciaEstudianteDTO>> ObtenerAsistenciasAsync(int idUsuario);
    Task<IEnumerable<HorarioEstudianteDTO>> ObtenerHorarioAsync(int idUsuario);
    Task<IEnumerable<AlertaDTO>> ObtenerAlertasAsync(int idUsuario);
    Task<int> SolicitarTramiteAsync(SolicitarTramiteDTO dto, int idUsuario);
    Task<IEnumerable<TramiteDTO>> ObtenerTramitesAsync(int idUsuario);
    Task<IEnumerable<HistorialTramiteDTO>> ObtenerHistorialTramitesAsync(int idUsuario);
    Task<IEnumerable<TipoTramiteDTO>> ObtenerTiposTramiteAsync();
    Task<IEnumerable<PeriodoEstudianteDTO>> ObtenerPeriodosAsync(int idUsuario);
    Task<PromedioGeneralDTO> ObtenerPromedioGeneralAsync(int idUsuario);
    Task CambiarClaveAsync(int idUsuario, string claveActual, string nuevaClave);
    Task<IEnumerable<PromedioUnidadDTO>> ObtenerPromedioUnidadAsync(int idUsuario);
}