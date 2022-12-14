---
title: "Contenido"
permalink: index.html
layout: home
---

# Modulos

* [Modulo 1: Explorar Azure App Service](module01.md)

# Clases

* [Clase 1](class01.md)
* [Clase 2](class02.md)
* [Clase 3](class03.md)
* [Clase 4](class04.md)
* [Clase 5](class05.md)
* [Clase 7](class07.md)
* [Clase 12](class12.md)

{% assign labs = site.pages | where_exp: "page", "page.url contains '/'" %}
| Módulo | Laboratorio |
| --- | --- |
{% for activity in labs %}{% if activity.lab.az204Module %}| {{ activity.lab.az204Module }} | [{{ activity.lab.az204Title }}]({{ site.github.url }}{{ activity.url }}) |
{% endif %}{% endfor %}