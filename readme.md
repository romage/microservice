Github.com/binarythistle
https://github.com/binarythistle/S04E03---.NET-Microservices-Course-

## Data https://www.youtube.com/watch?v=DgVjEo3OGBI&t=3758s

## Data Layer - db prep https://www.youtube.com/watch?v=DgVjEo3OGBI&t=4560s 

## Data Layer - DTOs https://www.youtube.com/watch?v=DgVjEo3OGBI&t=5251s 

## Controller and Actions https://www.youtube.com/watch?v=DgVjEo3OGBI&t=6079s

## Part 3 - Docker and Kubernetes https://www.youtube.com/watch?v=DgVjEo3OGBI&t=8181s

## pushing to docker hub https://www.youtube.com/watch?v=DgVjEo3OGBI&t=9449s

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







