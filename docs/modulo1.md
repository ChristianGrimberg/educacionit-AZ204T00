---
title:  "Modulo 1"
description: "AZ-204T00 Developing Solutions for Microsoft Azure"
permalink: modulo01.html
layout: theme
---

[⏪ Ir al inicio](index.md)

# Explorar Azure App Service
## Examinar Azure App Service

Azure App Service es un servicio basado en HTTP para hospedar aplicaciones web, API de REST y back-ends para dispositivos móviles. Puede desarrollarlo en su lenguaje de programación preferido, ya sea. NET, .NET Core, Java, Ruby, Node.js, PHP o Python. Las aplicaciones se ejecutan y escalan fácilmente en los entornos Windows y Linux.

### Compatibilidad integrada con el escalado automático

En Azure App Service se integra la capacidad de escalar o reducir verticalmente, o bien escalar o reducir horizontalmente. En función del uso de la aplicación web se puede escalar o reducir verticalmente los recursos de la máquina subyacente en la que se hospeda la aplicación web. Los recursos incluyen el número de núcleos o la cantidad de memoria RAM disponible. El escalado o la reducción horizontal es la capacidad de aumentar o disminuir el número de instancias de máquina que ejecutan la aplicación web.

### Compatibilidad con la integración e implementación continuas

Azure Portal proporciona integración e implementación continuas listas para usar con Azure DevOps, GitHub, Bitbucket, FTP o un repositorio de GIT local en el equipo de desarrollo. Conecte su aplicación web con cualquiera de los orígenes anteriores y App Service se encargará del resto mediante la sincronización automática del código y los futuros cambios en el código en la aplicación web.

### Ranuras de implementación

Al implementar la aplicación web, la aplicación web en Linux, el back-end móvil o la aplicación API en Azure App Service, puede implementarlas en una ranura de implementación independiente en lugar de en la ranura de producción predeterminada si realiza la ejecución en el nivel de plan Estándar, Premium o Aislado de App Service. Las ranuras de implementación son aplicaciones activas con sus propios nombres de host. Los elementos de contenido y configuraciones de aplicaciones se pueden intercambiar entre dos ranuras de implementación, incluida la ranura de producción.

### App Service en Linux

App Service también puede hospedar las aplicaciones Web de forma nativa en Linux para las pilas de aplicaciones admitidas. Además, puede ejecutar contenedores de Linux personalizados (también conocidos como Web App for Containers). App Service en Linux admite varias imágenes integradas específicas del lenguaje. Solo implemente el código. Los lenguajes compatibles incluyen: Node.js, Java (JRE 8 y JRE 11), PHP, Python, .NET Core y Ruby. Si el motor de tiempo de ejecución que requiere la aplicación no se admite en las imágenes integradas, puede implementarlo con un contenedor personalizado.

Los idiomas y sus versiones admitidas se actualizan de forma periódica. Puede recuperar la lista actual mediante el comando siguiente en Cloud Shell.

```bash
az webapp list-runtimes --os-type linux
```

#### Limitaciones

App Service en Linux tiene algunas limitaciones:

* App Service en Linux no se admite en el plan de tarifa Compartido.
* No se pueden mezclar las aplicaciones Windows y Linux en el mismo plan de App Service.
* Históricamente, no se podían mezclar aplicaciones de Windows y Linux en el mismo grupo de recursos. Sin embargo, todos los grupos de recursos creados a partir del 21 de enero de 2021 admiten este escenario. La compatibilidad con los grupos de recursos creados antes del 21 de enero de 2021 se implementará en breve en las regiones de Azure (incluidas las regiones de nube nacional).
* Azure Portal solo muestra las características que funcionan actualmente para las aplicaciones Linux. A medida que se habiliten las características, se activarán en el portal.

[⏪ Ir al inicio](index.md)