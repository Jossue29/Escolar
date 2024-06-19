namespace Escolar.Models;

public interface IrepositorioProfesor
{
    IEnumerable<Profesor> MostrarTodos();
    Profesor? ObtenerPorId(int id);
    void Agregar(Profesor profesor);
    void Actualizar(Profesor profesor);

    void Eliminar(int id);

    void Guardar();
}