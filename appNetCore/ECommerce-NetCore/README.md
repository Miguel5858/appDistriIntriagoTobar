# Usar comandos de Entity Framework
 En la Consola de Administrador de Paquetes digitar los siguientes comandos, deben estar en la capa de DataAccess

# Crear comando y versión de las tablas a crear en BDD
add-migration CreateEntidadesBDD

# Crear entidades en Base de datos
Update-database


## Tambien pueden ejecutar los comandos por powerShell
dotnet ef migrations add CreateEntidadesBDD

dotnet ef database update
