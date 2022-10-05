# PlatformService

Platform Service from a simplified example of building a microservice application.

```
dotnet new webapi -n PlatformService
code -r PlatformService
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
