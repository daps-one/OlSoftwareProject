@echo off
echo Compilando los servicios...
dotnet build Services/Projects/Projects.csproj
dotnet build Services/Reports/Reports.csproj

echo Ejecutando el servicio Projects...
start /d "." dotnet watch run --project Services/Projects/Projects.csproj --urls "http://localhost:5003;https://localhost:5004"

echo Ejecutando el servicio Reports...
start /d "." dotnet watch run --project Services/Reports/Reports.csproj --urls "http://localhost:5001;https://localhost:5002"