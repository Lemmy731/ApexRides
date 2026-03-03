using ApexRide.DTO;
using ApexRide.Models;

namespace ApexRide.BusinessLogic.Interface
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCars();
        Task<Car> GetCar(string id);
        Task AddCar(CarDto carDto);
    }
}
