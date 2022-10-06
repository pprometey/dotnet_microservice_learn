# CommandsService

Commands Service from a simplified example of building a microservice application.

Add packages

```sh
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

## Docker

Build docker image:

```sh
docker build -f Dockerfile -t pprometey/commandsservice .
```

Run docker container:

```sh
docker run -d -p 8080:80 --name CommandsService pprometey/commandsservice
```

Push docker:

```sh
docker push pprometey/commandsservice
```
