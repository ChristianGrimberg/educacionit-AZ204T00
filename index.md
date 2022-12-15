---
permalink: index.html
layout: home
title: 'AZ-204'
---

# AZ-204: Desarrollo de soluciones para Microsoft Azure

## Documentación relacionada del sitio de [Microsoft Docs](https://learn.microsoft.com/es-es/)

* Acceso al material teorico oficial en [Skillpipe](https://www.skillpipe.com/#/bookshelf/books)
{% assign modules = site.pages | where_exp: "page", "page.url contains '/pages/modules'" %}
{% for activity in modules %}{% if activity.document.az204Module %}* [{{ activity.document.az204Module }}]({{ site.github.url }}{{ activity.url }})
{% endif %}{% endfor %}

## Laboratorios efectuados en clase

{% assign classes = site.pages | where_exp: "page", "page.url contains '/pages/docs'" %}
| Módulo | Clase |
| ------ | ----- |
{% for activity in classes %}{% if activity.document.az204Title %}| {{ activity.document.az204Title }} | [{{ activity.document.az204Class }}]({{ site.github.url }}{{ activity.url }}) |
{% endif %}{% endfor %}

### Recursos adicionales

* Descarga de laboratorios base desde [Microsoft Learning AZ-204](https://github.com/MicrosoftLearning/AZ-204-DevelopingSolutionsforMicrosoftAzure.es-es/tree/main/Allfiles)