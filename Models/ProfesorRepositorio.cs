using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Escolar.Models
{
    public class ProfesorRepositorio : IrepositorioProfesor
    {
        private readonly ContextoDb _contexto;

        public ProfesorRepositorio(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        // Mostrar todos los cursos
        public IEnumerable<Profesor> MostrarTodos()
        {
            return _contexto.Profesores.OrderBy(p => p.Nombre).ToList();
        }

        // Obtener curso por ID
        public Profesor ObtenerPorId(int Id)
        {
            return _contexto.Profesores.FirstOrDefault(profesor => profesor.Id == Id);
        }

        // Agregar un nuevo curso
        public void Agregar(Profesor profesor)
        {
            _contexto.Profesores.Add(profesor);
            _contexto.SaveChanges();
        }

        // Actualizar curso existente
        public void Actualizar(Profesor profesor)
        {
            _contexto.Entry(profesor).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        // Eliminar curso por ID
        public void Eliminar(int id)
        {
            var profesor = ObtenerPorId(id);
            if (profesor != null)
            {
                _contexto.Profesores.Remove(profesor);
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
