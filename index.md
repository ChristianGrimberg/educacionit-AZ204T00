---
permalink: index.html
layout: home
---

# AZ-204: Desarrollo de soluciones para Microsoft Azure

{% assign classes = site.pages | where_exp: "page", "page.url contains '/pages/docs'" %}
| Módulo | Clase |
| ------ | ----- |
{% for activity in classes %}{% if activity.lab.az204Module %}| {{ activity.lab.az204Module }} | [{{ activity.lab.az204Title }}]({{ site.github.url }}{{ activity.url }}) |
{% endif %}{% endfor %}