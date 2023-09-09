using ex03.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ex03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Configura la cadena de conexi�n a partir de appsettings.json y la versi�n de MySQL
            var connectionString = builder.Configuration.GetConnectionString("MyDbSQL");
            var serverVersion = new MySqlServerVersion(new Version());
            // Agrega el contexto de la base de datos con la cadena de conexi�n de MySQL
            builder.Services.AddDbContext<MyDbContext>(options => options.UseMySql(connectionString, serverVersion));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapGet("/dbconexion", async ([FromServices] MyDbContext dbContext) =>
            {
                dbContext.Database.EnsureCreated();
                return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
            });

            app.Run();
        }
    }
}