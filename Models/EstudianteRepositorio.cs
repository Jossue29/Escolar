using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Escolar.Models
{
    public class EstudianteRepositorio : IrepositorioEstudiante
    {
        private readonly ContextoDb _contexto;

        public EstudianteRepositorio(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        // Mostrar todos los cursos
        public IEnumerable<Estudiante> MostrarTodos()
        {
            return _contexto.Estudiantes.OrderBy(e => e.Nombre).ToList();
        }

        // Obtener curso por ID
        public Estudiante ObtenerPorId(int Id)
        {
            return _contexto.Estudiantes.FirstOrDefault(estudiante => estudiante.Id == Id);
        }

        // Agregar un nuevo curso
        public void Agregar(Estudiante estudiante)
        {
            _contexto.Estudiantes.Add(estudiante);
            _contexto.SaveChanges();
        }

        // Actualizar curso existente
        public void Actualizar(Estudiante estudiante)
        {
            _contexto.Entry(estudiante).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        // Eliminar curso por ID
        public void Eliminar(int id)
        {
            var estudiante = ObtenerPorId(id) as Estudiante;
            if (estudiante != null)
            {
                _contexto.Estudiantes.Remove(estudiante);
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
