# DevOps TP API

API base desarrollada para el trabajo práctico integrador de DevOps.

El objetivo del proyecto es construir una API simple y utilizarla como base para aplicar prácticas DevOps:

- pruebas automatizadas
- Docker
- Docker Compose
- GitHub Actions
- publicación de imagen Docker
- despliegue continuo
- monitoreo
- releases y rollback

## Stack inicial

- .NET 8
- Minimal API
- xUnit
- Swagger / OpenAPI

## Endpoints iniciales

| Método | Endpoint | Descripción |
|---|---|---|
| GET | `/` | Información general de la API |
| GET | `/health` | Health check técnico |
| GET | `/ready` | Readiness check |
| GET | `/version` | Versión de la API |
| GET | `/diagnostics/ping` | Endpoint simple de diagnóstico |
| GET | `/diagnostics/error` | Error controlado para monitoreo |
| GET | `/diagnostics/slow` | Endpoint lento para pruebas de APM |

## Ejecutar localmente

```bash
dotnet restore
dotnet build
dotnet test
dotnet run --project src/DevOpsTp.Api
```

## Swagger

Una vez levantada la API, abrir:

```txt
http://localhost:<puerto>/swagger
```

## Estado del proyecto

- [x] Esqueleto de API
- [x] Health check
- [x] Swagger
- [x] Tests básicos
- [ ] Módulo funcional concreto
- [ ] Dockerfile
- [ ] Docker Compose
- [ ] CI/CD
- [ ] Publicación de imagen
- [ ] Deploy
- [ ] Monitoreo
