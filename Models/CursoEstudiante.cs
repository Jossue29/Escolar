using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar.Models;
public class CursoEstudiante
{
    public int EstudianteId { get; set; }
    public virtual Estudiante? Estudiante { get; set; }

    public int CursoId { get; set; }
    public virtual Curso? Curso { get; set; }
}
