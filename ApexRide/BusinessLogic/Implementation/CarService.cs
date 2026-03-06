using ApexRide.BusinessLogic.Interface;
using ApexRide.Models;
using ApexRide.Models.DTO;
using ApexRide.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApexRide.BusinessLogic.Implementation
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CarService(ICarRepository carRepository, IWebHostEnvironment webHostEnvironment)
        {
            _carRepository = carRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<List<Car>> GetAllCars()
            => await _carRepository.GetAllCars();

        public async Task<Car> GetCar(string id)
            => await _carRepository.GetCar(id);

        public async Task AddCar(CarDto carDto)
        {
            if (carDto.ImageUrl != null)
            {
                string folder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string fileName = Guid.NewGuid().ToString() + "_" + carDto.ImageUrl.FileName;
                string filePath = Path.Combine(folder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await carDto.ImageUrl.CopyToAsync(stream);
                }
                Car car = new Car
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = carDto.Name,
                    Brand = carDto.Brand,
                    Price = carDto.Price,
                    Year = carDto.Year,
                    Description = carDto.Description,
                    ImageUrl = "/images/" + fileName
                };
                await _carRepository.AddCar(car);
            }
        }
    }
}
