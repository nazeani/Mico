using Business.Services.Abstracts;
using Business.Services.Concrates;
using Core.RepositoryAbstracts;
using Data.DAL;
using Data.RepositoryConcrates;
using Microsoft.EntityFrameworkCore;

namespace MicroMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer("Server=CA-R214-PC09\\SQLEXPRESS;Database=MicroNaz;Trusted_Connection=true;Integrated Security=true;TrustServerCertificate=true;"));
            builder.Services.AddScoped<ISliderService, SliderService>();
            builder.Services.AddScoped<ISliderRepository, SliderRepository>();
            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}