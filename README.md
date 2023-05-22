# Projekt na PIS

### Deploy pojedynczych kontenerów na Azure

Trzeba stworzyć context dla ACI, a później:

`docker --context <aci-context> run -p 80:80 <user>/<image>:latest`

### Deploy docker-compose'a

```sh
docker context use default
docker compose build
docker compose push
docker context use <aci-context>
docker compose up
```