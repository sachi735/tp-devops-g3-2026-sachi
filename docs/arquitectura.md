# Arquitectura inicial

El proyecto se organiza como una API .NET 8 Minimal API con una estructura simple y preparada para crecer.

## Estructura

```txt
src/
  DevOpsTp.Api/
    Program.cs

tests/
  DevOpsTp.Tests/
    ApiSkeletonTests.cs

docs/
  arquitectura.md
  screenshots/

.github/
  workflows/
```

## Decisiones iniciales

- Se utiliza .NET 8 por ser una versión moderna del ecosistema .NET.
- Se utiliza Minimal API para mantener el proyecto simple y enfocado en prácticas DevOps.
- Se agregan endpoints técnicos desde el inicio para facilitar health checks, monitoreo y pruebas de despliegue.
- Se utiliza Swagger/OpenAPI para documentar y probar la API visualmente.
- Se agregan tests automatizados desde la primera versión del proyecto.
- No se incorpora base de datos en la primera etapa para evitar complejidad innecesaria.
