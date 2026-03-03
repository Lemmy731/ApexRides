using ApexRide.BusinessLogic.Interface;
using ApexRide.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApexRide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly AppDbContext _appDbContext;
        public CarsController(ICarService carService, AppDbContext appDbContext)
        {
            _carService = carService;
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
           var car  = await _appDbContext.Cars.ToListAsync();
            return Ok(car);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var car = await _appDbContext.Cars.FindAsync(id);
            return Ok();
        }
    }
    
}
