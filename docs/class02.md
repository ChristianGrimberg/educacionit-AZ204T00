---
title:  "Clase 2"
description: "AZ-204T00 Developing Solutions for Microsoft Azure"
permalink: /class02/
---

[⏪ Ir al inicio](index.md)

# Clase 02

## Laboratorios

1. Crear un nuevo grupo de recursos
    ```pwsh
    az group create -n educacionit-clase02 -l EastUs2
    ```
2. Crear Plan de App Service
    ```pwsh
    az appservice plan create -g educacionit-clase02 -n class02-plan --sku F1
    ```
3. Crear WebApp en App Service
    ```pwsh
    az webapp create -g educacionit-clase02 -n class02-web01 -p class02-plan
    ```
4. Despligue de la aplicacion desde el directorio de desarrollo
    ```pwsh
     az webapp up -g educacionit-clase02 -n class02-web01 -p class02-plan --runtime "dotnet:6"
    ```
5. Eliminacion del grupo de recursos
    ```pwsh
    az group delete -n educacionit-clase02 --no-wait
    ```