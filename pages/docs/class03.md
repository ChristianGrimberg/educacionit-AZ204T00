---
document:
  az204Class: 'Clase 3: Recuperar recursos y metadatos de Azure Storage mediante el SDK de Azure Storage para .NET'
  az204Title: 'Módulo 3: Desarrollar soluciones que utilicen el almacenamiento de blobs'
---

# Clase 3: Recuperar recursos y metadatos de Azure Storage mediante el SDK de Azure Storage para .NET

## Laboratorios

### Grupo de recursos para los laboratorios

1. Crear un nuevo grupo de recursos
    ```pwsh
    az group create -n educacionit-clase03 -l EastUs2
    ```

### Nueva Function App

1. Directorio de trabajo
    ```pwsh
    cd labs/class03
    ```
1. Crear la cuenta de almacenamiento
    ```pwsh
    az storage account create -g educacionit-clase03 -n storageaccountclass03 --sku Standard_LRS --access-tier Hot --min-tls-version TLS1_2 --public-network-access Enabled --routing-choice MicrosoftRouting
    ```
1. Obtener la cadena de conexion a la cuenta de almacenamiento creada
    ```pwsh
    $connectionString=az storage account show-connection-string -n storageaccountclass03 -g educacionit-clase03 --query connectionString -o tsv
    ```
1. Instalar herramienta HTTP Repl para .NET
    ```pwsh
    dotnet tool install -g Microsoft.dotnet-httprepl
    ```
1. Instalar el paquete `Microsoft.Azure.WebJob.Extensions.Storage`
    ```pwsh
    func extensions install --package Microsoft.Azure.WebJobs.Extensions.Storage --version 5.0.1
    ```

### Function Apps desde Azure CLI

1. 
    ```pwsh
    az functionapp create -n clase03-funcion02 -g educacionit-clase03 --storage-account storageaccountclass03 --runtime dotnet --consumption-plan-location EastUs2
    ```

### Eliminacion de los laboratorios

1. Eliminacion del grupo de recursos
    ```pwsh
    az group delete -n educacionit-clase03 --no-wait
    ```
