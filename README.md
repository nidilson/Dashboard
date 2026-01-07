
# 📊 Dashboard de Ejemplo — Datos de la NASA, RestCountries y PokeAPI

Este proyecto es un **dashboard de ejemplo** que consume datos desde múltiples APIs públicas para mostrar información de forma visual y dinámica.  
El objetivo es practicar conceptos como:

- Consumo de múltiples APIs REST
- Visualización de datos
- UI con componentes modernos
- Manejo de variables de entorno
- Integración con dashboards

---

## 🚀 Características

✔ Dashboard visual  
✔ Datos en tiempo real desde APIs públicas  
✔ Gráficos interactivos  
✔ Manejo de fechas  
✔ Ideal para pruebas y aprendizaje  

---

## 📦 Tecnologías utilizadas

- HTML / CSS / JavaScript
- Fetch API
- Chart.js (gráficos)
- Flatpickr (fechas)
- API de NASA
- PokeAPI
- RestCountries

---

## 🔑 API Key requerida — **NASA**

Para ejecutar el proyecto correctamente necesitas una **API Key de la NASA**.

### **Cómo obtener la API Key**

1. Ir a: https://api.nasa.gov/
2. Llenar el formulario
3. Recibir la Key en tu correo

### **Agregar la Key como variable de entorno**

Variable requerida:

```
NASA_API_KEY
```

Ejemplo en **Windows (PowerShell):**

```
setx NASA_API_KEY "TU_KEY_AQUI"
```

Ejemplo en **Linux / macOS:**

```
export NASA_API_KEY="TU_KEY_AQUI"
```

⚠️ Nota: la variable debe estar disponible antes de ejecutar el proyecto.

---

## 🌐 APIs utilizadas

| API | Uso | URL |
|---|---|---|
| NASA | Datos astronómicos (asteroides, etc.) | https://api.nasa.gov/ |
| RestCountries | Información de países | https://restcountries.com/ |
| PokeAPI | Datos Pokémon | https://pokeapi.co/ |

---

## ▶️ Cómo ejecutar el proyecto

```
# Clonar el repositorio
git clone https://github.com/usuario/proyecto-dashboard.git

# Entrar al proyecto
cd proyecto-dashboard

# Abrir en navegador / servidor local
```

Recomendado: **VSCode + Live Server**

---

## 📁 Estructura del proyecto

```
/
|-- index.html
|-- /css
|-- /js
|-- /assets
|-- README.md
```

---

## 📝 Notas

- El objetivo es didáctico
- Permite integración con más APIs
- Los estilos se pueden personalizar
- El proyecto sirve para pruebas frontend

---

## 📄 Licencia

MIT — Libre para aprendizaje y uso personal.
