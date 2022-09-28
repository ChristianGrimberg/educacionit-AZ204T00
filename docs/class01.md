---
title:  "Clase 1"
description: "AZ-204T00 Developing Solutions for Microsoft Azure"
permalink: class01.html
layout: page
---

[⏪ Ir al inicio](index.md)

# Clase 01

## Recursos

* Acceso al material teorico en [Skillpipe](https://www.skillpipe.com/#/bookshelf/books)
* Descarga de laboratorios base desde [Microsoft Learning AZ-204](https://github.com/MicrosoftLearning/AZ-204-DevelopingSolutionsforMicrosoftAzure/archive/refs/heads/master.zip)


## Laboratorios

### Grupo de recursos para los laboratorios de la Clase 01

1. Crear un nuevo grupo de recursos
    ```pwsh
    az group create -n educacionit-clase01 -l EastUs2
    ```

### Nueva aplicacion Web de .NET

1. Directorio de trabajo
    ```pwsh
    cd labs/class01/Web
    ```
1. Crear Plan de App Service
    ```pwsh
    az appservice plan create -g educacionit-clase01 -n app-plan-educacionit-class01 --sku F1
    ```
1. Crear WebApp en App Service
    ```pwsh
    az webapp create -g educacionit-clase01 -n web-app-educacionit -p app-plan-educacionit-class01
    ```
1. Agregar configuraciones para la construccion del sitio .NET durante el despliegue
    ```pwsh
    az webapp config appsettings set -g educacionit-clase01 -n web-app-educacionit --settings SCM_DO_BUILD_DURING_DEPLOYMENT=true

    az webapp config appsettings list -n webapp-api-educacionit -o table
    ```
1. Despligue de la aplicacion desde el directorio de desarrollo
    ```pwsh
    az webapp up -g educacionit-clase01 -n web-app-educacionit -p app-plan-educacionit-class01 -r "dotnet:6"
    ```

### Eliminacion de los laboratorios

1. Eliminacion del grupo de recursos
    ```pwsh
    az group delete -n educacionit-clase01 --no-wait
    ```

[⏪ Ir al inicio](index.md)