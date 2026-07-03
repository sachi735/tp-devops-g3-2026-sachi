# Status page

## Objetivo

El endpoint `/status` funciona como una status page liviana para validar rapidamente el estado operativo de la API.

Esta mejora cubre la funcionalidad opcional de crear una status page sin depender de servicios externos pagos. Puede consultarse desde el navegador, desde Render o desde herramientas de monitoreo.

## Endpoint

```txt
GET /status
```

## Informacion expuesta

La respuesta incluye:

- estado general del servicio;
- nombre del servicio;
- ambiente de ejecucion;
- version, commit y fecha de build;
- fecha de arranque;
- uptime en segundos;
- checks basicos de API, store en memoria y exportacion de telemetria.

## Ejemplo de validacion

Local:

```bash
curl http://localhost:8080/status
```

Render:

```bash
curl https://tp-devops-g3-2026-sachi.onrender.com/status
```

## Uso operativo

El endpoint permite revisar rapidamente si la API esta operativa y si la exportacion OTLP esta configurada en el ambiente actual.

Tambien puede usarse como evidencia en la presentacion del trabajo practico junto con `/health`, `/ready`, `/diagnostics/slow` y `/diagnostics/error`.
