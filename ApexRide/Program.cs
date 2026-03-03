using ApexRide.BusinessLogic.Implementation;
using ApexRide.BusinessLogic.Interface;
using ApexRide.Data;
using ApexRide.Repository.Implementation;
using ApexRide.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSession();
builder.Services.AddScoped<ICarService, CarService>(); 
builder.Services.AddScoped<ICarRepository, CarRepository>();       
builder.Services.AddScoped<IInquiryRepository, InquiryRepository>();   
builder.Services.AddScoped<IInquiryService, InquiryService>();     
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IloginService, LoginService>();

var app = builder.Build();
await app.SeedData(); 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
