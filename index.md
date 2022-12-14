---
title: "Contenido"
permalink: index.html
layout: home
---

{% assign labs = site.pages | where_exp: "page", "page.url contains '/docs'" %}
| Módulo | Laboratorio |
| --- | --- |
{% for activity in labs %}{% if activity.lab.az204Module %}| {{ activity.lab.az204Module }} | [{{ activity.lab.az204Title }}]({{ site.github.url }}{{ activity.url }}) |
{% endif %}{% endfor %}