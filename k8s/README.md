# Deploy application to k8s

Check state k8s

```sh
kubectl version --short
```

Deploy

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

Remove deployment

```sh
kubectl delete deployment platform-deploy
```

Get kubernetes services

```sh
kubectl get services
```

