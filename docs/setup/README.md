# Setup del entorno

## .NET 10 SDK (Linux / WSL)

```bash
# Ubuntu/Debian — script oficial
curl -sSL https://dot.net/v1/dotnet-install.sh | bash -s -- --channel 10.0
echo 'export PATH="$HOME/.dotnet:$PATH"' >> ~/.zshrc && source ~/.zshrc
dotnet --version   # 10.0.x
```

`global.json` en la raíz fija el SDK 10.0.401 con `rollForward: latestPatch`.

## VS Code

Instala las extensiones recomendadas (`.vscode/extensions.json`): C# Dev Kit, C#, Docker, EditorConfig.

## Docker (a partir de la semana 17)

PostgreSQL 16, RabbitMQ y Redis se levantan con `docker compose` desde el
`starter/` de cada semana que los use.

```bash
docker --version
docker compose version
```

## Herramientas globales (semanas 13+)

```bash
dotnet tool install -g dotnet-counters
dotnet tool install -g dotnet-trace
dotnet tool install -g dotnet-dump
dotnet tool install -g dotnet-ef
```

## .NET MAUI (semana 23, Android en Linux)

```bash
dotnet workload install maui-android
```

Requiere JDK 17 y Android SDK; ver guía en la semana 23. iOS y Windows
necesitan macOS/Windows y se documentan como opcionales.

## Verificación

```bash
cd bootcamp/week-01-dotnet_setup_tipos_control_flujo/2-practicas/ejercicio-01-hola-dotnet/starter
dotnet run
```
