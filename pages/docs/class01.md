---
document:
  az204Class: 'Clase 1: Cree una aplicación web de .NET con la oferta de Azure de Plataforma como Servicio'
  az204Title: 'Módulo 1: Crear aplicaciones web con Azure App Service'
---

# Clase 1: Cree una aplicación web de .NET con la oferta de Azure de Plataforma como Servicio

## Creación del ambiente para el laboratorio

### Autenticación con Azure CLI

```pwsh
az login
```

### Variables a utilizar

```pwsh
$resourceGroup="educacionit-clase01"
$webApp="web-app-educacionit"
$appPlan="app-plan-educacionit-class01"
```

### Grupo de recursos

1. Crear un nuevo grupo de recursos
    ```pwsh
    az group create -n $resourceGroup -l EastUs2

    az group list -o table
    ```

## Nueva Aplicacion Web de .NET

1. Directorio de trabajo
    ```pwsh
    cd labs/class01/Web
    ```
1. Agregar los certificados HTTPS para el entorno de pruebas local
    ```pwsh
    dotnet dev-certs https
    ```
1. Crear una solución para nueva aplicación web de .NET
    ```pwsh
    dotnet new sln
    dotnet new webapp
    dotnet sln add .
    ```
1. Prueba de la aplicación web en el entorno local
    ```pwsh
    dotnet run
    ```
1. Crear Plan de App Service
    ```pwsh
    az appservice plan create -g $resourceGroup -n $appPlan --sku F1
    ```
1. Crear WebApp en App Service
    ```pwsh
    az webapp create -g $resourceGroup -n $webApp -p $appPlan

    az webapp list -o table
    ```
1. Agregar configuraciones para la construccion del sitio .NET durante el despliegue
    ```pwsh
    az webapp config appsettings set -g $resourceGroup -n $webApp --settings SCM_DO_BUILD_DURING_DEPLOYMENT=true

    az webapp config appsettings list -n $webApp -g $resourceGroup -o table
    ```
1. Despligue de la aplicacion desde el directorio de desarrollo
    ```pwsh
    az webapp up -g $resourceGroup -n $webApp -p $appPlan -r "dotnet:6"
    ```

## Eliminacion del ambiente del laboratorio

1. Eliminacion del grupo de recursos
    ```pwsh
    az group delete -n $resourceGroup --no-wait
    ```