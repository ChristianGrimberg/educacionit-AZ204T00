---
title:  "Modulo 1"
description: "AZ-204T00 Developing Solutions for Microsoft Azure"
permalink: /modulo1/
---

[⏪ Ir al inicio](index.md)

# Explorar Azure App Service
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

### App Service en Linux

App Service tambien puede alojar aplicaciones nativas en Linux para las pilas de aplicaciones sopportadas. Tambien se puede correr contenedores de Linux particulares (_tambien conocido como Web App para Contenedores_). App Service en Linux soporta un numero especifico de imagenes preestablecidas, que permiten enfocarse unicamente en el despliegue del codigo. Los lenguajes soportados incluidos son:

* Node.js
* Java (JRE 8 & JRE 11)
* PHP
* Python
* .NET Core
* Ruby

Si el lenguaje de la aplicacion no es soportado por las imagenes preestablecidas, se puede desplegar con una imagen particular.

Los lenguajes y las versiones soportadas se actualizan periodicamente. Se puede obtener la lista actual utilizando el siguiente comando de Azure CLI:

```pwsh
az webapp list-runtimes --linux
```

#### Limitaciones

App Service en Linux tiene las siguientes limitaciones:

* App Service en Liux no es soportado en los niveles de planes __Shared__.
* No se pueden mezclar aplicaciones de Windows y Linux en el mismo plan de App Service.
* Historicamente, no se podia mezclar aplicaciones de Windows y Linux en el mismo Grupo de Recursos. Sin embargo, todos los Grupos de Recursos creados luego del 21 de enero de 2021 ya soportan este escenario. El soporte a los Grupos de Recursos creados previamente, se estan aplicando progresivamente en las diferentes regiones de Azure.
* El portal de Azure muestra unicamente las caracteristicas que funcionan actualmente con las aplicaciones de Linux. A medida que las caracteristicas estan habilitadas, se van reportando en el portal de Azure.

## Examinar planes de Azure App Service

En App Service una aplicacion siempre funciona sobre un _Plan de Azure App Service_. Un plan de App Service define un conjunto de recursos de computo para que corra la aplicacion. Una o mas aplicaciones pueden ser configuradas para ejecutarse en los mismos recursos de computo (_o mejor dicho, en el mismo plan de App Service_). Ademas, _Azure Functions_ tambien tiene la opcion de correr en un plan de App Service.

Cuando se crea un plan de App Service en una cierta region (por ejemplo, en el oeste de europa), un conjunto de recursos de computo es creado para ese plan en esa region. Cualquier aplicacion que se coloque dentro de ese plan de App Service va a correr con esos mismos recursos que se definieron en el plan. En cada plan de App Service se define:

* Region
* Numero de instancias de Maquinas Virtuales
* Tamaño de las instancias de VM:
    * _Small_
    * _Medium_
    * _Large_
* Nivel de Precios (_Pricing tier_):
    * _Free_
    * _Shared_
    * _Basic_
    * _Standard_
    * _Premium_
    * _PremiumV2_
    * _PremiumV3_
    * _Isolated_

El nivel de precios de un plan de App Service determina que caracteristicas se pueden obtener cuanto se debe abonar por el plan. Hay varias categorias de niveles de precios:

* __Shared compute:__ Tanto __Free__ como __Shared__ comparten el grupo de los recursos de las aplicaciones conlas aplicaciones de otros clientes. Estos niveles asignar cuotas de CPU para cada aplicacion que se ejecuta en los recursos compartidos, y los recursos no pueden escalar de forma horizontal.
* __Dedicated compute:__ Los niveles __Basic__, __Standard__, __Premium__, __PremiumV2__ y __PremiumV3__ ejecutan aplicaciones en maquinas virtuales dedicadas. Solo las aplicaciones que estan dentro del mismo plan de App Service pueden compartir los mismos recursos de computo. Cuanto mas alto sea el nivel, más instancias de maquinas virtuales estarán disponibles para el escalado horizontal.
* __Isolated:__ Este nivel ejecuta maquinas virtuales dedicadas en redes dedicadas de _Azure Virtual Network_. Este nivel proporciona aislamiento de red además del aislamiento de computo para las aplicaciones. Tambien provee el maximo de las capacidades de escalamiento horizontal.
* __Consumption:__ Este nivel esta disponible unicamente para aplicaciones de tipo funcion. Este nivel escala las funciones dinamicamente dependiendo de la carga de trabajo.

> __Nota:__ Los planes de alojamiento __Free__ y __Shared__ de App Service son niveles básicos que se ejecutan en las mismas máquinas virtuales de Azure como otras aplicaciones de App Service. Algunas aplicaciones podrian pertenecer a otros clientes. Estos niveles tienen la intencion de ser usadas unicamente para proposito de desarrollo o para pruebas.

### Como se ejecutan y escalan las aplicaciones

En los niveles __Free__ y __Shared__ una aplicacion recibe minutos de CPU en una instancia de maquina virtual compartida y no se puede escalar horizontalmente. En otros niveles, una aplicacion se ejecuta y escalada de la siguiente forma:

* Una aplicacion se ejecuta en todas las instancias de maquina virtual configurada en el plan de App Service.
* Si varias aplicaciones estan en el mismo plan de App Service, todas ellas comparten las mismas instancias de maquina virtual.
* Si se tiene varias ranuras de implementacion en una aplicacion, cada ranura se ejecuta inclusive en las mismas instancias de maquina virtual.
* Si estan habilitados los registros de diagnostico (_diagnostic logs_), la ejecucion de copias de seguridad o la ejecucion de WebJobs, todos ellos utilizan los ciclos de CPU y la memoria de las propias maquinas virtuales.

De esta manera, el plan de App Service es la __Unidad de Escalado__ (_Scale Unit_) de las aplicaciones de App Service. Si el plan es configurado para ejecutar cinco instancias de maquina virtual, entonces todas las aplicacion dentro del plan se ejecutan en las mismas cinco instancias. Si el plan es configurado para autoescalado, entonces todas las aplicaciones en el plan son escaladas en conjunto segun las configuraciones de autoescalado.

[⏪ Ir al inicio](index.md)