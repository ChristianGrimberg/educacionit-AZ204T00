---
document:
  az204Class: 'Clase 2: Compilación de una aplicación web con la oferta de Plataforma como Servicio de Azure'
  az204Title: 'Módulo 1: Crear aplicaciones web con Azure App Service'
---

# Clase 2: Compilación de una aplicación web con la oferta de Plataforma como Servicio de Azure

## Diagrama de arquitectura

![Diagrama de arquitectura que muestra un usuario que compila una aplicación web en la oferta de Azure con Plataforma como Servicio](../img/Lab01-Diagram.png)

## Creación del ambiente para el laboratorio

1. Autenticación con Azure CLI
    ```pwsh
    az login
    ```
1. Variables a utilizar

    ```pwsh
    $resourceGroup="educacionit-clase02"
    $storageAccount="storageeducacionitclass02"
    $appPlan="app-plan-educacionit-class02"
    $webAPI="webapp-api-educacionit"
    $webApp="webapp-api-sync-educacionit"
    $keyVault="kv-clase02"
    ```
1. Crear un nuevo grupo de recursos
    ```pwsh
    az group create -n $resourceGroup -l EastUs2

    az group list -o table
    ```

## Creación de una Cuenta de Almacenamiento

1. Directorio de trabajo
    ```pwsh
    cd labs/class02/img
    ```
1. Crear la cuenta de almacenamiento
    ```pwsh
    az storage account create -g $resourceGroup -n $storageAccount --sku Standard_LRS --access-tier Hot --min-tls-version TLS1_2 --public-network-access Enabled --routing-choice MicrosoftRouting
    ```
1. Obtener la cadena de conexion a la cuenta de almacenamiento creada
    ```pwsh
    $connectionString=az storage account show-connection-string -n $storageAccount -g $resourceGroup --query connectionString -o tsv
    ```
1. Crear el blob de contenedor de imagenes con acceso publico
    ```pwsh
    az storage container create -n images --public-access blob --connection-string $connectionString
    ```
1. Subir imagen de ejemplo al blob del contenedor
    ```pwsh
    az storage blob upload -c images -f ./sub.jpg -n sub.jpg --connection-string $connectionString

    az storage blob upload -c images -f ./blt.jpg -n blt.jpg --connection-string $connectionString
    ```

## Aplicacion WebAPI de .NET de demostración

1. Directorio de trabajo
    ```pwsh
    mkdir labs/class02/Api

    cd labs/class02/Api
    ```
1. Copiar recursos de demostración desde `Allfiles\Labs\01\Starter\API` a `labs/class02/Api`.
1. Crear Plan de App Service
    ```pwsh
    az appservice plan create -g $resourceGroup -n $appPlan --sku F1
    ```
1. Crear WebApp en App Service
    ```pwsh
    az webapp create -g $resourceGroup -n $webAPI -p $appPlan -r "dotnet:6"
    ```
1. Agregar configuraciones para la construccion del sitio .NET durante el despliegue
    ```pwsh
    az webapp config appsettings set -g $resourceGroup -n $webAPI --settings SCM_DO_BUILD_DURING_DEPLOYMENT=true

    az webapp config appsettings set -g $resourceGroup -n $webAPI --settings StorageConnectionString=$connectionString
    ```
1. Despligue de la aplicacion desde el directorio de desarrollo
    ```pwsh
    az webapp up -g $resourceGroup -n $webAPI -p $appPlan -r "dotnet:6"
    ```

## Aplicacion Web de .NET de demostración

1. Directorio de trabajo
    ```pwsh
    cd labs/class02/Web
    ```
1. Crear WebApp en App Service
    ```pwsh
    az webapp create -g $resourceGroup -n $webApp -p $appPlan -r "dotnet:6"
    ```
1. Agregar configuraciones para la construccion del sitio .NET durante el despliegue
    ```pwsh
    az webapp config appsettings set -g $resourceGroup -n $webApp --settings SCM_DO_BUILD_DURING_DEPLOYMENT=true

    az webapp config appsettings set -g $resourceGroup -n $webApp --settings ApiUrl=https://$webAPI.azurewebsites.net/
    ```
1. Despligue de la aplicacion desde el directorio de desarrollo
    ```pwsh
    az webapp up -g $resourceGroup -n $webApp -p $appPlan -r "dotnet:6"
    ```

## Azure Key Vault para la administracion de configuracion segura

1. Creacion del Key Vault
    ```pwsh
    az keyvault create -g $resourceGroup -n $keyVault -l EastUs2 --sku Standard --retention-days 90 --enable-rbac-authorization false --public-network-access Enabled
    ```
1. Crear un secreto para la cadena de conexion de la cuenta de almacenamiento
    ```pwsh
    az keyvault secret set -n StorageAccount --vault-name $keyVault --value $connectionString
    ```
1. Crear un secreto para la URL del Web API
    ```pwsh
    az keyvault secret set -n BackendUrl --vault-name $keyVault --value https://$webAPI.azurewebsites.net/
    ```
1. Habilitar la asignacion de permisos de identidad hacia ambos sitios
    ```pwsh
    az webapp identity assign -g $resourceGroup -n $webAPI

    az webapp identity assign -g $resourceGroup -n $webApp
    ```
1. Obtener el ID de la aplicacion Web API
    ```pwsh
    $apiPrincipalId=az webapp identity show -n $webAPI -g $resourceGroup --query "principalId" -o tsv
    ```
1. Obtener el ID de la aplicacion Web
    ```pwsh
    $systemPrincipalId=az webapp identity show -n $webApp -g $resourceGroup --query "principalId" -o tsv
    ```
1. Configurar el acceso a los secretos segun cada la aplicacion
    ```pwsh
    az keyvault set-policy -n $keyVault --secret-permissions get list --object-id $apiPrincipalId

    az keyvault set-policy -n $keyVault --secret-permissions get list --object-id $systemPrincipalId
    ```
1. Modificar el valor de la configuracion del Web API
    ```pwsh
    az webapp config appsettings set -g $resourceGroup -n $webAPI --settings "StorageConnectionString=@Microsoft.KeyVault(SecretUri=https://$keyVault.vault.azure.net/secrets/StorageAccount)"
    ```
1. Modificar el valor de la configuracion del sitio Web conectado a Web API
    ```pwsh
    az webapp config appsettings set -g $resourceGroup -n $webApp --settings "ApiUrl=@Microsoft.KeyVault(SecretUri=https://$keyVault.vault.azure.net/secrets/BackendUrl)"
    ```

## Eliminacion del ambiente del laboratorio

1. Eliminacion del grupo de recursos
    ```pwsh
    az group delete -n $resourceGroup --no-wait
    ```
