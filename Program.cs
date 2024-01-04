using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using myClientListApp.Data;
using myClientListApp.Repositories;
using myClientListApp.Services;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices((hostContext, services) =>
                {
                    // DbContext configuration
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection"));
                    });

                    // Add other services
                    services.AddScoped<IClientRepository, ClientRepository>();
                    services.AddScoped<IClientService, ClientService>();

                    services.AddControllers();
                    services.AddEndpointsApiExplorer();
                    services.AddSwaggerGen();

                    // CORS Configuration

                    services.AddCors(options =>
                    {
                        options.AddPolicy("AllowClientListApp",
                            builder =>
                            {
                                builder.WithOrigins("http://localhost:4200")
                                       .AllowAnyHeader()
                                       .AllowAnyMethod();
                            });
                    });
                });

                webBuilder.Configure((hostContext, app) =>
                {
                    // Configure the HTTP request pipeline.
                    if (hostContext.HostingEnvironment.IsDevelopment())
                    {
                        app.UseSwagger();
                        app.UseSwaggerUI();
                    }

                    app.UseHttpsRedirection();
                    app.UseAuthorization();

                    app.UseRouting(); // Explicitly add UseRouting()

                    app.UseCors("AllowClientListApp");

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                });
            });
}
