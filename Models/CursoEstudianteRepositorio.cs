using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace Escolar.Models
{
    public class CursoEstudianteRepositorio : IRepositorioCursoEstudiante
    {
        private readonly ContextoDb _contexto;

        public CursoEstudianteRepositorio(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        // Mostrar todos los registros de CursoEstudiante
        public IEnumerable<CursoEstudiante> MostrarTodos()
        {
              return _contexto.CursoEstudiantes
                .Include(ce => ce.Curso)
              .Include(ce => ce.Estudiante)
             .ToList();
        }


        // Obtener un registro de CursoEstudiante por IDs de estudiante y curso
        public CursoEstudiante ObtenerPorIDs(int idEstudiante, int idCurso)
        {
            return _contexto.CursoEstudiantes.Include(e => e.Estudiante) 
            .Include(c => c.Curso)
            .FirstOrDefault(ce => ce.EstudianteId == idEstudiante && ce.CursoId == idCurso);
            
        }

        // Agregar un nuevo registro a CursoEstudiante
       public void Agregar(CursoEstudiante cursoEstudiante)
{
    var existente = _contexto.CursoEstudiantes
        .FirstOrDefault(ce => ce.CursoId == cursoEstudiante.CursoId && ce.EstudianteId == cursoEstudiante.EstudianteId);

    if (existente == null)
    {
        _contexto.CursoEstudiantes.Add(cursoEstudiante);
        _contexto.SaveChanges();
    }
    else
    {
        throw new InvalidOperationException("La relación entre el curso y el estudiante ya existe.");
    }
}



        // Actualizar un registro existente en CursoEstudiante
        public void Actualizar(CursoEstudiante cursoEstudiante)
        {
            _contexto.Entry(cursoEstudiante).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        // Eliminar un registro de CursoEstudiante por IDs de estudiante y curso
        public void Eliminar(int idEstudiante, int idCurso)
        {
            var cursoEstudiante = ObtenerPorIDs(idEstudiante, idCurso);
            if (cursoEstudiante != null)
            {
                _contexto.CursoEstudiantes.Remove(cursoEstudiante);
                _contexto.SaveChanges();
            }
        }

        // Guardar cambios en el contexto
        public void Guardar()
        {
            _contexto.SaveChanges();
        }
    }
}
