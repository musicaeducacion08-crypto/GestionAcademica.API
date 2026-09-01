namespace GestionAcademica.API.DTOs.Admin;

public class HorarioDTO
{
    public int IdHorario { get; set; }
    public int IdAsignacion { get; set; }
    public int IdDiaSemana { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
    public string? Aula { get; set; }
    public bool Estado { get; set; }
    public string? NombreDia { get; set; }
}

public class CrearHorarioDTO
{
    public int IdAsignacion { get; set; }
    public int IdDiaSemana { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
    public string? Aula { get; set; }
}