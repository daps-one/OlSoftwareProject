# OlSoftwareProject

Para la correcta ejecución del proyecto se deben realizar los siguientes pasos:

1. Instalar la base de datos que se encuentra dividida en tres scripts en la ruta "src/Data" y son los siguientes archivos:
  - 1_create.sql: permite crear el esquema de la base de datos, es decir, sus tablas, llaves primarias y foráneas.
  - 2_sp.sql: el script permite crear el procedimiento almacenado requerido.
  - 3_populate.sql: contiene los datos semilla de la base de datos.

2. validar la cadena de conexión a la base de datos, dicha conexión se encuentra en la ruta "src/Infraestructure/Configuration/Middlewares" en el archivo "SqlServerServiceCollectionExtensions.cs".

3. por último se ejecuta el proyecto. Se puede ejecutar cada servicio por aparte en la ruta "src/Services" o se puede ejecutar el archivo "run.cmd" el cual va a ejecutar cada uno de los servicios de la aplicación.

> NOTA: Debido al tiempo limitado solo se pudo hacer los servicios y dichos servicios se pueden consumir directamente con swagger, ej: "https://localhost:5001/swagger/index.html".
