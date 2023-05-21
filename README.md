# Projekt na PIS

### Deploy pojedynczych kontenerów na Azure

Trzeba stworzyć context dla ACI, a później:

`docker --context acicontext run -p 80:80 thejoun/blazor-client:latest`