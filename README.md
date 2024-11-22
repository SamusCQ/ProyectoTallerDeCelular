# Proyecto Taller de Celulares

Este proyecto es una aplicación de escritorio desarrollada en **C# Windows Forms** para la gestión de un Taller de Celulares. Contiene funcionalidades básicas para administrar los datos relacionados con los servicios del taller.

## Instalación del Proyecto

Sigue estos pasos para configurar y ejecutar el proyecto correctamente en tu máquina local.

### Requisitos del Sistema
1. **SQL Server**:  
   - Asegúrate de tener instalado **SQL Server** (versión 2016 o superior) con la instancia `SQLEXPRESS` habilitada.
   - Habilita el servicio **SQL Server Browser** si es necesario.
2. **Visual Studio**:  
   - Descarga e instala Visual Studio 2019 o superior con soporte para proyectos **.NET Framework**.
3. **Respaldo de la Base de Datos**:  
   - El archivo de respaldo de la base de datos se encuentra en la carpeta `database` y se llama `DbCelular_20241106.bak`.

### Configuración de la Base de Datos
1. Abre **SQL Server Management Studio (SSMS)** o cualquier cliente compatible.
2. Restaura la base de datos utilizando el archivo `DbCelular_20241106.bak`:
   - Haz clic derecho sobre **Bases de datos** y selecciona **Restaurar base de datos...**.
   - En la opción **Dispositivo**, selecciona el archivo `DbCelular_20241106.bak`.
   - Asegúrate de que el nombre de la base de datos sea `DbCelular`.
3. Verifica que la restauración sea exitosa y que puedas acceder a la base de datos.

### Configuración del Proyecto
El proyecto utiliza una clase llamada `DatabaseConector` para gestionar la conexión a la base de datos. La cadena de conexión predeterminada está configurada de la siguiente manera:
```csharp
Server=.\SQLEXPRESS;Database=DbCelular;Trusted_Connection=True;
```

No necesitas realizar cambios en esta configuración si:
- La instancia de SQL Server es `SQLEXPRESS`.
- Usas autenticación de Windows.
- La base de datos restaurada tiene el nombre `DbCelular`.

Si necesitas cambiar el nombre del servidor, usar otro tipo de autenticación o un nombre diferente para la base de datos, actualiza la cadena de conexión en la clase `DatabaseConector` ubicada en `proyectoFinalPOE/Controlador/DatabaseConector.cs`.

### Ejecución del Proyecto
1. Abre el archivo de solución (`.sln`) del proyecto en Visual Studio.
2. Configura la solución para que se ejecute en **modo Debug**.
3. Haz clic en **Iniciar** para ejecutar la aplicación.

## Notas Importantes
- Asegúrate de que tu servidor SQL esté configurado para aceptar conexiones locales.
- Si usas una configuración diferente a `Trusted_Connection=True`, actualiza la cadena de conexión con un usuario y contraseña válidos:
  ```csharp
  Server=.\SQLEXPRESS;Database=DbCelular;User Id=usuario;Password=contraseña;
  ```
