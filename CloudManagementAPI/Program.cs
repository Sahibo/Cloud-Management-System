using CloudManagementAPI.Data;
using CloudManagementAPI.Repositories;
using CloudManagementAPI.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Microsoft.EntityFrameworkCore;

namespace CloudManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create and run the web host
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        
                        //services.AddDbContext<ApplicationDbContext>(options =>
                        //    options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));

                        services.AddScoped<CloudResourceRepository>();
                        services.AddScoped<CloudResourceService>();

                        services.AddControllers();
                    });

                    webBuilder.Configure(app =>
                    {
                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers(); 
                        });
                    });
                });
    }
}