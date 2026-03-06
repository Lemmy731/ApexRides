using ApexRide.BusinessLogic.Interface;
using ApexRide.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApexRide.Controllers
{
    public class InquiryController : Controller
    {
        private readonly IInquiryService _inquiryService;
        public InquiryController(IInquiryService inquiryService)
        {
            _inquiryService = inquiryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create(string Id)
        {
            return View(new Inquiry { CarId = Id });
        }
        [HttpGet]
        public IActionResult Creates(string Id)
        {
            var inquiry = new Inquiry
            {
                CarId = Id
            };

            return View(inquiry);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Inquiry inquiry)
        {
            await _inquiryService.CreateInquiry(inquiry);
            TempData["inquiry"] = "Inquiry Submitted";
            TempData["RedirectUrl"] = Url.Action("Index", "Home");
            return View();
            //return RedirectToAction("Index", "Home");
        }
        [HttpGet("all-inquiry")]
        public async Task<IActionResult> AllInquiry()
        {
            var response = await _inquiryService.GetInquiry();
            if (response == null) 
            {
                return View();   
            }
            return View(response);
        }
    }
}
