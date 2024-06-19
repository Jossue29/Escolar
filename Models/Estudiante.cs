using System.ComponentModel.DataAnnotations.Schema;

namespace Escolar.Models;

public class Estudiante 
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateTime Fecha_Nacimiento { get; set; }
    public string? Correo { get; set; }
    public ICollection<CursoEstudiante> CursoEstudiantes { get; set; } = new List<CursoEstudiante>();
}