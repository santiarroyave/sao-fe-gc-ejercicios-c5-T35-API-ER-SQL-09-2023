# Versiones antiguas
En este ejemplo se muestra el código tal cual se ve en la unidad formativa.

Se usan versiónes anteriores donde hacia falta la clase **Startup.cs**. *(Actualmente ya no hace falta)*

```csharp
using Microsoft.EntityFrameworkCore;

namespace Ejemplo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuramos la conexión con la base de datos SQL
            var connection = Configuration.GetConnectionString("NetflixDatabase");
            services.AddDbContextPool<netflixContext>(options => options.UseSqlServer(connection));
            services.AddControllers();

            // Register the swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
        }
    }
}
```