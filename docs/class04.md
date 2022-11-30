---
title:  "Clase 4"
description: "AZ-204T00 Developing Solutions for Microsoft Azure"
permalink: class04.html
layout: page
---

[⏪ Ir al inicio](index.md)

# Clase 4

## Instrucciones

### Diagrama de arquitectura

![Diagrama](img/Lab03-Diagram.png)

## Preparacion del ambiente en Azure
### Variables a utilizar

```pwsh
$resourceGroup="educacionit-clase04"
$storageAccount="stormediaclase04"
$compressedAudio="compressed-audio"
$rasterGraphics="raster-graphics"
$demoContainer="demo-container"

```

### Grupo de recursos para los laboratorios

1. Crear un nuevo grupo de recursos
    ```pwsh
    az group create -n $resourceGroup -l EastUs2
    ```

## Trabajando con cuentas de almacenamiento

### Nueva cuenta de almacenamiento

1. Directorio de trabajo
    ```pwsh
    cd labs/class04/img
    ```
1. Crear la cuenta de almacenamiento
    ```pwsh
    az storage account create -g $resourceGroup -n $storageAccount --sku Standard_LRS --access-tier Hot --min-tls-version TLS1_2 --public-network-access Enabled --routing-choice MicrosoftRouting --kind StorageV2 --location EastUs2
    ```
1. Obtener la cadena de conexion a la cuenta de almacenamiento creada
    ```pwsh
    $connectionString=az storage account show-connection-string -n $storageAccount -g $resourceGroup --query connectionString -o tsv
    ```
1. Crear los blobs de contenedor con acceso privado
    ```pwsh
    az storage container create -n $compressedAudio --connection-string $connectionString
    az storage container create -n $rasterGraphics --connection-string $connectionString
    az storage container create -n $demoContainer --connection-string $connectionString
    ```
1. Subir imagen de ejemplo al blob del contenedor
    ```pwsh
    az storage blob upload -c $rasterGraphics -f ./graph.jpg -n graph.jpg --connection-string $connectionString
    ```

## Laboratorio de aplicacion de consola

1. Directorio de trabajo
    ```pwsh
    cd labs/class04/BlobManager
    ```
1. Crear la aplicacion de consola si no existe
    ```pwsh
    dotnet new console --framework net6.0 --name BlobManager --output .
    ```
1. Correr la aplicacion
    ```pwsh
    dotnet run
    ```

## Eliminacion de los recursos en Azure

1. Eliminacion del grupo de recursos
    ```pwsh
    az group delete -n $resourceGroup --no-wait
    ```

[⏪ Ir al inicio](index.md)