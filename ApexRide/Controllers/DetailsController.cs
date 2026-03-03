using Microsoft.AspNetCore.Mvc;

namespace ApexRide.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
