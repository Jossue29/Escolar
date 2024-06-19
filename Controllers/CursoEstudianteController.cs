using Escolar.Models; // Asegúrate de incluir el namespace correcto de tu repositorio
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Escolar.Controllers
{
    public class CursoEstudianteController : Controller
    {
        private readonly IRepositorioCursoEstudiante _repositorioCursoEstudiante;

        public CursoEstudianteController(IRepositorioCursoEstudiante repositorioCursoEstudiante)
        {
            _repositorioCursoEstudiante = repositorioCursoEstudiante;
        }

        public IActionResult Index()
        {
            var cursosEstudiantes = _repositorioCursoEstudiante.MostrarTodos();
            return View(cursosEstudiantes);
        }

        public IActionResult Detalles(int idEstudiante, int idCurso)
        {
            var cursoEstudiante = _repositorioCursoEstudiante.ObtenerPorIDs(idEstudiante, idCurso);
            if (cursoEstudiante == null)
            {
                return NotFound();
            }
            return View(cursoEstudiante);
        }

        public IActionResult Agregar()
        {
            // Implementación de lógica para mostrar formulario de agregar
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(CursoEstudiante cursoEstudiante)
        {
            if (ModelState.IsValid)
            {
                _repositorioCursoEstudiante.Agregar(cursoEstudiante);
                _repositorioCursoEstudiante.Guardar();
                return RedirectToAction(nameof(Index));
            }
            return View(cursoEstudiante);
        }

        public IActionResult Editar(int idEstudiante, int idCurso)
        {
            var cursoEstudiante = _repositorioCursoEstudiante.ObtenerPorIDs(idEstudiante, idCurso);
            if (cursoEstudiante == null)
            {
                return NotFound();
            }
            return View(cursoEstudiante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(CursoEstudiante cursoEstudiante)
        {
            if (ModelState.IsValid)
            {
                _repositorioCursoEstudiante.Actualizar(cursoEstudiante);
                _repositorioCursoEstudiante.Guardar();
                return RedirectToAction(nameof(Index));
            }
            return View(cursoEstudiante);
        }

        public IActionResult Eliminar(int idEstudiante, int idCurso)
        {
            var cursoEstudiante = _repositorioCursoEstudiante.ObtenerPorIDs(idEstudiante, idCurso);
            if (cursoEstudiante == null)
            {
                return NotFound();
            }
            return View(cursoEstudiante);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarEliminar(int idEstudiante, int idCurso)
        {
            _repositorioCursoEstudiante.Eliminar(idEstudiante, idCurso);
            _repositorioCursoEstudiante.Guardar();
            return RedirectToAction(nameof(Index));
        }
    }
}
