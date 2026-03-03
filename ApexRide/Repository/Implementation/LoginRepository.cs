using ApexRide.Data;
using ApexRide.Models;
using ApexRide.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApexRide.Repository.Implementation
{
    public class LoginRepository: ILoginRepository
    {
        private readonly AppDbContext _appDbContext;
        public LoginRepository(AppDbContext appDbContext)
        {
             _appDbContext = appDbContext;
        }
 
        public async Task<bool> Login(Admin admin)
        {
            var user = await _appDbContext.Admins
                .FirstOrDefaultAsync(a =>
                    a.Username == admin.Username);
            var passwordHasher = new PasswordHasher<object>();
            if (user == null) 
            {
                return false;
            }
            var result = passwordHasher.VerifyHashedPassword(null, user.Password, admin.Password);

            if (user.Username == admin.Username & result == PasswordVerificationResult.Success)
            {
                return true;
            }
            return false;   
        }
    }
}
