# WebSocket Print Server

Este proyecto implementa un servidor WebSocket simple en C#, diseñado para escuchar conexiones en el puerto 3035 y manejar solicitudes específicas de impresión.

## Características

- Servidor WebSocket que escucha en `ws://127.0.0.1:3035`.
- Manejo de conexiones WebSocket a través de la ruta `/Print`.

## Requisitos

Para ejecutar este proyecto, necesitarás:

- [.NET Core SDK](https://dotnet.microsoft.com/download) (versión 3.1 o superior).

## Cómo ejecutar

1. Clona este repositorio a tu máquina local.
2. Abre una terminal y navega al directorio del proyecto.
3. Ejecuta el comando `dotnet run` para iniciar el servidor.
4. El servidor ahora está escuchando conexiones en `ws://127.0.0.1:3035`.

## Uso

Para usar este servidor, conecta tu cliente WebSocket a `ws://127.0.0.1:3035/Print`. El servidor manejará las solicitudes de impresión enviadas a esta ruta.

## Contribuir

Si deseas contribuir a este proyecto, por favor sigue estos pasos:

1. Haz fork del repositorio.
2. Crea una nueva rama para tu característica o corrección.
3. Haz tus cambios.
4. Envía un pull request.

Agradecemos cualquier contribución que ayude a mejorar el proyecto.

## Licencia

Este proyecto está licenciado bajo [MIT License](LICENSE).