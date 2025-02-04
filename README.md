# BlazorServer_ControlDinero

App en Blazor Server para gestión de gastos
Base de datos: SQL Server + Migraciones. 


## Instalaciones 

1. Tomar Cambios de la rama actual
```
git push
```
2. Ejecutar primero 
```
dotnet restore
```
3. Ajustar cadena de conexión para SQL Server en el archivo "appsettings.json".
4. Ejecutar las migraciones para montar la base de datos correctamente. 
- Usando Visual Studio, abrir consola de administrador de paquetes y escribir.
```
update-database
```
- Usando VS Code ó cualquier otro IDE, o el editor de preferencia, abrir nueva terminal y ejecutar
```
dotnet ef database update
```
- Usando igualmente cualquier ventana de comandos del sistema ejecutar.
```
dotnet ef database update
``` 

