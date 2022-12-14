---
title:  "Clase 7"
description: "AZ-204T00 Developing Solutions for Microsoft Azure"
permalink: class07.html
layout: page
---

[⏪ Ir al inicio](index.md)

# Clase 7

```pwsh
cd labs/class07/

dotnet new mvc --auth SingleOrg --client-id b85eb39c-e04a-4ed3-a3e2-0a7837128e48 --tenant-id 1cb49f17-0991-4515-b41a-4e348974f587 --domain estebancalabriagmail.onmicrosoft.com --name AwesomeAppChristianGrimberg

az webapp config appsettings set -g Az204ChristianGrimberg -n AwesomeAppChristianGrimberg --settings SCM_DO_BUILD_DURING_DEPLOYMENT=true

az webapp up -g Az204ChristianGrimberg -n AwesomeAppChristianGrimberg -p AppServicePlanChristianGrimnberg -r "dotnet:6"

az group delete -n Az204ChristianGrimberg --no-wait
```