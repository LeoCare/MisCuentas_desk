# **PROYECTO MISCUENTAS VERSION ESCRITORIO**

## **Tabla de Contenido**

- [Descripción del Proyecto](#descripción-del-proyecto)
- [Características Principales](#características-principales)
- [Requisitos del Sistema](#requisitos-del-sistema)
- [Configuración y Ejecución](#configuración-y-ejecución)
  - [1. Clonar el Repositorio](#1-clonar-el-repositorio)
  - [2. Abrir el Proyecto en Visual Studio](#2-abrir-el-proyecto-en-visual-studio)
  - [3. Restaurar Paquetes NuGet (si aplica)](#3-restaurar-paquetes-nuget-si-aplica)
  - [4. Compilar el Proyecto](#4-compilar-el-proyecto)
  - [5. Ejecutar la Aplicación](#5-ejecutar-la-aplicación)
- [Uso de la Aplicación](#uso-de-la-aplicación)
  - [Validación de Entradas](#validación-de-entradas)
  - [Listar Atributos en ComboBox](#listar-atributos-en-combobox)
  - [Filtrar Datos](#filtrar-datos)
  - [Visualización en DataGridView](#visualización-en-datagridview)
  - [Manejo de Eventos](#manejo-de-eventos)
- [Creación del Instalador](#creación-del-instalador)
  - [1. Instalación de la Extensión Visual Studio Installer Projects](#1-instalación-de-la-extensión-visual-studio-installer-projects)
  - [2. Crear el Proyecto de Instalación](#2-crear-el-proyecto-de-instalación)
  - [3. Configurar el Instalador](#3-configurar-el-instalador)
  - [4. Compilar el Instalador](#4-compilar-el-instalador)
  - [5. Distribuir el Instalador](#5-distribuir-el-instalador)
- [Solución de Problemas Comunes](#solución-de-problemas-comunes)
  - [Problemas con Íconos en Accesos Directos](#problemas-con-íconos-en-accesos-directos)
  - [NullReferenceException al Mostrar Datos](#nullreferenceexception-al-mostrar-datos)
- [Contribuciones](#contribuciones)
- [Licencia](#licencia)
- [Contacto](#contacto)

---

## **Descripción del Proyecto**

Esta es una aplicación de **Windows Forms** desarrollada en **C#** que permite gestionar los datos personales, las **Hojas** y los **Participantes** de aquellos datos creados a travez de la aplicacion movil **MISCUENTAS**. Proporciona funcionalidades para:

- Validar entradas de datos.
- Gestion de los datos personales.
- Gestion de credenciales.
- Listar y filtrar atributos de clases.
- Crear instaladores utilizando **Visual Studio Installer Projects**.

---

## **Características Principales**

- **Inicio de sesion (Logeo)**: Permite el inico de sesion de aquellos usuarios con perfiles de Administrador.
- **Registro**: Registro de nuevos usuarios de la aplicacion de escritorio.
- **Modificacion de datos**: Creacion y modificacion de datos personales.
- **Validación de Datos**: Verifica que las entradas del usuario sean correctas, tanto importes como correos o validacion de contraseñas.
- **Listar Atributos**: Utiliza **reflexión** para obtener y listar los atributos de las clases `Hoja` y `Participante`.
- **Modificacion de entidades**: Permite Agregar, Modificar o Eliminar tanto 'Hojas' como 'Participantes'.
- **Filtrado Dinámico**: Permite filtrar listas de objetos basándose en el atributo y valor seleccionado por el usuario.
- **Visualización de datos**: Muestra datos filtrados y permite seleccionar elementos para ver detalles en otros controles.
- **Creación de Instalador**: Incluye pasos para generar un instalador `.msi` utilizando **Visual Studio Installer Projects**.
- **Manejo de Excepciones**: Implementa manejo de errores comunes, como `NullReferenceException`.

---

## **Requisitos del Sistema**

- **Sistema Operativo**: Windows 7 o superior.
- **.NET Framework**: Versión 4.8 o superior.
- **Visual Studio**: 2019 o superior (para desarrollo).
- **Extensión**: Microsoft Visual Studio Installer Projects (para crear el instalador).

---

## **Configuración y Ejecución**

### **1. Clonar el Repositorio**

Clona el repositorio del proyecto a tu máquina local:

```bash
git clone https://github.com/tu_usuario/tu_repositorio.git
```

### **2. Abrir el Proyecto en Visual Studio**

- Navega hasta la carpeta del proyecto.
- Abre el archivo de solución `.sln` con Visual Studio.

### **3. Restaurar Paquetes NuGet (si aplica)**

Si el proyecto utiliza paquetes NuGet, restáuralos:

- En Visual Studio, ve a **Herramientas** > **Administrador de paquetes NuGet** > **Consola del Administrador de paquetes**.
- Ejecuta:

  ```powershell
  Update-Package -reinstall
  ```

### **4. Compilar el Proyecto**

- Selecciona la configuración **"Debug"** o **"Release"** según tus necesidades.
- En el menú superior, selecciona **Compilar** > **Compilar Solución**.

### **5. Ejecutar la Aplicación**

- Presiona **F5** para ejecutar en modo depuración o **Ctrl + F5** para ejecutar sin depuración.

---

## **Uso de la Aplicación**

### **Validación de Entradas**

La aplicación incluye validaciones para asegurar que los datos ingresados por el usuario sean correctos.

- **Números con Dos Decimales**: Los `TextBox` que requieren números con hasta dos decimales validan la entrada y muestran mensajes de error si es inválida.
- **Fechas Válidas**: Al hacer clic en un `TextBox` destinado a fechas, se muestra un calendario para asegurar la selección correcta.

### **Listar Atributos en ComboBox**

- Los atributos de las clases `Hoja` y `Participante` se listan automáticamente en un `ComboBox` utilizando reflexión.
- Permite al usuario seleccionar un atributo para realizar búsquedas o filtrados.

### **Filtrar Datos**

- **Filtrado Dinámico**: Basado en el atributo y valor ingresado por el usuario.
- Utiliza métodos genéricos que manejan diferentes tipos de datos y realizan comparaciones adecuadas.

### **Visualización en DataGridView**

- Los resultados de las búsquedas y filtrados se muestran en un `DataGridView`.
- Solo se muestran las columnas relevantes, como el título de la hoja o el nombre del participante.
- Al seleccionar un elemento en el `DataGridView`, los detalles se muestran en otros controles `TextBox`.

### **Manejo de Eventos**

- **SelectionChanged**: Actualiza los detalles mostrados cuando cambia la selección en el `DataGridView`.
- **Click**: Eventos asociados a botones para mostrar formularios adicionales, como la lista de participantes.

---

## **Creación del Instalador**

La aplicación incluye instrucciones para crear un instalador utilizando **Visual Studio Installer Projects**.

### **1. Instalación de la Extensión Visual Studio Installer Projects**

- En Visual Studio, ve a **Extensiones** > **Administrar Extensiones**.
- Busca **"Microsoft Visual Studio Installer Projects"** y haz clic en **Descargar**.
- Reinicia Visual Studio si es necesario para completar la instalación.

### **2. Crear el Proyecto de Instalación**

- Haz clic derecho en la solución y selecciona **Agregar** > **Nuevo Proyecto...**.
- Selecciona **"Visual Studio Installer"** > **"Setup Project"**.
- Nombra el proyecto y haz clic en **Crear**.

### **3. Configurar el Instalador**

#### **3.1. Agregar Salida Principal**

- En el **Editor del sistema de archivos**, haz clic derecho en **"Application Folder"**.
- Selecciona **Agregar** > **"Project Output..."** y agrega la **Salida principal** de tu aplicación.

#### **3.2. Agregar Archivos Adicionales (si aplica)**

- Agrega cualquier archivo adicional que tu aplicación requiera, como bases de datos, imágenes, etc.

#### **3.3. Configurar Accesos Directos**

- Crea accesos directos en el escritorio y menú de inicio si lo deseas.
- **Asignar Íconos a los Accesos Directos**:

  - Agrega el archivo `.ico` al proyecto de instalación.
  - En las propiedades del acceso directo, establece la propiedad **Icon** al archivo `.ico` agregado.

### **4. Compilar el Instalador**

- Selecciona la configuración **"Release"**.
- En el menú superior, selecciona **Compilar** > **Compilar Solución**.
- El archivo `.msi` se generará en la carpeta `bin\Release` del proyecto de instalación.

### **5. Distribuir el Instalador**

- Proporciona el archivo `.msi` a los usuarios para que puedan instalar la aplicación fácilmente.

---

## **Solución de Problemas Comunes**

### **Problemas con Íconos en Accesos Directos**

Si el acceso directo creado por el instalador no muestra el ícono especificado:

- **Verifica que el archivo `.ico` esté agregado correctamente**:

  - Debe estar en **"Application Folder"** en el proyecto de instalación.

- **Asigna el ícono al acceso directo**:

  - En el **Editor del sistema de archivos**, haz clic derecho en el acceso directo y selecciona **Propiedades**.
  - Establece la propiedad **Icon** al archivo `.ico` que agregaste.

- **Limpia y recompila el proyecto de instalación**:

  - En el menú superior, selecciona **Compilar** > **Limpiar Solución**.
  - Luego, selecciona **Compilar** > **Compilar Solución**.

### **NullReferenceException al Mostrar Datos**

Si encuentras una excepción `NullReferenceException`:

- **Verifica que las propiedades del objeto no sean `null`** antes de acceder a ellas.
- **Utiliza operadores seguros**:

  - Usa el operador de coalescencia nula `??` o el operador de propagación nula `?.` para manejar valores `null`.
  
  ```csharp
  tbxNombre.Text = participante.Nombre ?? "";
  ```

- **Asegúrate de inicializar listas y objetos** antes de usarlos.

---

## **Contribuciones**

¡Las contribuciones son bienvenidas! Si deseas contribuir al proyecto:

1
