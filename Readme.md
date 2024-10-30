# **PROYECTO MISCUENTAS -version Desktop-**

![imagen](/Resources/presentacion.png)

[![Kotlin](https://img.shields.io/badge/Code-CSHARP-blueviolet)](https://kotlinlang.org/) [![LICENSE](https://img.shields.io/badge/Lisence-CC-%23e64545)](https://leocare.dev/docs/license/) ![GitHub](https://img.shields.io/github/last-commit/LeoCare/MisCuentas_desk)

## **Tabla de Contenido**

- [Descripción del Proyecto](#descripcion-del-proyecto)
- [Características Principales](#caracteristicas-principales)
- [Requisitos del Sistema](#requisitos-del-sistema)
- [Instalacion 1](#instalacion-1)
- [Instalacion 2: Configuración y Ejecución](#instalacion-2-configuracion-y-ejecucion)
  - [1. Clonar el Repositorio](#clonar-el-repositorio)
  - [2. Abrir el Proyecto en Visual Studio](#abrir-el-proyecto-en-visual-studio)
  - [3. Restaurar Paquetes NuGet (si aplica)](#restaurar-paquetes-nuget-si-aplica)
  - [4. Compilar el Proyecto](#compilar-el-proyecto)
  - [5. Ejecutar la Aplicación](#ejecutar-la-aplicación)
- [Creación del Instalador](#creacion-del-instalador)
  - [1. Instalación de la Extensión Visual Studio Installer Projects](#instalacion-de-la-extension-visual-studio-installer-projects)
  - [2. Crear el Proyecto de Instalación](#crear-el-proyecto-de-instalacion)
  - [3. Configurar el Instalador](#configurar-el-instalador)
  - [4. Compilar el Instalador](#compilar-el-instalador)
  - [5. Distribuir el Instalador](#distribuir-el-instalador)
- [Uso de la Aplicación](#uso-de-la-aplicacion)
  - [Conexion y Logeo](#conexion-y-logeo)
  - [Formularios](#formularios)
	- [Mis Datos](#mis-datos)
	- [Informes](#informes)
	- [Solicitudes](#solicitudes)
	- [Avanzado](#avanzado)
  - [Listar Atributos en ComboBox](#listar-atributos-en-combobox)
  - [Filtrar Datos](#filtrar-datos)
  - [Visualización en DataGridView](#visualizacion-en-datagridview)
  - [Validación de Entradas](#validacion-de-entradas)
- [Solución de Problemas Comunes](#solucion-de-problemas-comunes)
  - [Problemas con Íconos en Accesos Directos](#problemas-con-iconos-en-accesos-directos)
- [Autor](#autor)
   - [Contacto](#contacto)
   - [Contribucion](#contribucion)
   - [Licencia](#licencia)

---

## **Descripción del Proyecto**

Esta es una aplicación de **Windows Forms** desarrollada en **C#** que permite gestionar los datos personales, las **Hojas** y los **Participantes** de aquellos datos creados a travez de la aplicacion movil **MISCUENTAS**. Proporciona funcionalidades para:

- Validar entradas de datos.
- Gestion de los datos personales.
- Gestion de credenciales.
- Filtrar, Modificar o Eliminar Hojas y Participantes.
- Listar Hojas, Gastos, Pagos, Balances.
- Enviar Emails a los deudores.

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
- **Manejo de Excepciones**: Implementa manejo de errores comunes, como `NullReferenceException`.
- **Envio de Email**: Envio de email a los participantes que tengan una deuda pendiente.

---

## **Requisitos del Sistema**

- **Sistema Operativo**: Windows 7 o superior.
- **.NET Framework**: Versión 4.8 o superior.
- **Visual Studio**: 2019 o superior (para desarrollo).
- **Extensión**: Microsoft Visual Studio Installer Projects (para crear el instalador).

---

## **Instalacion 1**

Si tienes el instalador,.msi, simplemente haz doble click y sigue los pasos que se indican.
![imagen de la instalcion](/Resources/instalacion.png)
Si no es el caso, dirigete al siguiente punto.

---
## **Instalacion 2: Configuración y Ejecución**

### **1. Clonar el Repositorio**

Clona el repositorio del proyecto a tu máquina local:

```bash
git clone git@github.com:LeoCare/MisCuentas_desk.git
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

## **Uso de la Aplicación**

### **Conexion y Logeo**

En la parte superior derecha hay dos indicadores, el mundo indica la conexion a la BBDD (verde = conectado; rojo = desconectado).
El otro indicador es el de inicio de sesion, debe presionar en este para ir a la ventan de LOGEO/REGISTRO.
![imagen de la instalcion](/Resources/logeo1.png)

### **Formularios**

Una vez dentro, disponemos de 3 formularios distintos:

- **Mis Datos:** Ventana donde poder Introducir/Modificar nuestros datos personales, así como `Cambiar la contraseña` o `Eliminar nuestra cuenta`.
![imagen de misdatos](/Resources/misdatos.png)

- **Informes:** Aquí podremos ver los datos de nuestras actividades, `Hojas`, `Gastos`, `Pagos` y `Balances`.
![imagen del informe](/Resources/informes.png)

- **Solicitudes:** En Solicitudes podemos ver nuestros balances con los participantes que nos deben algun importe y aquellas deudas que aun tenemos pendientes. A nuestros deudores podemos enviarles un correo para informarles que aun esa pendiente el pago.
![imagen de la solicitud](/Resources/solicitudes.png)
Ejemplo del email:
![imagen de la solicitud](/Resources/email.png)

- **Avanzado:** Por ultimo, esta ventana nos permite modificar, crear o eliminar tanto Hojas como Participantes.
![imagen de la ventana avanzado](/Resources/avanzado.png)

### **Listar Atributos en ComboBox**

- Los atributos de las clases `Hoja` y `Participante` se listan automáticamente en un `ComboBox` utilizando reflexión.
- Permite al usuario seleccionar un atributo para realizar búsquedas o filtrados.

### **Filtrar Datos**

- **Filtrado Dinámico**: Basado en el atributo y valor ingresado por el usuario.
- Utiliza métodos genéricos que manejan diferentes tipos de datos y realizan comparaciones adecuadas.

### **Visualización en DataGridView**

- Los resultados de las búsquedas y filtrados se muestran en un `DataGridView` a modo de tablas.
- Solo se muestran las columnas relevantes, como el título de la hoja o el nombre del participante.
- Al seleccionar un elemento en el `DataGridView`, los detalles se muestran en otros controles `TextBox`.

### **Validación de Entradas**

La aplicación incluye validaciones para asegurar que los datos ingresados por el usuario sean correctos.

- **Números con Dos Decimales**: Los `TextBox` que requieren números con hasta dos decimales validan la entrada y muestran mensajes de error si es inválida.
- **Fechas Válidas**: Al hacer clic en un `TextBox` destinado a fechas, se muestra un calendario para asegurar la selección correcta.
- **Correos validos**: La sintaxis de los correos se valida en todos los apartados requeridos.
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

---

## Autor
Mi nombre es <b>Leonardo David Care Prado</b>, soy tecnico en sistemas y desarrollador de aplicaciones multiplataforma, o eso espero con este proyecto...jjjjj.<br>
A fecha de este año (2024) llevo 4 años realizando trabajos de desarrollo para la misma empresa, ademas de soporte y sistemas.<br>
Estos desarrollos incluyen lenguajes como Html, C#, Xamarin, Oracle, Java y Kotlin.

[![Html](https://img.shields.io/badge/Code-Htmnl-blue)](https://www.w3schools.com/html/) [![C#](https://img.shields.io/badge/Code-C_SHARP-green)](https://dotnet.microsoft.com/es-es/languages/csharp) [![Xamarin](https://img.shields.io/badge/Code-Xamarin-red)](https://dotnet.microsoft.com/es-es/apps/xamarin) [![Oracle](https://img.shields.io/badge/Code-Oracle-white)](https://www.oracle.com/es/) [![Java](https://img.shields.io/badge/Code-Java-orange)](https://www.java.com/es/) [![Kotlin](https://img.shields.io/badge/Code-Kotlin-blueviolet)](https://kotlinlang.org/)

### Contacto
Para cualquier consulta o aporte puedes comunicarte conmigo por correo<br>
[leon1982care@gmail.com](https://mail.google.com/mail/u/0/?pli=1#inbox)
<p><a href="https://mail.google.com/mail/u/0/?pli=1#inbox" target="_blank">
        <img src="https://ams3.digitaloceanspaces.com/graffica/2021/06/logogmailgrafica-1-1024x576.png" 
    height="30" alt="correo_electronico">
</a></p> 

## Contribucion
Gracias a todos los que aporten nuevas ideas de como mejorar mi proyecto. Sientance libres de participar, cambiar u opinar sobre el mismo.</br>
Solo pido que al crear la rama, esta comience por 'contribucion/lo_que_aporteis'. Y, el commit sea claro y descriptivo.</br>
En caso de necesitar documentar los nuevos cambios, seguir con el uso de las libreria mensionada en el apartado [Documentaciones](#documentaciones).</br>
Muchisimas gracias a todos!

## Licencia
Este repositorio y todo su contenido estan bajo la licencia de **Creative Commons**. Solo pido que si haces uso de ella, me cites como el autor.</br>
<a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/"><img alt="Creative Commons License" style="border-width:0" src="https://i.creativecommons.org/l/by-nc-sa/4.0/88x31.png" /></a>

<a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/">Creative Commons
Attribution-NonCommercial-ShareAlike 4.0 International License</a>.