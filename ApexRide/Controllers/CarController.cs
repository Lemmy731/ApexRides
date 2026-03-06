using ApexRide.BusinessLogic.Interface;
using ApexRide.Data;
using ApexRide.Models;
using ApexRide.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ApexRide.Controllers
{
    public class CarController : Controller
    {

        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }


        //[HttpGet("{id}")]
        public async Task<IActionResult> Details(string Id)
        {
            var car = await _carService.GetCar(Id);
            return View(car);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarDto carDto)
        {
            var admin = HttpContext.Session.GetString("Admin");

            if (admin == null)
            {
                TempData["Error"] = "Log in as an admin please";
                TempData["RedirectUrl"] = Url.Action("Login", "Login");
                return View();
            }
            await _carService.AddCar(carDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllCars();
            return View(cars);
        }
    }
}
