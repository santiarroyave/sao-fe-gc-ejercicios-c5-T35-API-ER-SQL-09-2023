# C5-T35 API ER SQL

## Paquetes necesarios
- [Pomelo.EntityFrameworkCore.MySql](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql)

## Capturas
### Ejercicio 1
![imagen](https://github.com/santiarroyave/sao-fe-gc-ejercicios-c5-T35-API-ER-SQL-09-2023/assets/135848692/d72ae057-193a-4ae7-9994-78068c4a0e12)

### Ejercicio 2
![imagen](https://github.com/santiarroyave/sao-fe-gc-ejercicios-c5-T35-API-ER-SQL-09-2023/assets/135848692/bae39a59-2ae3-4295-8b41-620c91c06114)

### Ejercicio 3
![imagen](https://github.com/santiarroyave/sao-fe-gc-ejercicios-c5-T35-API-ER-SQL-09-2023/assets/135848692/69e1ea43-99b1-4f0d-8921-a563f1b2f516)

### Ejercicio 4
![imagen](https://github.com/santiarroyave/sao-fe-gc-ejercicios-c5-T35-API-ER-SQL-09-2023/assets/135848692/f3317cd6-d63d-4659-90ac-d6e50edcea46)


## Pasos
1. Agregar la cadena de conexión a la DB

Archivo: **appsettings.json**

> [!WARNING]
> Hay datos sensibles que deberian guardarse en variables de entorno o en gestores de secretos.

```json
{
  "ConnectionStrings": {
    "MyDbSQL": "Server=localhost;Port=3306;Database=MyDatabase;User=MyUser;Password=MyPassword;"
  },
  // Otras configuraciones...
}
```

2. Realizar la conexión a la DB

Archivo: **Program.cs**

```csharp
// Configura la cadena de conexión a partir de appsettings.json
var connectionString = builder.Configuration.GetConnectionString("MyDbSQL");
// Especificar la verisión
var serverVersion = new MySqlServerVersion(new Version());
// Agrega el contexto de la base de datos con la cadena de conexión de MySQL
builder.Services.AddDbContext<MyDbContext>(options => options.UseMySql(connectionString, serverVersion));
```

### Métodos para especificar la versión de la DB
La versión que especifiques es la versión que *Entity Framework Core* utilizará como guía para comunicarse con la base de datos MySQL. Sin embargo, *Entity Framework Core* se adaptará automáticamente a la versión del servidor MySQL al que te estás conectando para asegurarse de que la comunicación sea efectiva y compatible.

Poner la versión al configurar *Entity Framework Core* sirve como una guía inicial que le dice a *Entity Framework Core* cómo generar consultas SQL y realizar operaciones de base de datos basadas en las características y capacidades de esa versión específica de MySQL. Esta especificación de versión es útil cuando deseas asegurarte de que *Entity Framework Core* aproveche las características específicas de una versión particular de MySQL.

Sin embargo, *Entity Framework Core* es lo suficientemente inteligente como para adaptarse automáticamente a la versión del servidor MySQL al que te estás conectando. Esto significa que, aunque especificaste una versión en tu configuración, la biblioteca se ajustará para funcionar correctamente con la versión real del servidor MySQL.

#### Obtener versión
Para obtener la versión se puede usar esta consulta en la DB
```sql
SELECT VERSION();
```

#### Método 1 para especificar la versión en la API
```csharp
// Manera 1: Sin especificar versión
var serverVersion = new MySqlServerVersion(new Version());
// Manera 2: Especificando versión
var serverVersion = new MySqlServerVersion(new Version(8, 1, 0));
```

Si no especificas la versión exacta, *Entity Framework Core* utilizará la versión predeterminada de MySQL que es compatible con la versión de *Pomelo.EntityFrameworkCore*.MySql que estás utilizando. Esto puede ser conveniente si no tienes requisitos de compatibilidad específicos o si estás dispuesto a confiar en la versión predeterminada que proporciona la biblioteca.

En general, si no tienes razones específicas para requerir una versión exacta, puedes omitir la especificación de la versión y confiar en la versión predeterminada proporcionada por la biblioteca *Pomelo.EntityFrameworkCore.MySql*. Esto facilitará las actualizaciones futuras, ya que tu aplicación se adaptará automáticamente a nuevas versiones compatibles de MySQL a medida que la biblioteca se actualice.

#### Método 2 para especificar la versión en la API
```csharp
// Manera 1
var serverVersion = ServerVersion.Parse("8.1");
// Manera 2
var serverVersion = ServerVersion.Parse("8.1-mysql");
```

En las cadenas de versión de MySQL, el sufijo "-mysql" a menudo se usa para indicar que se trata de una versión de MySQL específica de una distribución o paquete en particular. No es parte de la versión principal y secundaria de MySQL, sino que se agrega para distinguir versiones específicas utilizadas en paquetes personalizados o distribuciones de MySQL.

En términos de *Entity Framework Core* y la configuración de la cadena de conexión, no es necesario incluir el sufijo "-mysql" en la cadena de versión. *Entity Framework Core* interpreta la versión principal y secundaria de MySQL y no requiere el sufijo para funcionar correctamente.