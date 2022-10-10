# Practical lessons on the .NET Microservices - Full Course

Original video cource: https://www.youtube.com/watch?v=DgVjEo3OGBI

## PlatformService

Create PlatformService

```sh
dotnet new webapi -n PlatformService
code -r PlatformService
```


## CommandsService

Create CommandsService

```sh
dotnet new webapi -n CommandsService
coder -r CommandsService
```

## Deploy

```sh
cd k8s

kubectl apply -f ingress-srv.yaml -f local-pvc.yaml -f mssql-platform-deploy.yaml -f rabbitmq-deploy.yaml -f platforms-np-srv.yaml -f platform-deploy.yaml -f commands-deploy.yaml 
```
