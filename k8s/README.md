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
