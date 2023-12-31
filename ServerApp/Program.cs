using ServerApp.Managers;
using SharedLibrary.Models.Strategies;

namespace ServerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Network services
            builder.Services.AddSignalR();
            builder.Services.AddSingleton<GameHub>();
            builder.Services.AddSingleton<GameManager>();

            // Game services
            builder.Services.AddSingleton<ServerManager>();
            builder.Services.AddSingleton<ShootStrategy>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<GameHub>("/gameHub"); // Customize the hub URL
                endpoints.MapControllers();
            });
            app.MapControllers();

            app.Run();
        }
    }
}