namespace Escolar.Models;

public interface IrepositorioAsignatura
{
    IEnumerable<Asignatura> MostrarTodos();
    Asignatura? ObtenerPorId(int id);
    void Agregar(Asignatura asignatura);
    void Actualizar(Asignatura asignatura);

    void Eliminar(int id);

    void Guardar();
}