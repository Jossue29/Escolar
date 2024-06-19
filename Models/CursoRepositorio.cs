using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Escolar.Models
{
    public class CursoRepositorio : IrepositorioCurso
    {
        private readonly ContextoDb _contexto;

        public CursoRepositorio(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        // Mostrar todos los cursos
        public IEnumerable<Curso> MostrarTodos()
        {
            return _contexto.Cursos.OrderBy(c => c.Nombre).ToList();
        }

        // Obtener curso por ID
        public Curso ObtenerPorId(int id)
        {
            return _contexto.Cursos.FirstOrDefault(curso => curso.Id == id);
        }

        // Agregar un nuevo curso
        public void Agregar(Curso curso)
        {
            _contexto.Cursos.Add(curso);
            _contexto.SaveChanges();
        }

        // Actualizar curso existente
        public void Actualizar(Curso curso)
        {
            _contexto.Entry(curso).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        // Eliminar curso por ID
        public void Eliminar(int id)
        {
            var curso = ObtenerPorId(id);
            if (curso != null)
            {
                _contexto.Cursos.Remove(curso);
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
