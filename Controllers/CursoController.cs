using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Escolar.Models;

namespace MyMvcApp.Controllers
{
    public class CursoController : Controller
    {
        private readonly IrepositorioCurso _InstanciaCursoRepo;

        public CursoController(IrepositorioCurso cursoRepositorio)
        {
            _InstanciaCursoRepo = cursoRepositorio;
        }

        public IActionResult Index()
        {
            var curso = _InstanciaCursoRepo.MostrarTodos();
            return View(curso);
        }

        public IActionResult Detalles(int id)
        {
            var curso = _InstanciaCursoRepo.ObtenerPorId(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(Curso curso)
        {
            if (ModelState.IsValid)
            {
                _InstanciaCursoRepo.Agregar(curso);
                _InstanciaCursoRepo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        public IActionResult Editar(int id)
        {
            var curso = _InstanciaCursoRepo.ObtenerPorId(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Curso curso)
        {
            if (ModelState.IsValid)
            {
                _InstanciaCursoRepo.Actualizar(curso);
                _InstanciaCursoRepo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        public IActionResult Delete(int id)
        {
            var curso = _InstanciaCursoRepo.ObtenerPorId(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _InstanciaCursoRepo.Eliminar(id);
            _InstanciaCursoRepo.Guardar();
            return RedirectToAction(nameof(Index));
        }
    }
}
