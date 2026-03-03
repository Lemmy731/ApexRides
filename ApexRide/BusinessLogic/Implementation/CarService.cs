using ApexRide.BusinessLogic.Interface;
using ApexRide.DTO;
using ApexRide.Models;
using ApexRide.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApexRide.BusinessLogic.Implementation
{
    public class CarService: ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<List<Car>> GetAllCars()
            => await _carRepository.GetAllCars();   

        public async Task<Car> GetCar(string id)
            => await _carRepository.GetCar(id); 

        public async Task AddCar(CarDto carDto)
        {
            Car car = new Car
            {
                Id = Guid.NewGuid().ToString(),
                Name = carDto.Name,
                Brand = carDto.Brand,   
                Price = carDto.Price,   
                Year = carDto.Year, 
                Description = carDto.Description,   
                ImageUrl = carDto.ImageUrl
            };
            await _carRepository.AddCar(car);     
        }
    }
}
