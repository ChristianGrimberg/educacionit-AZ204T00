---
title:  "AZ-204T00 Developing Solutions for Microsoft Azure"
permalink: /modulo1/
---

[<- Atras](index.md)

# Modulo 1: Explorar Azure App Service
## Examinar Azure App Service

Azure App Service es un servicio basado en HTTP para alojar aplicaciones de tipo:

* Web
* REST API
* Moviles de tipo back-end

Se puede utilizar los siguientes lenguajes:

* .NET
* Java
* Ruby
* Node.js
* PHP
* Python

Las aplicaciones pueden correr y escalar con facilidad tanto en entornos Windows y Linux.

### Soporte de auto-escalado

Azure App Service tiene la habilidad de escalar de forma vertical u horizontalmente. Dependiendo del uso de la aplicacion se pueden escalar de forma vertical los recursos de cantidad de nucleos y cantidad de memoria RAM sobre la maquina que corre de fondo y que aloja la misma. El escalado horizontal refiere a la habilidad para incrementar o decrecer la cantidad de instancias de maquinas virtuales en simultaneo corriendo para la aplicacion.

### Soporte de Integracion Continua/Despliegue Continuo

El portal de Azure provee soporte integrado de Integracion Continua/Despliegue Continuo con Azure DevOps, GitHub, Bitbucket, FTP o desde un repositorio local desde la maquina de desarrollo. La conexion de la aplicacion web desde cualquiera de estos origenes implica que Azure App Service se encargue del resto, sincronizando los cambios actuales en el codigo y cualquier otro a futuro.

### Ranuras de Implementacion (_Deployment slots_)

Ya sea usando el portal de Azure como las herramientas de linea de comandos, se puede agregar facilmente ranuras de implementacion a una aplicacion de Azure App Service. Por cada instancia, se puede crear una ranura de despliegue de ensayos (_staging deployment slot_) para subir los cambios a testear en Azure. Cuando el codigo esta correcto, se puede intercambiar facilmente la ranura de ensayos con la ranura de produccion. Esto se puede hacer con unos simples click desde el portal de Azure.

> __Nota:__ Las ranuras de implementacion estan disponibles unicamente en los niveles de planes __Standard__ y __Premium__.