# Projekt na PIS

## Deploy a single container to Azure

You need to create a context for ACI, and then:

```sh
docker --context <aci-context> run -p 80:80 <user>/<image>:latest
```

## Deploy with docker compose to ACI

Build and push to docker hub

```sh
docker context use default
docker compose build
docker compose push
```

Deploy to ACI

```sh
docker context use <aci-context>
docker compose up
```

## Build with Buildah and push to Docker Hub

Login (required to push)
```sh
buildah login docker.io
```

Build (example for UserProfileService)

```sh
git clone https://github.com/thejoun/pis-project.git
cd pis-project/
buildah bud -f UserProfileService/Dockerfile -t thejoun/user-profile-service .
```

Push (example for UserProfileService)
```sh
buildah push thejoun/user-profile-service:latest
```