using GestionAcademica.API.DTOs.Admin;
using GestionAcademica.API.DTOs.Shared;
using GestionAcademica.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionAcademica.API.Controllers.Admin;

[ApiController]
[Route("api/admin")]
[Authorize(Roles = "Administrador")]
public class AdminController : ControllerBase
{
    private readonly IAdminRepository _adminRepo;

    public AdminController(IAdminRepository adminRepo)
    {
        _adminRepo = adminRepo;
    }

    private int GetUserId()
    {
        var claim = User.FindFirst("IdUsuario")?.Value;
        return int.TryParse(claim, out int id) ? id : 0;
    }

    // ============================================================
    // CURSOS
    // ============================================================
    [HttpGet("cursos")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<CursoDTO>>>> ListarCursos()
    {
        var data = await _adminRepo.ListarCursosAsync();
        return Ok(new ResponseDTO<IEnumerable<CursoDTO>> { Success = true, Data = data });
    }

    [HttpGet("cursos/{id}")]
    public async Task<ActionResult<ResponseDTO<CursoDTO>>> ObtenerCurso(int id)
    {
        var data = await _adminRepo.ObtenerCursoPorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<CursoDTO> { Success = false, Message = "Curso no encontrado." });
        return Ok(new ResponseDTO<CursoDTO> { Success = true, Data = data });
    }

    [HttpPost("cursos")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearCurso([FromBody] CursoDTO dto)
    {
        var id = await _adminRepo.InsertarCursoAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Curso creado exitosamente.", Data = id });
    }

    [HttpPut("cursos")]
    public async Task<ActionResult<ResponseDTO<string>>> ActualizarCurso([FromBody] CursoDTO dto)
    {
        await _adminRepo.ActualizarCursoAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Curso actualizado exitosamente." });
    }

    [HttpPatch("cursos/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoCurso(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoCursoAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Curso {(estado ? "activado" : "desactivado")} exitosamente." });
    }

    // ============================================================
    // GRADOS
    // ============================================================
    [HttpGet("grados")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<GradoDTO>>>> ListarGrados()
    {
        var data = await _adminRepo.ListarGradosAsync();
        return Ok(new ResponseDTO<IEnumerable<GradoDTO>> { Success = true, Data = data });
    }

    [HttpGet("grados/{id}")]
    public async Task<ActionResult<ResponseDTO<GradoDTO>>> ObtenerGrado(int id)
    {
        var data = await _adminRepo.ObtenerGradoPorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<GradoDTO> { Success = false, Message = "Grado no encontrado." });
        return Ok(new ResponseDTO<GradoDTO> { Success = true, Data = data });
    }

    [HttpPost("grados")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearGrado([FromBody] GradoDTO dto)
    {
        var id = await _adminRepo.InsertarGradoAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Grado creado exitosamente.", Data = id });
    }

    [HttpPut("grados")]
    public async Task<ActionResult<ResponseDTO<string>>> ActualizarGrado([FromBody] GradoDTO dto)
    {
        await _adminRepo.ActualizarGradoAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Grado actualizado exitosamente." });
    }

    [HttpPatch("grados/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoGrado(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoGradoAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Grado {(estado ? "activado" : "desactivado")} exitosamente." });
    }

    // ============================================================
    // SECCIONES
    // ============================================================
    [HttpGet("secciones")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<SeccionDTO>>>> ListarSecciones()
    {
        var data = await _adminRepo.ListarSeccionesAsync();
        return Ok(new ResponseDTO<IEnumerable<SeccionDTO>> { Success = true, Data = data });
    }

    [HttpGet("secciones/{id}")]
    public async Task<ActionResult<ResponseDTO<SeccionDTO>>> ObtenerSeccion(int id)
    {
        var data = await _adminRepo.ObtenerSeccionPorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<SeccionDTO> { Success = false, Message = "Sección no encontrada." });
        return Ok(new ResponseDTO<SeccionDTO> { Success = true, Data = data });
    }

    [HttpPost("secciones")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearSeccion([FromBody] SeccionDTO dto)
    {
        var id = await _adminRepo.InsertarSeccionAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Sección creada exitosamente.", Data = id });
    }

    [HttpPut("secciones")]
    public async Task<ActionResult<ResponseDTO<string>>> ActualizarSeccion([FromBody] SeccionDTO dto)
    {
        await _adminRepo.ActualizarSeccionAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Sección actualizada exitosamente." });
    }

    [HttpPatch("secciones/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoSeccion(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoSeccionAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Sección {(estado ? "activada" : "desactivada")} exitosamente." });
    }

    // ============================================================
    // PERIODOS
    // ============================================================
    [HttpGet("periodos")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<PeriodoDTO>>>> ListarPeriodos()
    {
        var data = await _adminRepo.ListarPeriodosAsync();
        return Ok(new ResponseDTO<IEnumerable<PeriodoDTO>> { Success = true, Data = data });
    }

    [HttpGet("periodos/{id}")]
    public async Task<ActionResult<ResponseDTO<PeriodoDTO>>> ObtenerPeriodo(int id)
    {
        var data = await _adminRepo.ObtenerPeriodoPorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<PeriodoDTO> { Success = false, Message = "Periodo no encontrado." });
        return Ok(new ResponseDTO<PeriodoDTO> { Success = true, Data = data });
    }

    [HttpPost("periodos")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearPeriodo([FromBody] PeriodoDTO dto)
    {
        var id = await _adminRepo.InsertarPeriodoAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Periodo creado exitosamente.", Data = id });
    }

    [HttpPut("periodos")]
    public async Task<ActionResult<ResponseDTO<string>>> ActualizarPeriodo([FromBody] PeriodoDTO dto)
    {
        await _adminRepo.ActualizarPeriodoAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Periodo actualizado exitosamente." });
    }

    [HttpPatch("periodos/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoPeriodo(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoPeriodoAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Periodo {(estado ? "activado" : "desactivado")} exitosamente." });
    }

    // ============================================================
    // TIPOS DE TRÁMITE
    // ============================================================
    [HttpGet("tipos-tramite")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<TipoTramiteDTO>>>> ListarTiposTramite()
    {
        var data = await _adminRepo.ListarTiposTramiteAsync();
        return Ok(new ResponseDTO<IEnumerable<TipoTramiteDTO>> { Success = true, Data = data });
    }

    [HttpGet("tipos-tramite/{id}")]
    public async Task<ActionResult<ResponseDTO<TipoTramiteDTO>>> ObtenerTipoTramite(int id)
    {
        var data = await _adminRepo.ObtenerTipoTramitePorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<TipoTramiteDTO> { Success = false, Message = "Tipo de trámite no encontrado." });
        return Ok(new ResponseDTO<TipoTramiteDTO> { Success = true, Data = data });
    }

    [HttpPost("tipos-tramite")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearTipoTramite([FromBody] TipoTramiteDTO dto)
    {
        var id = await _adminRepo.InsertarTipoTramiteAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Tipo de trámite creado exitosamente.", Data = id });
    }

    [HttpPut("tipos-tramite")]
    public async Task<ActionResult<ResponseDTO<string>>> ActualizarTipoTramite([FromBody] TipoTramiteDTO dto)
    {
        await _adminRepo.ActualizarTipoTramiteAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Tipo de trámite actualizado exitosamente." });
    }

    [HttpPatch("tipos-tramite/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoTipoTramite(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoTipoTramiteAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Tipo de trámite {(estado ? "activado" : "desactivado")} exitosamente." });
    }

    // ============================================================
    // ESTADOS DE TRÁMITE
    // ============================================================
    [HttpGet("estados-tramite")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<EstadoTramiteDTO>>>> ListarEstadosTramite()
    {
        var data = await _adminRepo.ListarEstadosTramiteAsync();
        return Ok(new ResponseDTO<IEnumerable<EstadoTramiteDTO>> { Success = true, Data = data });
    }

    [HttpGet("estados-tramite/{id}")]
    public async Task<ActionResult<ResponseDTO<EstadoTramiteDTO>>> ObtenerEstadoTramite(int id)
    {
        var data = await _adminRepo.ObtenerEstadoTramitePorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<EstadoTramiteDTO> { Success = false, Message = "Estado de trámite no encontrado." });
        return Ok(new ResponseDTO<EstadoTramiteDTO> { Success = true, Data = data });
    }

    [HttpPost("estados-tramite")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearEstadoTramite([FromBody] EstadoTramiteDTO dto)
    {
        var id = await _adminRepo.InsertarEstadoTramiteAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Estado de trámite creado exitosamente.", Data = id });
    }

    [HttpPut("estados-tramite")]
    public async Task<ActionResult<ResponseDTO<string>>> ActualizarEstadoTramite([FromBody] EstadoTramiteDTO dto)
    {
        await _adminRepo.ActualizarEstadoTramiteAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Estado de trámite actualizado exitosamente." });
    }

    [HttpPatch("estados-tramite/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoEstadoTramite(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoEstadoTramiteAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Estado de trámite {(estado ? "activado" : "desactivado")} exitosamente." });
    }

    // ============================================================
    // TIPOS DE EVALUACIÓN
    // ============================================================
    [HttpGet("tipos-evaluacion")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<TipoEvaluacionDTO>>>> ListarTiposEvaluacion()
    {
        var data = await _adminRepo.ListarTiposEvaluacionAsync();
        return Ok(new ResponseDTO<IEnumerable<TipoEvaluacionDTO>> { Success = true, Data = data });
    }

    [HttpGet("tipos-evaluacion/{id}")]
    public async Task<ActionResult<ResponseDTO<TipoEvaluacionDTO>>> ObtenerTipoEvaluacion(int id)
    {
        var data = await _adminRepo.ObtenerTipoEvaluacionPorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<TipoEvaluacionDTO> { Success = false, Message = "Tipo de evaluación no encontrado." });
        return Ok(new ResponseDTO<TipoEvaluacionDTO> { Success = true, Data = data });
    }

    [HttpPost("tipos-evaluacion")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearTipoEvaluacion([FromBody] TipoEvaluacionDTO dto)
    {
        var id = await _adminRepo.InsertarTipoEvaluacionAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Tipo de evaluación creado exitosamente.", Data = id });
    }

    [HttpPut("tipos-evaluacion")]
    public async Task<ActionResult<ResponseDTO<string>>> ActualizarTipoEvaluacion([FromBody] TipoEvaluacionDTO dto)
    {
        await _adminRepo.ActualizarTipoEvaluacionAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Tipo de evaluación actualizado exitosamente." });
    }

    [HttpPatch("tipos-evaluacion/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoTipoEvaluacion(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoTipoEvaluacionAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Tipo de evaluación {(estado ? "activado" : "desactivado")} exitosamente." });
    }

    // ============================================================
    // ESTUDIANTES
    // ============================================================
    [HttpGet("estudiantes")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<EstudianteDTO>>>> ListarEstudiantes()
    {
        var data = await _adminRepo.ListarEstudiantesAsync();
        return Ok(new ResponseDTO<IEnumerable<EstudianteDTO>> { Success = true, Data = data });
    }

    [HttpGet("estudiantes/{id}")]
    public async Task<ActionResult<ResponseDTO<EstudianteDTO>>> ObtenerEstudiante(int id)
    {
        var data = await _adminRepo.ObtenerEstudiantePorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<EstudianteDTO> { Success = false, Message = "Estudiante no encontrado." });
        return Ok(new ResponseDTO<EstudianteDTO> { Success = true, Data = data });
    }

    [HttpPatch("estudiantes/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoEstudiante(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoEstudianteAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Estudiante {(estado ? "activado" : "desactivado")} exitosamente." });
    }

    // ============================================================
    // DOCENTES
    // ============================================================
    [HttpGet("docentes")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<DocenteDTO>>>> ListarDocentes()
    {
        var data = await _adminRepo.ListarDocentesAsync();
        return Ok(new ResponseDTO<IEnumerable<DocenteDTO>> { Success = true, Data = data });
    }

    [HttpGet("docentes/{id}")]
    public async Task<ActionResult<ResponseDTO<DocenteDTO>>> ObtenerDocente(int id)
    {
        var data = await _adminRepo.ObtenerDocentePorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<DocenteDTO> { Success = false, Message = "Docente no encontrado." });
        return Ok(new ResponseDTO<DocenteDTO> { Success = true, Data = data });
    }

    [HttpPatch("docentes/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoDocente(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoDocenteAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Docente {(estado ? "activado" : "desactivado")} exitosamente." });
    }

    // ============================================================
    // GRADO-SECCION
    // ============================================================
    [HttpGet("grado-seccion")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<GradoSeccionDTO>>>> ListarGradoSeccion()
    {
        var data = await _adminRepo.ListarGradoSeccionAsync();
        return Ok(new ResponseDTO<IEnumerable<GradoSeccionDTO>> { Success = true, Data = data });
    }

    [HttpPost("grado-seccion")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearGradoSeccion([FromBody] CrearGradoSeccionDTO dto)
    {
        var id = await _adminRepo.InsertarGradoSeccionAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Asignación creada exitosamente.", Data = id });
    }

    [HttpDelete("grado-seccion/{id}")]
    public async Task<ActionResult<ResponseDTO<string>>> EliminarGradoSeccion(int id)
    {
        await _adminRepo.EliminarGradoSeccionAsync(id, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Asignación eliminada exitosamente." });
    }

    // ============================================================
    // USUARIOS (CRUD COMPLETO)
    // ============================================================
    [HttpGet("usuarios")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<UsuarioDTO>>>> ListarUsuarios()
    {
        var data = await _adminRepo.ListarUsuariosAsync();
        return Ok(new ResponseDTO<IEnumerable<UsuarioDTO>> { Success = true, Data = data });
    }

    [HttpGet("usuarios/{id}")]
    public async Task<ActionResult<ResponseDTO<UsuarioDTO>>> ObtenerUsuario(int id)
    {
        var data = await _adminRepo.ObtenerUsuarioPorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<UsuarioDTO> { Success = false, Message = "Usuario no encontrado." });
        return Ok(new ResponseDTO<UsuarioDTO> { Success = true, Data = data });
    }

    [HttpPost("usuarios")]
    public async Task<ActionResult<ResponseDTO<UsuarioResponseDTO>>> CrearUsuario([FromBody] CrearUsuarioDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.TipoDocumento) || string.IsNullOrWhiteSpace(dto.NumeroDocumento) ||
            string.IsNullOrWhiteSpace(dto.Nombres) || string.IsNullOrWhiteSpace(dto.ApellidoPaterno) ||
            string.IsNullOrWhiteSpace(dto.NombreUsuario) || string.IsNullOrWhiteSpace(dto.Clave))
        {
            return BadRequest(new ResponseDTO<UsuarioResponseDTO>
            {
                Success = false,
                Message = "Todos los campos obligatorios deben ser completados."
            });
        }

        var idUsuario = await _adminRepo.CrearUsuarioAsync(dto, GetUserId());
        if (idUsuario == 0)
            return BadRequest(new ResponseDTO<UsuarioResponseDTO> { Success = false, Message = "Error al crear el usuario." });

        return Ok(new ResponseDTO<UsuarioResponseDTO>
        {
            Success = true,
            Message = "Usuario creado exitosamente.",
            Data = new UsuarioResponseDTO { IdUsuario = idUsuario }
        });
    }

    [HttpPut("usuarios")]
    public async Task<ActionResult<ResponseDTO<string>>> ActualizarUsuario([FromBody] UsuarioDTO dto)
    {
        await _adminRepo.ActualizarUsuarioAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Usuario actualizado exitosamente." });
    }

    [HttpPatch("usuarios/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoUsuario(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoUsuarioAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Usuario {(estado ? "activado" : "desactivado")} exitosamente." });
    }

    // ============================================================
    // PERSONAS
    // ============================================================
    [HttpGet("personas")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<PersonaDTO>>>> ListarPersonas([FromQuery] string? busqueda = null)
    {
        var data = await _adminRepo.ListarPersonasAsync(busqueda);
        return Ok(new ResponseDTO<IEnumerable<PersonaDTO>> { Success = true, Data = data });
    }

    [HttpGet("personas/{id}")]
    public async Task<ActionResult<ResponseDTO<PersonaDTO>>> ObtenerPersona(int id)
    {
        var data = await _adminRepo.ObtenerPersonaPorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<PersonaDTO> { Success = false, Message = "Persona no encontrada." });
        return Ok(new ResponseDTO<PersonaDTO> { Success = true, Data = data });
    }

    [HttpPost("personas")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearPersona([FromBody] PersonaDTO dto)
    {
        var id = await _adminRepo.InsertarPersonaAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Persona creada exitosamente.", Data = id });
    }

    [HttpPut("personas")]
    public async Task<ActionResult<ResponseDTO<string>>> ActualizarPersona([FromBody] PersonaDTO dto)
    {
        await _adminRepo.ActualizarPersonaAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Persona actualizada exitosamente." });
    }

    [HttpPatch("personas/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoPersona(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoPersonaAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Persona {(estado ? "activada" : "desactivada")} exitosamente." });
    }

    // ============================================================
    // SESIONES
    // ============================================================
    [HttpGet("sesiones")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<SesionDTO>>>> ListarSesiones()
    {
        var data = await _adminRepo.ListarSesionesAsync();
        return Ok(new ResponseDTO<IEnumerable<SesionDTO>> { Success = true, Data = data });
    }

    [HttpGet("sesiones/{id}")]
    public async Task<ActionResult<ResponseDTO<SesionDTO>>> ObtenerSesion(int id)
    {
        var data = await _adminRepo.ObtenerSesionPorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<SesionDTO> { Success = false, Message = "Sesión no encontrada." });
        return Ok(new ResponseDTO<SesionDTO> { Success = true, Data = data });
    }

    [HttpPatch("sesiones/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoSesion(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoSesionAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Sesión {(estado ? "activada" : "desactivada")} exitosamente." });
    }

    // ============================================================
    // UNIDADES
    // ============================================================
    [HttpGet("unidades/{idAsignacion}")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<UnidadDTO>>>> ListarUnidadesPorAsignacion(int idAsignacion)
    {
        var data = await _adminRepo.ListarUnidadesPorAsignacionAsync(idAsignacion);
        return Ok(new ResponseDTO<IEnumerable<UnidadDTO>> { Success = true, Data = data });
    }

    [HttpPost("unidades")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearUnidad([FromBody] CrearUnidadDTO dto)
    {
        var id = await _adminRepo.InsertarUnidadAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Unidad creada exitosamente.", Data = id });
    }

    [HttpPut("unidades")]
    public async Task<ActionResult<ResponseDTO<string>>> ActualizarUnidad([FromBody] UnidadDTO dto)
    {
        await _adminRepo.ActualizarUnidadAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Unidad actualizada exitosamente." });
    }

    // ============================================================
    // LISTA ESTUDIANTES
    // ============================================================
    [HttpGet("asignaciones/{id}/estudiantes")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<ListaEstudianteDTO>>>> ListarEstudiantesPorAsignacion(int id)
    {
        var data = await _adminRepo.ListarListaEstudiantesPorAsignacionAsync(id);
        return Ok(new ResponseDTO<IEnumerable<ListaEstudianteDTO>> { Success = true, Data = data });
    }

    [HttpPost("asignaciones/estudiantes")]
    public async Task<ActionResult<ResponseDTO<int>>> InscribirEstudianteEnAsignacion([FromBody] CrearListaEstudianteDTO dto)
    {
        var id = await _adminRepo.InsertarListaEstudianteAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Estudiante inscrito en la asignación exitosamente.", Data = id });
    }

    [HttpPatch("asignaciones/estudiantes/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoInscripcion(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoListaEstudianteAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Inscripción {(estado ? "activada" : "desactivada")} exitosamente." });
    }

    // ============================================================
    // HORARIOS
    // ============================================================
    [HttpGet("horarios")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<HorarioDTO>>>> ListarHorarios([FromQuery] int? idAsignacion = null)
    {
        var data = await _adminRepo.ListarHorariosAsync(idAsignacion);
        return Ok(new ResponseDTO<IEnumerable<HorarioDTO>> { Success = true, Data = data });
    }

    [HttpGet("horarios/{id}")]
    public async Task<ActionResult<ResponseDTO<HorarioDTO>>> ObtenerHorario(int id)
    {
        var data = await _adminRepo.ObtenerHorarioPorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<HorarioDTO> { Success = false, Message = "Horario no encontrado." });
        return Ok(new ResponseDTO<HorarioDTO> { Success = true, Data = data });
    }

    [HttpPost("horarios")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearHorario([FromBody] CrearHorarioDTO dto)
    {
        var id = await _adminRepo.InsertarHorarioAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Horario creado exitosamente.", Data = id });
    }

    [HttpPut("horarios")]
    public async Task<ActionResult<ResponseDTO<string>>> ActualizarHorario([FromBody] HorarioDTO dto)
    {
        await _adminRepo.ActualizarHorarioAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Horario actualizado exitosamente." });
    }

    [HttpDelete("horarios/{id}")]
    public async Task<ActionResult<ResponseDTO<string>>> EliminarHorario(int id)
    {
        await _adminRepo.EliminarHorarioAsync(id, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Horario eliminado exitosamente." });
    }

    // ============================================================
    // ASIGNACIONES
    // ============================================================
    [HttpGet("asignaciones")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<AsignacionDTO>>>> ListarAsignaciones()
    {
        var data = await _adminRepo.ListarAsignacionesAsync();
        return Ok(new ResponseDTO<IEnumerable<AsignacionDTO>> { Success = true, Data = data });
    }

    [HttpGet("asignaciones/{id}")]
    public async Task<ActionResult<ResponseDTO<AsignacionDTO>>> ObtenerAsignacion(int id)
    {
        var data = await _adminRepo.ObtenerAsignacionPorIdAsync(id);
        if (data == null)
            return NotFound(new ResponseDTO<AsignacionDTO> { Success = false, Message = "Asignación no encontrada." });
        return Ok(new ResponseDTO<AsignacionDTO> { Success = true, Data = data });
    }

    [HttpPost("asignaciones")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearAsignacion([FromBody] CrearAsignacionDTO dto)
    {
        var id = await _adminRepo.InsertarAsignacionAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Asignación creada exitosamente.", Data = id });
    }

    [HttpPatch("asignaciones/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoAsignacion(int id, [FromBody] bool estado)
    {
        await _adminRepo.CambiarEstadoAsignacionAsync(id, estado, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Asignación {(estado ? "activada" : "desactivada")} exitosamente." });
    }

    // ============================================================
    // MATRÍCULAS PERIODO
    // ============================================================
    [HttpGet("matriculas-periodo")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<MatriculaPeriodoDTO>>>> ListarMatriculasPeriodo()
    {
        var data = await _adminRepo.ListarMatriculasPeriodoAsync();
        return Ok(new ResponseDTO<IEnumerable<MatriculaPeriodoDTO>> { Success = true, Data = data });
    }

    [HttpPost("matriculas-periodo")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearMatriculaPeriodo([FromBody] CrearMatriculaPeriodoDTO dto)
    {
        var id = await _adminRepo.InsertarMatriculaPeriodoAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Matrícula creada exitosamente.", Data = id });
    }

    [HttpPatch("matriculas-periodo/{id}/estado")]
    public async Task<ActionResult<ResponseDTO<string>>> CambiarEstadoMatriculaPeriodo(int id, [FromBody] string estadoMatricula)
    {
        await _adminRepo.CambiarEstadoMatriculaPeriodoAsync(id, estadoMatricula, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = $"Estado de matrícula cambiado a '{estadoMatricula}' exitosamente." });
    }
    // Controllers/Admin/AdminController.cs (agrega al final)

    [HttpGet("semanas/{idUnidad}")]
    public async Task<ActionResult<ResponseDTO<IEnumerable<SemanaDTO>>>> ListarSemanasPorUnidad(int idUnidad)
    {
        var data = await _adminRepo.ListarSemanasPorUnidadAsync(idUnidad);
        return Ok(new ResponseDTO<IEnumerable<SemanaDTO>> { Success = true, Data = data });
    }

    [HttpPost("semanas")]
    public async Task<ActionResult<ResponseDTO<int>>> CrearSemana([FromBody] CrearSemanaDTO dto)
    {
        var id = await _adminRepo.InsertarSemanaAsync(dto, GetUserId());
        return Ok(new ResponseDTO<int> { Success = true, Message = "Semana creada exitosamente.", Data = id });
    }

    [HttpPut("semanas")]
    public async Task<ActionResult<ResponseDTO<string>>> ActualizarSemana([FromBody] SemanaDTO dto)
    {
        await _adminRepo.ActualizarSemanaAsync(dto, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Semana actualizada exitosamente." });
    }

    [HttpDelete("semanas/{id}")]
    public async Task<ActionResult<ResponseDTO<string>>> EliminarSemana(int id)
    {
        await _adminRepo.EliminarSemanaAsync(id, GetUserId());
        return Ok(new ResponseDTO<string> { Success = true, Message = "Semana eliminada exitosamente." });
    }
}