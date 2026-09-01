using GestionAcademica.API.DTOs.Admin;
using GestionAcademica.API.DTOs.Docente;
using GestionAcademica.API.DTOs.Estudiante;
using GestionAcademica.API.DTOs.Shared;
using GestionAcademica.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Controllers.Estudiante;

[ApiController]
[Route("api/estudiante")]
[Authorize(Roles = "Estudiante")]
public class EstudianteController : ControllerBase
{
    private readonly IEstudianteRepository _estudianteRepo;

    public EstudianteController(IEstudianteRepository estudianteRepo)
    {
        _estudianteRepo = estudianteRepo;
    }

    private int GetUserId()
    {
        var claim = User.FindFirst("IdUsuario")?.Value;
        return int.TryParse(claim, out int id) ? id : 0;
    }

    [HttpGet("perfil")]
    public async Task<ActionResult<ResponseDTO<PerfilDTO>>> ObtenerPerfil()
    {
        var data = await _estudianteRepo.ObtenerPerfilAsync(GetUserId());
        return Ok(new ResponseDTO<PerfilDTO> { Success = true, Data = data });
    }

    [HttpPut("perfil")]
    public async Task<ActionResult<ResponseDTO<string>>> ActualizarPerfil([FromBody] ActualizarPerfilDTO dto)
    {
        await _estudianteRepo.ActualizarPerfilAsync(GetUserId(), dto.Telefono, dto.Correo, dto.Direccion);
        return Ok(new ResponseDTO<string> { Success = true, Message = "Perfil actualizado exitosamente." });
    }

    [HttpGet("notas")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<NotaEstudianteDTO>>>> ObtenerNotas()
    {
        var data = await _estudianteRepo.ObtenerNotasAsync(GetUserId());
        return Ok(new ResponseDTO<IEnumerable<NotaEstudianteDTO>> { Success = true, Data = data });
    }

    [HttpGet("resumen-notas")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<ResumenNotasDTO>>>> ObtenerResumenNotas()
    {
        var data = await _estudianteRepo.ObtenerResumenNotasAsync(GetUserId());
        return Ok(new ResponseDTO<IEnumerable<ResumenNotasDTO>> { Success = true, Data = data });
    }

    [HttpGet("asistencias")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<AsistenciaEstudianteDTO>>>> ObtenerAsistencias()
    {
        var data = await _estudianteRepo.ObtenerAsistenciasAsync(GetUserId());
        return Ok(new ResponseDTO<IEnumerable<AsistenciaEstudianteDTO>> { Success = true, Data = data });
    }

    [HttpGet("horario")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<HorarioEstudianteDTO>>>> ObtenerHorario()
    {
        var data = await _estudianteRepo.ObtenerHorarioAsync(GetUserId());
        return Ok(new ResponseDTO<IEnumerable<HorarioEstudianteDTO>> { Success = true, Data = data });
    }

    [HttpGet("alertas")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<AlertaDTO>>>> ObtenerAlertas()
    {
        var data = await _estudianteRepo.ObtenerAlertasAsync(GetUserId());
        return Ok(new ResponseDTO<IEnumerable<AlertaDTO>> { Success = true, Data = data });
    }

    [HttpPost("tramites")]
    public async Task<ActionResult<ResponseDTO<int>>> SolicitarTramite([FromBody] SolicitarTramiteDTO dto)
    {
        var id = await _estudianteRepo.SolicitarTramiteAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Trámite solicitado exitosamente.", Data = id });
    }

    [HttpGet("tramites")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<TramiteDTO>>>> ObtenerTramites()
    {
        var data = await _estudianteRepo.ObtenerTramitesAsync(GetUserId());
        return Ok(new ResponseDTO<IEnumerable<TramiteDTO>> { Success = true, Data = data });
    }

    [HttpGet("historial-tramites")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<HistorialTramiteDTO>>>> ObtenerHistorialTramites()
    {
        var data = await _estudianteRepo.ObtenerHistorialTramitesAsync(GetUserId());
        return Ok(new ResponseDTO<IEnumerable<HistorialTramiteDTO>> { Success = true, Data = data });
    }

    [HttpGet("tipos-tramite")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<TipoTramiteDTO>>>> ObtenerTiposTramite()
    {
        var data = await _estudianteRepo.ObtenerTiposTramiteAsync();
        return Ok(new ResponseDTO<IEnumerable<TipoTramiteDTO>> { Success = true, Data = data });
    }

    [HttpGet("periodos")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<PeriodoEstudianteDTO>>>> ObtenerPeriodos()
    {
        var data = await _estudianteRepo.ObtenerPeriodosAsync(GetUserId());
        return Ok(new ResponseDTO<IEnumerable<PeriodoEstudianteDTO>> { Success = true, Data = data });
    }

    [HttpGet("promedio-general")]
    public async Task<ActionResult<ResponseDTO<PromedioGeneralDTO>>> ObtenerPromedioGeneral()
    {
        var data = await _estudianteRepo.ObtenerPromedioGeneralAsync(GetUserId());
        return Ok(new ResponseDTO<PromedioGeneralDTO> { Success = true, Data = data });
    }

    [HttpPut("cambiar-clave")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarClave([FromBody] CambiarClaveDTO dto)
    {
        await _estudianteRepo.CambiarClaveAsync(GetUserId(), dto.ClaveActual, dto.NuevaClave);
        return Ok(new ResponseDTO<string> { Success = true, Message = "Contraseña actualizada exitosamente." });
    }
    [HttpGet("promedio-unidad")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<PromedioUnidadDTO>>>> ObtenerPromedioUnidad()
    {
        var data = await _estudianteRepo.ObtenerPromedioUnidadAsync(GetUserId());
        return Ok(new ResponseDTO<IEnumerable<PromedioUnidadDTO>> { Success = true, Data = data });
    }
}