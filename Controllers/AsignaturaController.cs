using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Escolar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;



namespace Escolar.Controllers
{
    //[Authorize]
    public class AsignaturaController : Controller
    {
        
        private readonly IrepositorioAsignatura _InstanciaAsignaturaRepo;
        private readonly IrepositorioCurso _InstanciaCursoRepo;

        public AsignaturaController(IrepositorioAsignatura variableAsignaturaRepo, IrepositorioCurso variableCursoRepo)
        {
            _InstanciaAsignaturaRepo = variableAsignaturaRepo;
            _InstanciaCursoRepo = variableCursoRepo;
        }
        
        public IActionResult Index() // devolver la vista index en productos
        {
            
            var asignaturas =  _InstanciaAsignaturaRepo.MostrarTodos();
            return View(asignaturas);
        }

        public IActionResult Detalles(int Id) // traer los detalles de un producto especifico
        {
            var asignatura = _InstanciaAsignaturaRepo.ObtenerPorId(Id);

            if (asignatura == null)
            {
                return NotFound();
            }
             //var categoria = _InstanciaCategoriaRepo.ObtenerPorId(producto.CategoriaId);
               // producto.Categoria = categoria;

            return View(asignatura);
        }

       // [Authorize(Roles ="Administrador")]

        public IActionResult Agregar() // Solicitar los datos de categoria
        {
            ViewData["Cursos"] = new SelectList(_InstanciaCursoRepo.MostrarTodos(), "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles ="Administrador")]
        public IActionResult Agregar(Asignatura asignatura) // Inserta un producto con categoria
        {
            if (ModelState.IsValid)
            {
                _InstanciaAsignaturaRepo.Agregar(asignatura);
                _InstanciaAsignaturaRepo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursosId"] = new SelectList(_InstanciaCursoRepo.MostrarTodos(), "Id", "Nombre", asignatura.CursoId);
            return View(asignatura);
        }
        //[Authorize(Roles ="Administrador")]

        public IActionResult Editar(int Id) // Obtienen los datos de un producto especifico
        {
            var asignatura = _InstanciaAsignaturaRepo.ObtenerPorId(Id);
            if (asignatura == null)
            {
                return NotFound();
            }
            ViewBag.Cursos = new SelectList(_InstanciaCursoRepo.MostrarTodos(), "Id", "Nombre");
            return View(asignatura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles ="Administrador")]
        public IActionResult Editar(Asignatura asignatura) // Actualiza un producto especifico
        {
            if (ModelState.IsValid)
            {
                _InstanciaAsignaturaRepo.Actualizar(asignatura);
                _InstanciaAsignaturaRepo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            return View(asignatura);
        }

       // [Authorize(Roles ="Administrador")]

        public IActionResult Delete(int id) // Devuelve los datos de un producto para eliminar 
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
       // [Authorize(Roles ="Administrador")]
        public IActionResult DeleteConfirmed(int id) // Elimina el producto seleccionado
        {
            _InstanciaAsignaturaRepo.Eliminar(id);
            _InstanciaCursoRepo.Guardar();
            return RedirectToAction(nameof(Index));
        }
    }
}

