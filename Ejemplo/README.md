# Proyecto de ejemplo de la unidad formativa
## Pasos que he seguido
1. Crear proyecto **ASP.NET Core Web API**
2. Instalar los paquetes NuGet
    - [Microsoft.VisualStudio.Web.CodeGeneration.Design](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/6.0.16)
    - [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/7.0.10)
    - [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/7.0.10)
3. Configuración del proyecto `Properties > launchSettings.json`
4. Conexión con DB `appsettings.json`
```json
"AllowedHosts": "*",
"ConnectionStrings": {
  "NetflixDatabase": "Server=192.168.1.135;Database=netflix;User ID=remote;Password=remote"
}
```
5. Configurar el archivo Startup
> En versiones 6 y 7 este archivo ya no está presente, por lo que se deberá configurar en Program.cs




## Startup
### ¿Para qué se utiliza?
El archivo **Startup.cs** en proyectos API de C# (como proyectos ASP.NET Core) es un componente fundamental que configura y establece la aplicación web en su inicio. Se encarga de varias tareas clave relacionadas con la configuración, la inyección de dependencias y la gestión del flujo de solicitud y respuesta en la aplicación.

En resumen, define cómo se comporta la aplicación, qué servicios se utiliza y cómo se procesan las solicitudes HTTP entrantes. Es una parte crucial para establecer el comportamiento de la aplicación y controlar su flujo de trabajo.

### Ahora se usa Program.cs
En *ASP.NET Core 6 (Versión utilizada)* se ha introducido una simplificación en la configuración de la aplicación que puede no requerir un archivo Startup.cs separado para proyectos más simples, como una API básica.

En esta versión, la configuración de la aplicación se realiza directamente en el archivo Program.cs utilizando el método **ConfigureServices** y el método **Configure** directamente en la clase Program.

Dentro del método *Main* de tu archivo *Program.cs*, puedes ver que se realiza la configuración de servicios y middleware, similar a lo que normalmente se haría en los métodos *ConfigureServices* y *Configure* de la clase Startup. Esto es parte de la simplificación introducida en ASP.NET Core 6 para proyectos más pequeños y simples.

Si tu proyecto se mantiene relativamente simple y no necesita una configuración compleja, puedes trabajar directamente en *Program.cs*.

### ¿Entonces es buena práctica usar Starup?
El uso de la clase *Startup* en ASP.NET Core sigue siendo una buena práctica, independientemente de la complejidad de tu aplicación.

La separación de la configuración en una clase dedicada, como Startup, es una **convención** que promueve la modularidad, la organización y el mantenimiento del código, y es una parte fundamental del modelo de programación de ASP.NET Core.

Aunque es cierto que en ASP.NET Core 6 se introdujo una simplificación que permite configurar servicios y middleware directamente en Program.cs para proyectos más pequeños y simples, la mayoría de las aplicaciones, especialmente aquellas de mayor envergadura o con requerimientos más complejos, todavía se benefician de la estructura tradicional que utiliza la clase Startup.

Aquí hay algunas razones por las cuales seguir utilizando la clase Startup es una buena práctica:
- **Organización y claridad**: Proporciona un lugar centralizado y claro para configurar servicios, middleware y rutas.
- **Modularidad*: Permite dividir la aplicación en módulos más pequeños y fácilmente mantenibles. 
- **Escalabilidad**: Si tu aplicación crece en complejidad o escala, es más probable que necesites una configuración más avanzada.
- **Prácticas recomendadas de la comunidad**: Esto significa que es más probable que otros desarrolladores comprendan y colaboren en tu código si sigues esta convención.


### Configurar el host para usar la clase *Startup* en *Program.cs*
En el método *Main* del archivo *Program.cs*, configura el host para utilizar la clase *Startup* que has creado. Esto se hace utilizando el método **UseStartup<TStartup>()** en el *WebHostBuilder*.

Puedes agregar la línea `app.UseStartup<Startup>()` después de builder.Build() para especificar que la clase Startup se utilizará para la configuración de la aplicación:
```csharp
var app = builder.Build();
app.UseStartup<Startup>();
```
Con esto, el host utilizará la clase Startup que has creado para configurar la aplicación.

Asegúrate de que los métodos *ConfigureServices* y *Configure* en *Startup.cs* estén configurados según las necesidades de tu aplicación. Allí es donde definirás tus servicios, middleware, enrutamiento, autenticación, autorización y cualquier otra configuración específica de tu aplicación.

> Dudas: ¿La configuración de Swagger que aparece en Program.cs hay que moverla a Starup.cs?

### Algunas configuraciones utilizadas
1. Configuración de servicios
```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Configuración de servicios como la autenticación, la base de datos, etc.
}
```
2. Configuración de middleware
```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    // Configuración de middleware como enrutamiento, autenticación, etc.
}
```
3. Configuración de enrutamiento
5. Configuración de autenticación y autorización
6. Configuración de inyección de dependencias