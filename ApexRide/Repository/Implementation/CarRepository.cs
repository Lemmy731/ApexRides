using ApexRide.Data;
using ApexRide.Models;
using ApexRide.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApexRide.Repository.Implementation
{
    public class CarRepository: ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAllCars()
            => await _context.Cars.ToListAsync();   

        public async Task<Car> GetCar(string id)
            => await _context.Cars.FindAsync(id);

        public async Task AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }
    }
}
