using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Escolar.Models;
using Microsoft.AspNetCore.Authorization;

namespace MyMvcApp.Controllers
{
    [Authorize]
    public class ProfesorController : Controller
    {
        private readonly IrepositorioProfesor _InstanciaProfesorRepo;

        public ProfesorController(IrepositorioProfesor profesorRepositorio)
        {
            _InstanciaProfesorRepo = profesorRepositorio;
        }

        public IActionResult Index()
        {
            var profesores = _InstanciaProfesorRepo.MostrarTodos();
            return View(profesores);
        }

        public IActionResult Detalles(int id)
        {
            var profesor = _InstanciaProfesorRepo.ObtenerPorId(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                _InstanciaProfesorRepo.Agregar(profesor);
                _InstanciaProfesorRepo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }

        public IActionResult Editar(int id)
        {
            var profesor = _InstanciaProfesorRepo.ObtenerPorId(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                _InstanciaProfesorRepo.Actualizar(profesor);
                _InstanciaProfesorRepo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }

        public IActionResult Delete(int id)
        {
            var profesor = _InstanciaProfesorRepo.ObtenerPorId(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _InstanciaProfesorRepo.Eliminar(id);
            _InstanciaProfesorRepo.Guardar();
            return RedirectToAction(nameof(Index));
        }
    }
}
