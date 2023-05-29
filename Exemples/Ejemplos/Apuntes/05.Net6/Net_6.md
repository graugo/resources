# Net 6
## Kestrel VS IIS
Kestrel e IIS nos sirven para ejecutar las aplicaciones que hemos desarrollado, como servidor web.
Kestrel e IIS tienen cosas diferentes:
- Kestrel no nos permite hacer un loging de los accesos Http de nuestro servidor.
- No nos permite tener multiples aplicaciones en el mismo puerto por diseño.
- La Autenticacion via windows no existe, ya que es cross platform.
- IIS tiene una integracion directa con FTP, mientras Kestrel no.
- Si queremos tener un filtrado de tipos de archivo para bloquear su acceso a nuestra aplicacion hemos de configurarlo codificandolo.
- El mapeo de los tipo MIME es mucho mejor en IIS.

Cuando hablamos de los tipos MIME nos referimos a las imagenes, paginas html, etc

Pensad que Kestrel se continua actualizando poco a poco lo que hace que este tipo de diferencias se reduzca con el tiempo.

Una de las cosas buenas que aporta Kestrel que IIS no permite es el poder desplegar nuestras aplicaciones en sistemas operativos no nativos.
Cuando hablamos de sistemas no nativos nos referimos a Linux y Mac.
El uso de Kestrel en linux es muy sencillo, tan solo hemos de iniciar la aplicación.

## CLI
https://learn.microsoft.com/es-es/dotnet/core/tools/

Comandos que más utilizaremos
- new, https://learn.microsoft.com/es-es/dotnet/core/tools/dotnet-new, nos sirve para crear una aplicacion utilizando una plantilla
- restore, https://learn.microsoft.com/es-es/dotnet/core/tools/dotnet-restore, nos permite restaurar las dependencias y herramientas de nuestro proyecto
- build, https://learn.microsoft.com/es-es/dotnet/core/tools/dotnet-build, compila el proyecto
- run, https://learn.microsoft.com/es-es/dotnet/core/tools/dotnet-run, ejecuta el proyecto seleccionado
- test, https://learn.microsoft.com/es-es/dotnet/core/tools/dotnet-test, ejecuta las pruebas unitarias de nuestro proyecto

### Crear una solución con proyectos en CLI
1. Crearemos una carpeta donde se situara la solución. Utilizando el comando **dotnet new sln -n <name>** crearemos el sln de nuestra solución.
2. En la misma ubicación crearemos nuestro proyecto de WebApi con el comando **dotnet new webapi -lang C# -n <name>**
3. Ahora tenemos que añadir a nuestra solución el proyecto creado con el comando **dotnet sln add <project_path>**
4. Con estos pasos tendremos creada nuestra solución con un proyecto de WebApi dentro.

## Net Standard
https://learn.microsoft.com/es-es/dotnet/standard/net-standard?tabs=net-standard-1-0

## Net 6 vs Framework
https://learn.microsoft.com/en-us/dotnet/standard/choosing-core-framework-server

https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10

## Crear aplicacion con Net6
### Configuration
- https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0
### Logging
- Native
    - https://learn.microsoft.com/en-us/dotnet/core/extensions/logging?tabs=command-line
- Serilog
    - https://github.com/serilog/serilog/wiki/Getting-Started
### IOC
- Native
    - https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection
### HttpClient
- Basic usage, https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory#basic-usage
- Typed usage, https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory#typed-clients
### Cache
#### MemoryCache
- Utilizar la interfaz IMemoryCache para invocar el servicio que nos permitira controlar la cache
- Añadimos al constructor la inyeccion
- Crearemos métodos para hacer el Get y el Set, se puede crear un método que realice las 2 acciones.
- Para dar nombre a la Key se tiene que hacer con un object, la mejor opción es tratar con una enum
- Se ha de añadir a la clase program AddMemoryCache para hacer la inyeccion en nuestro servicio
- https://learn.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-7.0
#### Redis
- Hay que instalar el Nuget Microsoft.Extensions.Caching.Distributed
- Añadir a los settings el server de redis donde se añadira la informacion
- Añadir en program AddStackExchangeRedisCache con la configuracion necesaria
- Crear el servicio utilizando IDistributedCache para llamar a Redis
### EF Core
- Instalar Nugets de EntityFrameWorkCore
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
- Generar una clase que herede de DbContext y añadir los modelos que hagan de tablas
- Sobrescribir el método OnConfiguring, para añadir la connectionString
- Ejecutar el comando Add-Migration InitialCreate
- Ejecutar el comando Update-Database
- La base de datos se creara en este proceso y se ejecutaran las migrations necesarias
- Para DI -> Añadir en la clase program un DbContext con el tipo de nuestra herencia de DbContext
- Utilizar el UseSqlServer para añadir la connectionString
- https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
- https://learn.microsoft.com/en-us/ef/core/
