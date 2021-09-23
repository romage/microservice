Github.com/binarythistle
https://github.com/binarythistle/S04E03---.NET-Microservices-Course-

## Data https://www.youtube.com/watch?v=DgVjEo3OGBI&t=3758s

## Data Layer - db prep https://www.youtube.com/watch?v=DgVjEo3OGBI&t=4560s 

## Data Layer - DTOs https://www.youtube.com/watch?v=DgVjEo3OGBI&t=5251s 

## Controller and Actions https://www.youtube.com/watch?v=DgVjEo3OGBI&t=6079s

## Part 3 - Docker and Kubernetes https://www.youtube.com/watch?v=DgVjEo3OGBI&t=8181s

## pushing to docker hub https://www.youtube.com/watch?v=DgVjEo3OGBI&t=9449s

> docker build -t romage/platformservice .

https://github.com/romage/microservice

https://hub.docker.com/

https://hub.docker.com/_/microsoft-dotnet-sdk

https://docs.microsoft.com/en-us/visualstudio/containers/overview?view=vs-2019

https://insomnia.rest/download

> docker run -p 8080:80 -d romage/platformservice
> docker ps

## introduction to kubernetes https://www.youtube.com/watch?v=DgVjEo3OGBI&t=9763s

## kubernetes architechture overview https://www.youtube.com/watch?v=DgVjEo3OGBI&t=10014s

Kubernetes - Cluster > Node > Pod  > docker container(s)
Node port
Cluster IP 
Ingress Nginx Container 
Persistant volume claim (dbs are not stateless)
Pods > 
> Ingress Nginx 
> Command Service
> Command Service Sql
> Platform Service
> Platform Service SQL
> Rabbit MQ

## Deploy platform service (kubernetes) https://www.youtube.com/watch?v=DgVjEo3OGBI&t=10720s

K8S = Kubernetes
(from within the k8s folder command line...)
> kubectl version
> kubectl apply -f platforms-depl.yaml
> kubectl get deployments
> kubectl get pods
> kubects delete deployment platforms-depl
> kubects get services

## Part 4 - Starting our 2nd Service https://www.youtube.com/watch?v=DgVjEo3OGBI&t=12301s

> dotnet add webapi -n CommandsService
> cd CommandsService
https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/
> dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
> dotnet add package Microsoft.EntityFrameworkCore
> dotnet add package Microsoft.EntityFrameworkCore.Design
> dotnet add package Microsoft.EntityFrameworkCore.InMemory


## Adding HttpClient https://www.youtube.com/watch?v=DgVjEo3OGBI&t=14121s

## Deploying Services to Kubernetes https://www.youtube.com/watch?v=DgVjEo3OGBI&t=15574s


> docker build -t romage/commandservice .
> docker push romage/commandservice 


> kubectl apply -f platforms-depl.yaml
> kubectl get services
> kubectl get deployments

## Adding an API Gateway https://www.youtube.com/watch?v=DgVjEo3OGBI&t=17095s


> kubectl rollout restart deployment platforms-dep
> kubectl apply -f commands-depl.yaml
> kubectl rollout restart deployment commands-dep


https://github.com/kubernetes/ingress-nginx
> kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.0.0/deploy/static/provider/cloud/deploy.yaml

> kubectl get namespaces
> kubectl get pods --namespace=ingress-ng
> kubectl get services


update hosts file to include acme.com (ingress host address)
127.0.0.1 acme.com

> kubectl apply -f ingress-srv.yaml
> kubectl rollout restart deployment ingress-srv.yaml


> kubectl delete deployments ingress-nginx-controller --namespace=ingress-nginx

## Part 5 - Startign with Sql Server https://www.youtube.com/watch?v=DgVjEo3OGBI&t=18432s
> kubectl get storageclass
> kubectl get pvc 
> kubectl apply -f local-pvc.yaml

## Adding a Kubernetes Secret https://www.youtube.com/watch?v=DgVjEo3OGBI&t=18754s
> kubectl create secret generic mssql --from-literal=SA_PASSWO secret generic mssql --from-liRD="pa55w0rd!"

> kubectl apply -f mssql-plat-depl.yaml
> kubectl get services
> kubectl get pods

## Accessing via ssms https://www.youtube.com/watch?v=DgVjEo3OGBI&t=19831s

should now be able to connect using destop sql server
note the server name uses a comma (not a colon) ...
Server name: localhost, 1433
Authentication: SQL Server Authentication
Login: sa
Password (as specified in the secrets store)


> dotnet ef migrations add initialmigation
if ef is not reconised, this was split out in dotnet 3, and can be included globally by:
> dotnet tool install --global dotnet-ef


## Updating the platform service to use sql server https://www.youtube.com/watch?v=DgVjEo3OGBI&t=19986s


## Part 6 - multi-resource api https://www.youtube.com/watch?v=DgVjEo3OGBI&t=21962s

## https://www.youtube.com/watch?v=DgVjEo3OGBI&t=22171s
## https://www.youtube.com/watch?v=DgVjEo3OGBI&t=24326s
## Part 7 MessageQ and Rabbit MQ https://www.youtube.com/watch?v=DgVjEo3OGBI&t=26449s
## Rabbit MQ to Kubernetes https://www.youtube.com/watch?v=DgVjEo3OGBI&t=26935s