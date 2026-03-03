using ApexRide.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApexRide.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;

        public HomeController(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllCars();
            return View(cars);
        }
    }
}
