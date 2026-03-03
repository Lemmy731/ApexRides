using ApexRide.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ApexRide.Data
{
    public static class SeedAdmin
    {
        //admin login details
        private  const string username = "john@yopmail.com";
        private const string password = "Jo@hn12345";

        public static async Task SeedData(this IApplicationBuilder app)
        {
            var passwordHash = new PasswordHasher<object>();

            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
            if (!context.Admins.Any())
            {
                Admin admin = new Admin
                {
                    ID = Guid.NewGuid().ToString(),
                    Username = username,
                    Password = passwordHash.HashPassword(null, password)
                };
                await context.Admins.AddAsync(admin);
                await context.SaveChangesAsync();
            }
        }
    }
}
