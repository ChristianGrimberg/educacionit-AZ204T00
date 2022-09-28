---
title:  "Clase 2"
description: "AZ-204T00 Developing Solutions for Microsoft Azure"
permalink: class02.html
---

[⏪ Ir al inicio](index.md)

# Clase 02

## Laboratorios

### Grupo de recursos para los laboratorios de la Clase 02

1. Crear un nuevo grupo de recursos
    ```pwsh
    az group create -n educacionit-clase02 -l EastUs2
    ```

### Nueva cuenta de almacenamiento

1. Crear la cuenta de almacenamiento
    ```pwsh
    az storage account create -g educacionit-clase02 -n educacionitclass02 --sku Standard_LRS --access-tier Hot --min-tls-version TLS1_2 --public-network-access Enabled --routing-choice MicrosoftRouting
    ```

### Nueva aplicacion Web API

1. Directorio de trabajo
    ```pwsh
    cd labs/class02/Api
    ```
1. Crear Plan de App Service
    ```pwsh
    az appservice plan create -g educacionit-clase02 -n app-plan-educacionit-class02 --sku F1
    ```
1. Crear WebApp en App Service
    ```pwsh
    az webapp create -g educacionit-clase02 -n webapp-api-educacionit -p app-plan-educacionit-class02
    ```
1. Agregar configuraciones para la construccion del sitio .NET durante el despliegue
    ```pwsh
    az webapp config appsettings set -g educacionit-clase02 -n webapp-api-educacionit --settings "SCM_DO_BUILD_DURING_DEPLOYMENT=true"

    az webapp config appsettings list -n webapp-api-educacionit -o table
    ```
1. Despligue de la aplicacion desde el directorio de desarrollo
    ```pwsh
    az webapp up -g educacionit-clase02 -n webapp-api-educacionit -p app-plan-educacionit-class02 -r "dotnet:6"
    ```

### Eliminacion de los laboratorios

1. Eliminacion del grupo de recursos
    ```pwsh
    az group delete -n educacionit-clase02 --no-wait
    ```

[⏪ Ir al inicio](index.md)