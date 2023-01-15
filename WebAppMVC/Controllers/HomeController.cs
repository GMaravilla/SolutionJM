using BLL.Service;
using Data.DataContext;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBaleroService _baleroService;

        public HomeController(IBaleroService baleroService)
        {
            _baleroService= baleroService;
        }

        public async Task<IActionResult> Index()
        {
            var Baleros = await _baleroService.ObtenerTodos();
            return View(Baleros);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([Bind("IdBaleros,Marca,Codigo,Precio,Fecha_Create")]Balero balero)
        {
            if(ModelState.IsValid)
            {
                bool respuesta = await _baleroService.Insertar(balero);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Hubo un error al insertar el balero en la base de datos";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar([Bind("IdBaleros,Marca,Codigo,Precio,Fecha_Create")] Balero balero)
        {
            if(ModelState.IsValid)
            {
                bool respuesta = await _baleroService.Actualizar(balero);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessae = "Hubo un error al actualizar el balero en la base de datos";
                return View();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool respuesta = await _baleroService.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new {valor = respuesta});
        }

        [HttpPost]
        public async Task<IActionResult> Obtener(int id)
        {
            Balero respuesta = await _baleroService.Obtener(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}