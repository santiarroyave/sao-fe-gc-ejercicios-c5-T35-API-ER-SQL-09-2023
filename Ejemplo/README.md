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
> En versiones 6 y 7 este archivo ya no está presente, por lo que para proyectos simples se puede simplificar configurarandolo en Program.cs

Más información en **MANERA_ACTUAL.md**
```csharp
// Configuramos la conexión con la base de datos SQL
var connection = builder.Configuration.GetConnectionString("NetflixDatabase");
builder.Services.AddDbContextPool<netflixContext>(options => options.UseSqlServer(connection));
```
5. Agregar clase Cliente
6. Agregar clase Vodeos
7. Agregar netflixContext

