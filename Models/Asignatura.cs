using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar.Models;

public class Asignatura
{
    public int Id { get; set; }
    public string NombreAsignatura { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    
    [ForeignKey("Profesor")]
    public int ProfesorId { get; set; }
    public Profesor? Profesor { get; set; }
    
    [ForeignKey("Curso")]
    public int CursoId { get; set; }
    public Curso? Curso{ get; set; }
}
