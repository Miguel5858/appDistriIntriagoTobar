docker-compose -f .\docker-compose-services-mq.yml up -d


1.-Crear archivo Dockerfile
2.-Crear archivo .dockerignore
3.-Configurar archivo Dockerfile con el nombre del proyecto
4.-Crear un appseetting.docker.json para que se ejecute la siguiente linea:  ENV ASPNETCORE_ENVIRONMENT docker
5.-Consultar el nombre del contenerdor de base de datos en NAMES con el comando docker ps
6.-Cambiar localhost por el nombre del contenedor database-sql en el appseetting.docker.json
7.-En el dockerfile son dos partes: construccion y ejecución
8.-En la ruta base del proyecto donde esta el  Dockerfile abrir cmd y ejecutar:
9.-docker build -t webapiperson .
10.- se crea la imagen
11.- verificar la imagen con el comando: docker images
12.- verificar los contenedores que estan en la red que se creo anteriormente en el docker-compose
docker inspect netappdistri
13.- En Containers verificamos que ya esta el contenedor "database-sql"
14.-Crear contenedor de la imagen agregando a la red existente
docker run --name webapipersoncontainer -d -p 5000:81 --network netappdistri webapiperson




-- si no tiene la red crear con el comando:
docker network create netappdistri
--agregar contenedor a una red
docker network connect netappdistri database-postgres


--verificar el logs del contenedor en el puerto
docker logs echistorycontainer


http://localhost:5000/api/proyecto


--borrar contenedor
docker rm -f proyecto