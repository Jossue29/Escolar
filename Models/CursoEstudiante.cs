using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar.Models;
public class CursoEstudiante
{
    public int EstudianteId { get; set; }
    public required Estudiante Estudiante { get; set; }
    
    public int CursoId { get; set; }
    public required Curso Curso { get; set; }
}