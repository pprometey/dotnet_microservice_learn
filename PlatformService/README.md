# PlatformService

Platform Service from a simplified example of building a microservice application.

Add packages

```sh
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

## Docker

Build docker image:

```sh
docker build -f Dockerfile -t pprometey/platformservice .
```

Run docker container:

```sh
docker run -d -p 8080:80 --name PlatformService pprometey/platformservice
``` 

Push docker:

```sh
docker push pprometey/platformservice
```

## DB Migration

Install dotnet-ef tool

```sh
dotnet tool install --global dotnet-ef
```

Add first db migration

```sh
dotnet-ef migrations add InitialMigration
```

## RabbitMQ

Add package RabbitMQ client

```sh
dotnet add package RabbitMQ.Client
```

## gRPC

Add gPRC server package

```sh
dotnet add package Grpc.AspNetCore
```