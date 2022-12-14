---
permalink: index.html
layout: home
---

# AZ-204: Desarrollo de soluciones para Microsoft Azure

## Recursos

* Acceso al material teorico en [Skillpipe](https://www.skillpipe.com/#/bookshelf/books)
* Descarga de laboratorios base desde [Microsoft Learning AZ-204](https://github.com/MicrosoftLearning/AZ-204-DevelopingSolutionsforMicrosoftAzure/archive/refs/heads/master.zip)

## Documentación relacionada

{% assign modules = site.pages | where_exp: "page", "page.url contains '/pages/modules'" %}
{% for activity in modules %}{% if activity.document.az204Module %}* [{{ activity.document.az204Module }}]({{ site.github.url }}{{ activity.url }})
{% endif %}{% endfor %}

## Laboratorios efectuados en clase

{% assign classes = site.pages | where_exp: "page", "page.url contains '/pages/docs'" %}
| Módulo | Clase |
| ------ | ----- |
{% for activity in classes %}{% if activity.document.az204Title %}| {{ activity.document.az204Title }} | [{{ activity.document.az204Class }}]({{ site.github.url }}{{ activity.url }}) |
{% endif %}{% endfor %}