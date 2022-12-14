---
title: "Contenido"
permalink: index.html
layout: home
---

{% assign classes = site.pages | where_exp: "page", "page.url contains '/docs'" %}
| Módulo | Clase |
| ------ | ----- |
{% for activity in classes %}
{% if activity.lab.az204Module %}
| {{ activity.lab.az204Module }} | [{{ activity.lab.az204Title }}]({{ site.github.url }}{{ activity.url }}) |
{% endif %}
{% endfor %}