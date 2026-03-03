using ApexRide.Models;

namespace ApexRide.Repository.Interface
{
    public interface ILoginRepository
    {
        Task<bool> Login(Admin admin);
    }
}
