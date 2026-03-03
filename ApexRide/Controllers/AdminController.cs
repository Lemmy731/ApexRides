using ApexRide.BusinessLogic.Interface;
using ApexRide.DTO;
using ApexRide.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApexRide.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly IloginService _loginService;

        public AdminController(IloginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AdminDto adminDto)
        {
            Admin admin = new Admin
            {
                Password = adminDto.Password,
                Username = adminDto.Username
            };
            var response = await _loginService.Login(admin);    
            if (response)
            {
                HttpContext.Session.SetString("Admin", adminDto.Username);
                return RedirectToAction("Dashboard");
            }
            else
            {
                //TempData["Error"] = "Login as an admin please";
                //return RedirectToAction("Dashboard");

                TempData["Error"] = "Log in as an admin please";
                TempData["RedirectUrl"] = Url.Action("Login", "Login");
                //return View();
            }
            return View();
        }
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}