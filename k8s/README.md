# Deploy application to k8s

Check state k8s

```sh
kubectl version --short
```

Deploy Platform Service

```sh
 kubectl apply -f .\platform-deploy.yaml
```

Get state deployments

```sh
kubectl get deployments
```

Get state pods

```sh
kubectl get pods
```

Remove deployment Platform Service

```sh
kubectl delete deployment platform-deploy
```

Get kubernetes services

```sh
kubectl get services
```

Restart deploy Platform Service

```sh
kubectl rollout restart deployment platforms-deploy
```

Deploy Commands Service

```sh
kubectl apply -f .\commands-deploy.yaml
```

Deploy ingress-nginx

```sh
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.4.0/deploy/static/provider/cloud/deploy.yaml
```

Get k8s namespaces

```sh
kubectl get namespaces
```

Get pods in ingress-nginx namespace

```sh
kubectl get pods --namespace=ingress-nginx
```

Get services in ingress-nginx namespace

```sh
kubectl get services --namespace=ingress-nginx
```

Deploy ingress-nginx service

```sh
kubectl apply -f ingress-srv.yaml
```

Get k8s storages

```sh
kubectl get storageclass
```

Reserve storage for mssql

```sh
kubectl apply -f local-pvc.yaml
```

Get k8s Persistent Volume Claims

```sh
kubectl get pvc  
```

Create secret form password admin user (SA) for MSSQL

```sh
kubectl create secret generic mssql --from-literal=SA_PASSWORD="pa55w0rd!"
```

Check syntaxis k8s config file

```sh
kubectl create --dry-run=client --validate -f mssql-platform-deploy.yaml
```

Deploy mssql service

```sh
kubectl apply -f mssql-platform-deploy.yaml
```
