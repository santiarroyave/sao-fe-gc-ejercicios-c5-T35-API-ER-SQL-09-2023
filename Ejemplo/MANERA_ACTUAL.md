# Versiones actuales
En este ejemplo se muestra el codigo configurado para las versiones actuales.

En este caso se prescinde de la clase **Startup.cs**

En versiones antiguas la conexion a base de datos es esta:
```csharp
// Configuramos la conexión con la base de datos SQL
var connection = Configuration.GetConnectionString("NetflixDatabase");
services.AddDbContextPool<netflixContext>(options => options.UseSqlServer(connection));
services.AddControllers();
```

En versiones actuales la conexion a base de datos es esta:
```csharp
// Configuramos la conexión con la base de datos SQL
var connection = builder.Configuration.GetConnectionString("NetflixDatabase");
builder.Services.AddDbContextPool<netflixContext>(options => options.UseSqlServer(connection));
```

Aqui se muestra como se veria el Main
```csharp
using Ejemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Configuramos la conexión con la base de datos SQL
            var connection = builder.Configuration.GetConnectionString("NetflixDatabase");
            builder.Services.AddDbContextPool<netflixContext>(options => options.UseSqlServer(connection));


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

            app.Run();
        }
    }
}
```