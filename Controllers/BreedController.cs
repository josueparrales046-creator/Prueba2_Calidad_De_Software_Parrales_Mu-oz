using EjemploMVC.Models;
using EjemploMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace EjemploMVC.Controllers
{
    public class BreedController : Controller
    {
        private readonly DogBreedService _dogBreedService;
        private const int PageSize = 10; 

        public BreedController(DogBreedService dogBreedService)
        {
            _dogBreedService = dogBreedService;
        }


        public async Task<ActionResult> Index(int page = 1)
        {
            var resultado = await _dogBreedService.GetBreeds(page, PageSize);

            var viewModel = new DogBreedListViewModel
            {
                Razas = resultado.Data,
                PaginaActual = page,
                HasNext = !string.IsNullOrEmpty(resultado.Links?.Next)
            };

            return View(viewModel);
        }


        public async Task<ActionResult> Details(string id)
        {
            try
            {
                var raza = await _dogBreedService.GetBreed(id);
                return View(raza);
            }
            catch (HttpRequestException)
            {
                TempData["ErrorMessage"] = "No se encontró la raza solicitada.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
