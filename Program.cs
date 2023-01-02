using Microsoft.EntityFrameworkCore;
using WebApplication11.Data;
using WebApplication11.Services.Interfaces;
using WebApplication11.Services;
namespace WebApplication11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MoovieDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("MoovieConnectionString")));
            builder.Services.AddScoped<IActorService, ActorService>();
            builder.Services.AddScoped<IMoovieInfoService, MoovieInfoService>();
            builder.Services.AddScoped<IMoovieService, MoovieService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}