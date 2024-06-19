namespace Escolar.Models;

public interface IrepositorioEstudiante
{
    IEnumerable<Estudiante> MostrarTodos();
    Estudiante? ObtenerPorId(int id);
    void Agregar(Estudiante estudiante);
    void Actualizar(Estudiante estudiante);

    void Eliminar(int id);

    void Guardar();
}