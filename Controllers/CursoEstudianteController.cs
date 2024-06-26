using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Escolar.Models;
public class CursoEstudianteController : Controller
{
    private readonly IRepositorioCursoEstudiante _repositorioCursoEstudiante;
    private readonly IrepositorioCurso _repositorioCurso;
    private readonly IrepositorioEstudiante _repositorioEstudiante;

    public CursoEstudianteController(IRepositorioCursoEstudiante repositorioCursoEstudiante,
                                     IrepositorioCurso repositorioCurso,
                                     IrepositorioEstudiante repositorioEstudiante)
    {
        _repositorioCursoEstudiante = repositorioCursoEstudiante;
        _repositorioCurso = repositorioCurso;
        _repositorioEstudiante = repositorioEstudiante;
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
        ViewData["Cursos"] = _repositorioCurso.MostrarTodos();
        ViewData["Estudiantes"] = _repositorioEstudiante.MostrarTodos();
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
        ViewData["Cursos"] = _repositorioCurso.MostrarTodos();
        ViewData["Estudiantes"] = _repositorioEstudiante.MostrarTodos();
        return View(cursoEstudiante);
    }

    public IActionResult Editar(int idEstudiante, int idCurso)
    {
    var cursoEstudiante = _repositorioCursoEstudiante.ObtenerPorIDs(idEstudiante, idCurso);
    if (cursoEstudiante == null)
    {
        return NotFound();
    }
    ViewBag.Estudiantes = new SelectList(_repositorioEstudiante.MostrarTodos(), "Id", "Nombre", cursoEstudiante.EstudianteId);
    ViewBag.Cursos = new SelectList(_repositorioCurso.MostrarTodos(), "Id", "Nombre", cursoEstudiante.CursoId);
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
    ViewBag.Estudiantes = new SelectList(_repositorioEstudiante.MostrarTodos(), "Id", "Nombre", cursoEstudiante.EstudianteId);
    ViewBag.Cursos = new SelectList(_repositorioCurso.MostrarTodos(), "Id", "Nombre", cursoEstudiante.CursoId);
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
