@echo off
echo Compilando los servicios...
dotnet clean Services/Projects/Projects.csproj
dotnet build Services/Projects/Projects.csproj
dotnet clean Services/Reports/Reports.csproj
dotnet build Services/Reports/Reports.csproj
dotnet clean Web/OlWebApp/OlWebApp.csproj
dotnet build Web/OlWebApp/OlWebApp.csproj

echo Ejecutando el servicio Projects...
start /d "." dotnet watch run --project Services/Projects/Projects.csproj --urls "http://localhost:5003;https://localhost:5004"

echo Ejecutando el servicio Reports...
start /d "." dotnet watch run --project Services/Reports/Reports.csproj --urls "http://localhost:5001;https://localhost:5002"

echo Ejecutando la aplicación web...
start /d "." dotnet watch run --project Web/OlWebApp/OlWebApp.csproj --urls "http://localhost:5005;https://localhost:5006"