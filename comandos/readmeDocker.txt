docker-compose -f .\docker-compose-services-mq.yml up -d


-- docker proyecto history --
--crear ambiente para docker en el appseetting


docker ps
docker build -t ecommercehistory .
-- en minuscula y el . cuando esta en la ruta del archivo docker

--cuando se termina de configurar docker con el servicio history
--verificar si se creo la imagen
docker images

--verificar los contenedores que estan en la red que se creo 
docker inspect netappdistri


-- si no tiene la red crear con el comando:;
docker network create netappdistri
--agregar contenedor a una red
docker network connect netappdistri database-postgres


--crear contenedor
docker run --name echistorycontainer -d -p 5000:80 --network netappdistri ecommercehistory

--verificar el logs del contenedor en el puerto
docker logs echistorycontainer


http://localhost:5000/api/History


--borrar contenedor
docker rm -f historycontainer