# 🧩 Freelance 2025 — CODE: AC *(Small Toys)*

**Freelance 2025 — CODE: AC**, también conocido como **Small Toys**, es un **prototipo de videojuego técnico** desarrollado como **encargo freelance** bajo un **plazo muy corto (2 días)**.  
El objetivo fue crear una **experiencia jugable tipo “survival arena”**, con una **vista isométrica**, **cambio dinámico de armas**, y **oleadas de enemigos** que desafían la resistencia del jugador.

---

## 💼 Contexto del Proyecto

El proyecto fue desarrollado en **Unity** como un **encargo freelance**, buscando ofrecer un sistema de combate funcional con **énfasis en el gameplay y optimización**.  
Se combinaron **assets de Mixamo** para animaciones, modelos personalizados en **Blender**, y **efectos de sonido originales** diseñados específicamente para cada arma y evento del juego.

Además, se integró un **avión atacante** que sobrevuela el campo y lanza **proyectiles explosivos** que afectan tanto a enemigos como al jugador, añadiendo **dinamismo y peligro constante** a la escena.

<div align="left">
  <img src="https://github.com/MiltonCastro93/Freelance-2025-CODE-AC/blob/main/Captura01.webp" width="350" alt="Captura del proyecto CODE:AC"/>
</div>

---

## ⚙️ Detalles Técnicos

| Aspecto | Descripción |
|----------|-------------|
| 🧩 **Motor** | Unity 2022 |
| 💻 **Lenguaje** | C# |
| 🧠 **Tipo de Proyecto** | Freelance / Prototipo técnico |
| 🎮 **Perspectiva** | Isométrica (Top-Down) |
| 🔫 **Género base** | Shooter / Survival |
| 🔉 **Audio** | Sonidos producidos y editados manualmente |
| 🧱 **Estado** | Prototipo funcional |

---

## 🧠 Lógica Implementada

El proyecto se enfocó en la **implementación de sistemas técnicos eficientes** y en la **optimización del rendimiento**.  
Entre las características principales se incluyen:

- 🔫 **Sistema de cambio de armas con interfaces**, permitiendo alternar entre:
  - **Pistola:** alta cadencia, bajo daño.  
  - **Escopeta:** corto alcance, daño alto.  
  - **RPG:** lento, pero con daño explosivo en área.
- 🧩 **Cada arma** cuenta con valores personalizados de **cadencia, munición y daño**, controlados por **interfaces reutilizables**.
- 🧨 **Sistema de “Object Pooling”** para gestionar proyectiles y evitar el abuso de `Instantiate`, mejorando la **eficiencia de memoria** durante las oleadas.
- ✈️ **Aeronave enemiga dinámica**, que lanza proyectiles aleatorios sobre el mapa, causando daño en un **radio de impacto** que afecta tanto a enemigos como al jugador.
- 🤖 **Enemigos animados con Mixamo**, con comportamiento básico de persecución y ataque cuerpo a cuerpo.
- 👤 **Personaje principal** animado con Mixamo, controlado mediante inputs de movimiento y rotación isométrica.
- 🔊 **Efectos de sonido** creados desde cero a partir de fragmentos mezclados y procesados por el desarrollador.
- 💥 **Proyectil modelado en Blender**, con animaciones de impacto y destrucción visual coherentes con el estilo del juego.

---

## 🎨 Estilo Visual y HUD

El juego adopta un **estilo low poly** con una **vista isométrica clara**, combinando simplicidad visual con legibilidad durante el combate.  
El **HUD** presenta un diseño **limpio y funcional**, mostrando:
- Contador de munición.  
- Indicador de arma activa.  
- Efectos visuales de daño y recarga.

Los colores y materiales transmiten una **sensación de “juguetes en guerra”**, reforzando la identidad de *Small Toys*.

---

## 🎬 Captura del Proyecto

<div align="center">
  <img src="https://github.com/MiltonCastro93/Freelance-2025-CODE-AC/blob/main/Captura02.webp" width="350" alt="Captura del proyecto Small Toys"/>
</div>

---

## 📄 Estado y Créditos

| Detalle | Información |
|----------|-------------|
| 📅 **Año** | 2025 |
| 💼 **Origen** | Encargo freelance |
| 🧾 **Duración de desarrollo** | 2 días |
| 🎨 **Modelos / UI** | Modelado en Blender y edición en Krita |
| 🔊 **Audio** | Producido y editado por el desarrollador |
| 👨‍💻 **Desarrollador** | Milton Castro |
| 🔓 **Autorización** | Proyecto publicado con fines demostrativos |

---

> 💬 *“Freelance-2025-CODE-AC (Small Toys)” es una demostración de diseño técnico y creatividad bajo presión, combinando optimización, sistemas modulares y una jugabilidad dinámica con recursos limitados.*
