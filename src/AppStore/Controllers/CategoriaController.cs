using AppStore.Models.Domain;
using AppStore.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AppStore.Models.DTO;

namespace AppStore.Controllers;

[Authorize]
public class CategoriaController : Controller
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpPost]
    public IActionResult Add(Categoria categoria)
    {
        if (!ModelState.IsValid)
        {
            return View(categoria);
        }

        var resultadoCategoria = _categoriaService.Add(categoria);
        if (resultadoCategoria)
        {
            TempData["msg"] = "Se agregó la categoría exitosamente.";
            return RedirectToAction(nameof(Add));
        }

        TempData["msg"] = "Errores guardando la categoría.";
        return View(categoria);
    }

    public IActionResult Add()
    {
        var categoria = new Categoria();
        return View(categoria);
    }

    public IActionResult Edit(int id)
    {
        var categoria = _categoriaService.GetById(id);
        if (categoria == null) {
            return NotFound();
        }
        return View(categoria);
    }

    [HttpPost]
    public IActionResult Edit(Categoria categoria)
    {
        if (!ModelState.IsValid)
        {
            return View(categoria);
        }

        var resultadoCategoria = _categoriaService.Update(categoria);
        if (!resultadoCategoria)
        {
            TempData["msg"] = "Errores, no se pudo actualizar la categoría.";
            return View(categoria);
        }

        TempData["msg"] = "Se actualizó exitosamente la categoría.";
        return View(categoria);
    }

    public IActionResult CategoriaList()
    {
        var categorias = _categoriaService.List();
        var categoriaListVm = new CategoriaListVm
        {
            CategoriaList = categorias
        };
        return View(categoriaListVm);
    }

    public IActionResult Delete(int id)
    {
        _categoriaService.Delete(id);
        return RedirectToAction(nameof(CategoriaList));
    }
}
