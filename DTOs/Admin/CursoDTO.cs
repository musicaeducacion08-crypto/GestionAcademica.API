namespace GestionAcademica.API.DTOs.Admin;

public class CursoDTO
{
    public int IdCurso { get; set; }
    public string? CodigoCurso { get; set; }
    public string? NombreCurso { get; set; }
    public string? Descripcion { get; set; }
    public int? HorasSemanales { get; set; }
    public bool Estado { get; set; }
}