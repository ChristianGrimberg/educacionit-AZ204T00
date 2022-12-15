---
document:
  az204Class: 'Clase 12'
  az204Title: 'Módulo 12'
---

# Clase 12

## Preparacion del ambiente en Azure

### Variables a utilizar

```pwsh
$resourceGroup="educacionit-clase12"
$webApp="web-clase-12"
$appPlan="plan-clase-12"
```

### Grupo de recursos para los laboratorios

1. Crear un nuevo grupo de recursos
    ```pwsh
    az group create -n $resourceGroup -l EastUs2
    ```

## Trabajando con Application Insights

### Nueva aplicación de consola y publicacion

1. Directorio de trabajo
    ```pwsh
    cd labs/class12
    ```
1. Crear proyecto de .NET
    ```pwsh
    dotnet new webapi --name HelloApi --framework net6.0
    dotnet dev-certs https --trust
    ```
1. Inyectar librerias
    ```pwsh
    dotnet add package Microsoft.ApplicationInsights
    dotnet add package Microsoft.ApplicationInsights.AspNetCore
    dotnet add package Microsoft.ApplicationInsights.PerfCounterCollector
    dotnet add package Microsoft.ApplicationInsights.Profiler.AspNetCore
    dotnet add package Microsoft.Extensions.Logging.ApplicationInsights
    ```
1. Agregar configuraciones para la construccion del sitio .NET durante el despliegue
    ```pwsh
    az webapp config appsettings set -g $resourceGroup -n $webApp --settings SCM_DO_BUILD_DURING_DEPLOYMENT=true

    az webapp config appsettings set -g $resourceGroup -n $webApp --settings StorageConnectionString=$connectionString
    ```
1. Subir proyecto
    ```pwsh
    az webapp up -g $resourceGroup -n $webApp -p $appPlan -r "dotnet:6"
    ```

## Eliminacion de los recursos en Azure

1. Eliminacion del grupo de recursos
    ```pwsh
    az group delete -n $resourceGroup --no-wait
    ```
