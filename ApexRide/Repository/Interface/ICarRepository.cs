using ApexRide.Models;

namespace ApexRide.Repository.Interface
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCars();
        Task<Car> GetCar(string id);
        Task AddCar(Car car);
    }
}
