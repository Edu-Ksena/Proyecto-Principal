# Registro de Cambios - Módulos de Calificaciones, Asistencia y Votaciones

Este archivo contiene el historial de cambios, adiciones y modificaciones realizadas en los módulos del portal del profesor y estudiante de la aplicación.

---

## [25 de Junio, 2026] - Implementación Inicial del Módulo de Calificaciones (Profesor)

### Módulo de Calificaciones
- **Controlador (`DashboardController.cs`):** 
  - Se agregó la acción `Calificaciones` para manejar y servir la vista de la planilla de calificaciones del docente.
- **Layout General del Docente (`_DashboardLayout.cshtml`):**
  - Se agregó el botón **Calificaciones** en el menú de navegación de la barra lateral, utilizando el ícono de FontAwesome `<i class="fa-solid fa-graduation-cap"></i>` para mantener consistencia con los demás módulos.
  - Se actualizó el avatar y nombre del profesor a **JP (Juan Pérez)**, corrigiendo el correo a `juan.perez@gmail.com` de acuerdo con los datos presentados en la planilla para lograr concordancia visual.
- **Vista de Calificaciones (`Calificaciones.cshtml`):**
  - Creada en [Views/Dashboard/Calificaciones.cshtml](file:///c:/Users/APRENDIZ/Downloads/Eduk.ña/Proyecto-Principal/Views/Dashboard/Calificaciones.cshtml).
  - Cuenta con un diseño premium y responsivo que reproduce fielmente el diseño de la maqueta:
    - Fila superior de tarjetas de métricas (KPIs): *Curso Seleccionado*, *Promedio Grupal* y *Estudiantes en Riesgo*.
    - Listado de cursos activos a la izquierda (*Matemáticas 11-B*, *Matemáticas 10-A*, *Cálculo 11-A*, *Trigonometría 10-B*).
    - Planilla detallada de notas para el período 3 de 2024 con botones de acción en la parte superior derecha (*Nueva Actividad*, *Guardar Cambios*, *Publicar Notas*).
    - Tabla con datos simulados y avatares de iniciales para los estudiantes (Andres Alvarado, Camilo Bernal, Claudia Daza, Gabriel Estrada, Sofia Franco) con sus respectivas notas.
    - Paginación e información del pie de página.
- **Interactividad (JavaScript):**
  - Se implementó lógica de cálculo reactivo: al modificar cualquiera de las calificaciones (Actividad 1, Actividad 2, Parcial), se recalculan automáticamente el promedio individual (DEF) y el estado (*Aprobado*, *Regular*, *En Riesgo*), variando los colores del texto y el estilo de los badges dinámicamente.
  - Se adaptó la validación para asegurar que los valores introducidos estén estrictamente entre 0.0 y 5.0.
  - Se programó la simulación interactiva al alternar entre diferentes cursos de la lista izquierda, cargando notas distintas para demostrar la funcionalidad y recalculando las métricas globales del curso (promedio grupal y total de estudiantes en riesgo) al vuelo.
- **Perfil de Docente (`Perfil.cshtml`):**
  - Se adaptaron los textos estáticos en la vista de perfil para que muestre el nombre **Juan Pérez** y correo coherentes, manteniendo la armonía de datos en toda la aplicación del profesor.

---

## [Pendiente] - Módulo de Asistencia (Profesor / Estudiante)
*Sección reservada para registrar cambios en el módulo de Asistencia.*

---

## [Pendiente] - Módulo de Votaciones / Elecciones
*Sección reservada para registrar cambios en el módulo de Votaciones.*
