# prueba_tecnica_alejandro_vertel_reimagine
Prueba Técnica para Desarrollador Backend con .NET

# Paso a paso para probar la API

1. Dentro del repositorio se encuentra un archivo docker-compose con la configuración del container con la imagen de postgres para obtener una BD local.
2. Tener docker instalado
3. Utilizar el comando `docker-compose up -d` para levantar la imagen y el container
4. Una vez se tenga esto corriendo se puede correr el proyecto con normalidad, una ventana de Swagger se mostrará con los distintos endpoints.
5. En caso de querer conectarse por medio de algún DBMS (pgAdmin, DBeaver, etc.), estas son las credenciales: 

```
host: localhost
database: PruebaTecnicaReImagine
port: 5005
user: postgres
password: postgres
```
