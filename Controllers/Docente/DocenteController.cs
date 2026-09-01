using GestionAcademica.API.DTOs.Admin;
using GestionAcademica.API.DTOs.Docente;
using GestionAcademica.API.DTOs.Shared;
using GestionAcademica.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Controllers.Docente;

[ApiController]
[Route("api/docente")]
[Authorize(Roles = "Docente")]
public class DocenteController : ControllerBase
{
    private readonly IDocenteRepository _docenteRepo;

    public DocenteController(IDocenteRepository docenteRepo)
    {
        _docenteRepo = docenteRepo;
    }

    private int GetUserId()
    {
        var claim = User.FindFirst("IdUsuario")?.Value;
        return int.TryParse(claim, out int id) ? id : 0;
    }

    [HttpGet("cursos")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<CursoDocenteDTO>>>> ObtenerCursos()
    {
        var data = await _docenteRepo.ObtenerCursosAsync(GetUserId());
        return Ok(new ResponseDTO<IEnumerable<CursoDocenteDTO>> { Success = true, Data = data });
    }

    [HttpGet("estudiantes/{idAsignacion}")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<EstudianteNotaDTO>>>> ObtenerEstudiantes(int idAsignacion)
    {
        var data = await _docenteRepo.ObtenerEstudiantesAsync(idAsignacion, GetUserId());
        return Ok(new ResponseDTO<IEnumerable<EstudianteNotaDTO>> { Success = true, Data = data });
    }
    // Controllers/Docente/DocenteController.cs

    [HttpPost("notas")]
    public async Task<ActionResult<ResponseDTO<string>>> GuardarNota([FromBody] GuardarNotaDTO dto)
    {
        await _docenteRepo.GuardarNotaAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Nota guardada exitosamente." });
    }

    [HttpPost("asistencias")]
    public async Task<ActionResult<ResponseDTO<string>>> GuardarAsistencia([FromBody] GuardarAsistenciaDTO dto)
    {
        await _docenteRepo.GuardarAsistenciaAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Asistencia guardada exitosamente." });
    }

    [HttpGet("alertas")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<AlertaDTO>>>> ObtenerAlertas()
    {
        var data = await _docenteRepo.ObtenerAlertasAsync(GetUserId());
        return Ok(new ResponseDTO<IEnumerable<AlertaDTO>> { Success = true, Data = data });
    }

    [HttpPost("alertas/seguimiento")]
    public async Task<ActionResult<ResponseDTO<string>>> RegistrarSeguimiento([FromBody] SeguimientoAlertaDTO dto)
    {
        await _docenteRepo.RegistrarSeguimientoAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Seguimiento registrado exitosamente." });
    }

    [HttpGet("kpis")]
    public async Task<ActionResult<ResponseDTO<KPIDocenteDTO>>> ObtenerKPIs()
    {
        var data = await _docenteRepo.ObtenerKPIsAsync(GetUserId());
        return Ok(new ResponseDTO<KPIDocenteDTO> { Success = true, Data = data });
    }

    [HttpGet("unidades/{idAsignacion}")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<UnidadDTO>>>> ObtenerUnidades(int idAsignacion)
    {
        var data = await _docenteRepo.ObtenerUnidadesAsync(idAsignacion, GetUserId());
        return Ok(new ResponseDTO<IEnumerable<UnidadDTO>> { Success = true, Data = data });
    }

    [HttpGet("tipos-evaluacion")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<TipoEvaluacionDTO>>>> ObtenerTiposEvaluacion()
    {
        var data = await _docenteRepo.ObtenerTiposEvaluacionAsync();
        return Ok(new ResponseDTO<IEnumerable<TipoEvaluacionDTO>> { Success = true, Data = data });
    }

    [HttpGet("estados-asistencia")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<EstadoAsistenciaDTO>>>> ObtenerEstadosAsistencia()
    {
        var data = await _docenteRepo.ObtenerEstadosAsistenciaAsync();
        return Ok(new ResponseDTO<IEnumerable<EstadoAsistenciaDTO>> { Success = true, Data = data });
    }
}