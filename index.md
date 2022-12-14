---
permalink: index.html
layout: home
---

# AZ-204: Desarrollo de soluciones para Microsoft Azure

{% assign classes = site.pages | where_exp: "page", "page.url contains '/pages/docs'" %}
{% assign modules = site.pages | where_exp: "page", "page.url contains '/pages/modules'" %}
| Módulo | Clase |
| ------ | ----- |
{% for activity in classes %}{% if activity.document.az204Module %}| {{ activity.document.az204Module }} | [{{ activity.document.az204Title }}]({{ site.github.url }}{{ activity.url }}) |
{% endif %}{% endfor %}