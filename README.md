# Practical lessons on the .NET Microservices - Full Course

Original video cource: https://www.youtube.com/watch?v=DgVjEo3OGBI

## PlatformService

Create PlatformService

```sh
dotnet new webapi -n PlatformService
code -r PlatformService
```

### Docker

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

## CommandsService

Create CommandsService

```sh
dotnet new webapi -n CommandsService
```

