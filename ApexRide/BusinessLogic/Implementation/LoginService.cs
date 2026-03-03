using ApexRide.BusinessLogic.Interface;
using ApexRide.Data;
using ApexRide.Models;
using ApexRide.Repository.Interface;

namespace ApexRide.BusinessLogic.Implementation
{
    public class LoginService: IloginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<bool> Login(Admin admin)
        {
            var user = await _loginRepository.Login(admin);
            if(user)
            {
                return true;
            }
            return false;
        }
    }
}
