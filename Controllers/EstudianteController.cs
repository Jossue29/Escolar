using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Escolar.Models;
using Microsoft.AspNetCore.Authorization;

namespace MyMvcApp.Controllers
{
    [Authorize]
    public class EstudianteController : Controller
    {
        private readonly IrepositorioEstudiante _InstanciaEstudianteRepo;

        public EstudianteController(IrepositorioEstudiante estudianteRepositorio)
        {
            _InstanciaEstudianteRepo = estudianteRepositorio;
        }

        public IActionResult Index()
        {
            var estudiantes = _InstanciaEstudianteRepo.MostrarTodos();
            return View(estudiantes);
        }

        public IActionResult Detalles(int id)
        {
            var estudiante = _InstanciaEstudianteRepo.ObtenerPorId(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _InstanciaEstudianteRepo.Agregar(estudiante);
                _InstanciaEstudianteRepo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        public IActionResult Editar(int id)
        {
            var estudiante = _InstanciaEstudianteRepo.ObtenerPorId(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _InstanciaEstudianteRepo.Actualizar(estudiante);
                _InstanciaEstudianteRepo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        public IActionResult Delete(int id)
        {
            var estudiante = _InstanciaEstudianteRepo.ObtenerPorId(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _InstanciaEstudianteRepo.Eliminar(id);
            _InstanciaEstudianteRepo.Guardar();
            return RedirectToAction(nameof(Index));
        }
    }
}
