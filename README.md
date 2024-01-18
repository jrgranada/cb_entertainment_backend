# PRUEBA TÉCNICA CB

## Contenido
  * [Descripción](#descripcion)
  * [Prerrequisitos](#prerrequisitos)
  * [Despliegue en Docker utilizando el docker-compose](#despliegue)

<a name="descripcion"></a>
## Descripción

Este proyecto contiene la información necesaria para desplegar el backend del proyecto en Docker.

### Framework utilizado:
* .Net: Versión 8.0 [Sitio Oficial][LinkNet]

[LinkNet]: https://dotnet.microsoft.com/es-es/learn/dotnet/what-is-dotnet-framework

<a name="prerrequisitos"></a>
## Prerrequisitos

* Tener instalado Docker [Sitio Oficial][LinkDocker]

[LinkDocker]: https://www.docker.com/products/docker-desktop/

* Se requiere de conexión a Internet para descargar el proyecto, la imágen base de dotnet, además de las librerías y dependencias.

<a name="despliegue"></a>
## Despliegue en Docker

### Clonar el proyecto:
Desde la línea de comando del sistema, ingrese a la carpeta donde quiere descargar el proyecto y ejecute la siguiente instrucción:

```bash
git clone https://github.com/jrgranada/cb_entertainment_backend.git
```

### Despliegue de la solución

Para el despliegue de la solución abra el poryecto con Visual Studio y realice el despliegue en Docker.

Antes de acceder a la aplicación es necesario conocer el puerto que le fue asignado, normalmente un puerto para las peticiones http y otro para las https, esta información se requiere al momento de desplegar el forntend de la solución.

### Accediendo a la aplicación

La URL para acceder al Open API de la aplicación debe lucir de la siguiente manera: https://localhost:32776/swagger/index.html ,usted debe cambiar el puerto a esta URL, una vez hecho el ajuste puede ir a través de un navegador web.
