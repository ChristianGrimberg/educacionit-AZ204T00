---
title:  "Clase 12"
description: "AZ-204T00 Developing Solutions for Microsoft Azure"
permalink: class12.html
layout: page
---

[⏪ Ir al inicio](index.md)

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
1. Crear proyecto de .NET
    ```pwsh
    dotnet new webapi --name HelloApi --framework net6.0
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