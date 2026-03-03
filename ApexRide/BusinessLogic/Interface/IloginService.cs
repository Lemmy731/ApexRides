using ApexRide.Models;

namespace ApexRide.BusinessLogic.Interface
{
    public interface IloginService
    {
        Task<bool> Login(Admin admin);
    }
}
