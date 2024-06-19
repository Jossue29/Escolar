using System.ComponentModel.DataAnnotations.Schema;

namespace Escolar.Models;

public class Profesor
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Especialidad { get;set; } = string.Empty;
    public ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
}

