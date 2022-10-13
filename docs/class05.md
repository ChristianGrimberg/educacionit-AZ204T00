---
title:  "Clase 4"
description: "AZ-204T00 Developing Solutions for Microsoft Azure"
permalink: class04.html
layout: page
---

[⏪ Ir al inicio](index.md)

# Clase 5

## Preparacion del ambiente en Azure

### Variables a utilizar

```pwsh
$resourceGroup="educacionit-clase05"
$storageAccount="cosmosdbclase05"
$images="images"
```

### Grupo de recursos para los laboratorios

1. Crear un nuevo grupo de recursos
    ```pwsh
    az group create -n $resourceGroup -l EastUs2
    ```

### Crear base de datos Azure CosmosDB

1. Crear base de datos Azure CosmosDB NoSQL (CoreSQL API)
    ```pwsh
    ```
1. Directorio de trabajo
    ```pwsh
    cd labs/class05/AdventureWorks/AdventureWorks.Upload/
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
    az storage container create -n $images --connection-string $connectionString --public-access blob
    ```
1. Insertar el paquete de Azure Cosmos
    ```pwsh
     dotnet add package Microsoft.Azure.Cosmos
    ```

## Eliminacion de los recursos en Azure

1. Eliminacion del grupo de recursos
    ```pwsh
    az group delete -n $resourceGroup --no-wait
    ```

[⏪ Ir al inicio](index.md)