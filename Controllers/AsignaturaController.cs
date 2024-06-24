using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Escolar.Models;
using Microsoft.EntityFrameworkCore;

namespace Escolar.Controllers
{
    public class AsignaturaController : Controller
    {
        private readonly IrepositorioAsignatura _InstanciaAsignaturaRepo;
        private readonly IrepositorioCurso _InstanciaCursoRepo;
        private readonly IrepositorioProfesor _InstanciaProfesorRepo;

        public AsignaturaController(IrepositorioAsignatura variableAsignaturaRepo, IrepositorioCurso variableCursoRepo, IrepositorioProfesor variableProfesorRepo)
        {
            _InstanciaAsignaturaRepo = variableAsignaturaRepo;
            _InstanciaCursoRepo = variableCursoRepo;
            _InstanciaProfesorRepo = variableProfesorRepo;
        }

        public IActionResult Index()
        {
            var asignaturas = _InstanciaAsignaturaRepo.MostrarTodos();
            return View(asignaturas);
        }

        public IActionResult Detalles(int Id)
        {
            var asignatura = _InstanciaAsignaturaRepo.ObtenerPorId(Id);

            if (asignatura == null)
            {
                return NotFound();
            }

            return View(asignatura);
        }

        public IActionResult Agregar()
        {
            ViewBag.Profesores = new SelectList(_InstanciaProfesorRepo.MostrarTodos(), "Id", "Nombre");
            ViewBag.Cursos = new SelectList(_InstanciaCursoRepo.MostrarTodos(), "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                _InstanciaAsignaturaRepo.Agregar(asignatura);
                _InstanciaAsignaturaRepo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Profesores = new SelectList(_InstanciaProfesorRepo.MostrarTodos(), "Id", "Nombre", asignatura.ProfesorId);
            ViewBag.Cursos = new SelectList(_InstanciaCursoRepo.MostrarTodos(), "Id", "Nombre", asignatura.CursoId);
            return View(asignatura);
        }

        public IActionResult Editar(int Id)
        {
            var asignatura = _InstanciaAsignaturaRepo.ObtenerPorId(Id);
            if (asignatura == null)
            {
                return NotFound();
            }
            ViewBag.Profesores = new SelectList(_InstanciaProfesorRepo.MostrarTodos(), "Id", "Nombre", asignatura.ProfesorId);
            ViewBag.Cursos = new SelectList(_InstanciaCursoRepo.MostrarTodos(), "Id", "Nombre", asignatura.CursoId);
            return View(asignatura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                _InstanciaAsignaturaRepo.Actualizar(asignatura);
                _InstanciaAsignaturaRepo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Profesores = new SelectList(_InstanciaProfesorRepo.MostrarTodos(), "Id", "Nombre", asignatura.ProfesorId);
            ViewBag.Cursos = new SelectList(_InstanciaCursoRepo.MostrarTodos(), "Id", "Nombre", asignatura.CursoId);
            return View(asignatura);
        }

        public IActionResult Delete(int id)
        {
            var asignatura = _InstanciaAsignaturaRepo.ObtenerPorId(id);
            if (asignatura == null)
            {
                return NotFound();
            }
            return View(asignatura);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _InstanciaAsignaturaRepo.Eliminar(id);
            _InstanciaAsignaturaRepo.Guardar();
            return RedirectToAction(nameof(Index));
        }
    }
}
