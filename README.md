# PicoService

Place `PicoGK.dll` in the `libs/` directory before building.

## Publish

```bash
dotnet publish -c Release
```

## Run locally

```bash
dotnet run
```

## Docker

```bash
docker build -t picoservice .
docker run -p 8080:80 picoservice
```
