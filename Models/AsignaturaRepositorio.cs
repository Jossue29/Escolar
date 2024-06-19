using Microsoft.EntityFrameworkCore;
namespace Escolar.Models
{
    public class AsignaturaRepositorio : IrepositorioAsignatura
    {
        private readonly ContextoDb _InstanciaDb;

        public AsignaturaRepositorio(ContextoDb variableDb)
        {
            _InstanciaDb = variableDb;
        }

        //Mostrar todos
        public IEnumerable<Asignatura> MostrarTodos()
        {
            return _InstanciaDb.Asignaturas
            .Include(c => c.Curso)
            .OrderBy(a => a.NombreAsignatura);
        }

        //Obtener por ID
        public Asignatura? ObtenerPorId(int variableId)
        {
            return _InstanciaDb.Asignaturas
            .Include(c => c.Curso)
            .FirstOrDefault(asi => asi.Id == variableId);
        }

        //Agregar
        public void Agregar(Asignatura asignatura)
        {
            _InstanciaDb.Asignaturas.Add(asignatura);
            _InstanciaDb.SaveChanges();
        }
        

        //Actualizar
        public void Actualizar(Asignatura asignatura)
        {
           _InstanciaDb.Entry(asignatura).State = EntityState.Modified;
            _InstanciaDb.SaveChanges();
        }

        //Eliminar
        public void Eliminar(int id)
        {
            var asignatura = ObtenerPorId(id);
            if (asignatura != null)
            {
                _InstanciaDb.Asignaturas.Remove(asignatura);
                _InstanciaDb.SaveChanges();
            }
        }

        //Guardar
        public void Guardar()
        {
            _InstanciaDb.SaveChanges();
        }
    }
}
