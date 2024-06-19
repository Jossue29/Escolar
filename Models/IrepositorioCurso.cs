namespace Escolar.Models;

public interface IrepositorioCurso
{
    IEnumerable<Curso> MostrarTodos();
    Curso? ObtenerPorId(int id);
    void Agregar(Curso curso);
    void Actualizar(Curso curso);

    void Eliminar(int id);

    void Guardar();
}