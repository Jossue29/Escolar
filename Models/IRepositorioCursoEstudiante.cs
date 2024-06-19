namespace Escolar.Models;

public interface IRepositorioCursoEstudiante
{
    IEnumerable<CursoEstudiante> MostrarTodos();
    CursoEstudiante ObtenerPorIDs(int idEstudiante, int idCurso);
    void Agregar(CursoEstudiante cursoEstudiante);
    void Actualizar(CursoEstudiante cursoEstudiante);

    void Eliminar(int idEstudiante, int idCurso);

    void Guardar();
}