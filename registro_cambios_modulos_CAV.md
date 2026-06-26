# Registro de Cambios - Módulos de Calificaciones, Asistencia y Votaciones

Este archivo contiene el historial de cambios, adiciones y modificaciones realizadas en los módulos del portal del profesor y estudiante de la aplicación.

---

## [25 de Junio, 2026] — Módulo de Calificaciones en Rol Administrador (3 Vistas en Flujo)

**Implementado por:** Sistema  
**Fecha y hora:** 25/06/2026 — 17:15 hrs (hora local)  
**Archivos afectados:** 5 modificados/creados  

### ¿Qué se hizo?
Se agregó el módulo de **Calificaciones** al rol de Administrador del sistema. El módulo sigue un flujo de tres vistas encadenadas (Listado → Curso → Estudiante), permitiendo al administrador supervisar y auditar las calificaciones de toda la institución.

### Cambios detallados

#### `Views/Shared/_AdminLayout.cshtml` — MODIFICADO
- Se agregó el ítem **ACADÉMICO** al menú lateral del panel administrador.
- Usa icono SVG de documento con líneas (planilla).
- Se activa (`active`) cuando la acción contiene "Calificacion" y el controlador es `AdminHome`.
- **No se modificó ningún otro ítem existente** del menú (INICIO, ESTUDIANTES, PROFESORES, CURSOS, HORARIOS, VOTACIONES, CONFIGURACION, INICIAR SESIÓN/SALIR).
- Avatares de la barra lateral ya existentes (`AR`, `CE`) permanecen sin cambios.

#### `Controllers/AdminHomeController.cs` — MODIFICADO
- Se agregaron 3 nuevas acciones al controlador:
  - `Calificaciones()` → Vista principal de listado institucional.
  - `CalificacionesCurso(string id)` → Vista de detalle por curso (ej: `11-A`).
  - `CalificacionesEstudiante(string id, string curso)` → Vista de detalle por estudiante.

#### `Views/AdminHome/Calificaciones.cshtml` — CREADO (NUEVO)
- **Vista 1** del flujo de calificaciones del admin.
- Inspirada en la imagen de maqueta: *Gestión de Cursos / Listado Institucional*.
- Incluye:
  - Header con título y botón "Generar Reporte General".
  - Filtros: buscador de texto + select de grado + select de jornada (con JS reactivo).
  - Tabla institucional: Curso · Director de Grupo · Grado · Progreso Notas · Estado · Acción (Auditar).
  - **Avatares de iniciales** de los directores (ej. `CR` = Carlos Alberto Ruiz, `ML` = Marta López, `RJ` = Ricardo Jiménez, `SO` = Sandra Ortiz, `PG` = Patricia Gómez).
  - Barras de progreso de notas con colores: verde (completo), amarillo (en curso), rojo (crítico), azul (finalizando).
  - Badges de estado: Verificado, Pendiente, Retrasado, Finalizando.
  - Panel lateral de reporte con KPIs: Promedio General (4.21), Tasa Aprobación (94.8%), gráfico de barras por grado y registro reciente de cambios.
  - Paginación.

#### `Views/AdminHome/CalificacionesCurso.cshtml` — CREADO (NUEVO)
- **Vista 2** del flujo. Detalle de calificaciones de un curso específico.
- Inspirada en la imagen: *Detalle de Calificaciones - Curso 11-A*.
- Incluye:
  - Breadcrumb: Inicio → Académico → Grado 11 → Calificaciones Curso 11-A.
  - Botones: Regresar (vuelve al listado), Exportar, + Nueva Calificación.
  - 4 KPI cards: Promedio del Curso, Estudiantes Registrados, Calificaciones Pendientes, Rendimiento Grupal.
  - Tabla de estudiantes con **avatares de iniciales** (ej. `AP`, `JL`, `MG`, `DS`, `LV`), nombre, ID, actividad, materia, calificación actual.
  - Botón "Ver Detalles" que navega a la Vista 3.
  - Paginación con info "Mostrando 1-5 de 35 estudiantes".

#### `Views/AdminHome/CalificacionesEstudiante.cshtml` — CREADO (NUEVO)
- **Vista 3** del flujo. Detalle de calificaciones del estudiante seleccionado.
- Inspirada en la imagen: *Detalle de Calificaciones - Ana Pérez*.
- Incluye:
  - Breadcrumb completo: Inicio → Académico → Curso 11-A → Ana Pérez.
  - Botones: ← Regresar (vuelve al curso), ↓ Exportar Boletín.
  - Card de perfil del estudiante con **avatar de iniciales `AP`** (no foto), ID (110293), Grado (11-A), Promedio General (4.2 / Alto).
  - Tarjetas de resumen: Promedio Período, Materias Aprobadas, Pendientes.
  - Tabla de rendimiento por asignatura — Período Actual (Corte 1, Corte 2, Examen, Definitiva).
  - Historial de períodos anteriores (P1 y P2 cerrados).

---

## [25 de Junio, 2026] — Implementación Inicial del Módulo de Calificaciones (Profesor)

**Implementado por:** Sistema  
**Fecha y hora:** 25/06/2026 — approx 15:00 hrs (hora local)

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

## [26 de Junio, 2026] — Módulo de Asistencia (Profesor / Administrador)

**Implementado por:** Sistema  
**Fecha y hora:** 26/06/2026 — approx 15:30 hrs (hora local)

### Módulo de Asistencia
Se agregó el módulo de **Asistencia** para los roles de **Profesor** y **Administrador**, siguiendo la maqueta proporcionada y asegurando la coherencia visual con el resto del sistema (avatares con iniciales, no fotos reales).

#### Rol Profesor
- **Nuevas Acciones (`DashboardController.cs`):** Se agregaron `Asistencia()` y `AsistenciaRegistro(string curso)`.
- **Vista Mis Cursos (`Asistencia.cshtml`):** Permite al profesor seleccionar el curso para registrar la asistencia. Muestra el estado del registro (Completado, Pendiente, En curso).
- **Vista Registro Diario (`AsistenciaRegistro.cshtml`):** Permite tomar asistencia de los estudiantes con toggles de estado (Presente, Excusa, Ausente, Tarde), y visualización de KPIs.

#### Rol Administrador
- **Nuevas Acciones (`AdminHomeController.cs`):** Se agregaron `Asistencia()`, `AsistenciaCurso(string id)` y `AsistenciaEstudiante(string id, string curso)`.
- **Vista Global (`Asistencia.cshtml`):** Panel institucional con tabla general de cursos y porcentaje de asistencia.
- **Vista Detalle Curso (`AsistenciaCurso.cshtml`):** Muestra el listado de estudiantes del curso seleccionado con alertas visuales y progreso.
- **Vista Detalle Estudiante (`AsistenciaEstudiante.cshtml`):** Perfil del estudiante con KPIs y un calendario mensual interactivo mostrando el estado diario de la asistencia.

---

## [Pendiente] — Módulo de Votaciones / Elecciones
*Sección reservada para registrar cambios en el módulo de Votaciones.*

---

## Mapa de Rutas por Módulo y Rol

Esta sección documenta **dónde se encuentran las vistas** de cada módulo según el rol de usuario.

### ROL: ADMINISTRADOR
> **Layout:** `Views/Shared/_AdminLayout.cshtml`  
> **ViewStart:** `Views/AdminHome/_ViewStart.cshtml` → `Layout = "_AdminLayout"`

| Módulo | Acción/Ruta URL | Archivo de Vista |
|--------|----------------|-----------------|
| Inicio / Dashboard | `GET /AdminHome/Index` | `Views/AdminHome/Index.cshtml` |
| Privacidad | `GET /AdminHome/Privacy` | `Views/AdminHome/Privacy.cshtml` |
| **Calificaciones — Listado** | `GET /AdminHome/Calificaciones` | `Views/AdminHome/Calificaciones.cshtml` ✅ NUEVO |
| **Calificaciones — Detalle Curso** | `GET /AdminHome/CalificacionesCurso?id=11-A` | `Views/AdminHome/CalificacionesCurso.cshtml` ✅ NUEVO |
| **Calificaciones — Detalle Estudiante** | `GET /AdminHome/CalificacionesEstudiante?id=110293&curso=11-A` | `Views/AdminHome/CalificacionesEstudiante.cshtml` ✅ NUEVO |
| **Asistencia — Global** | `GET /AdminHome/Asistencia` | `Views/AdminHome/Asistencia.cshtml` ✅ NUEVO |
| **Asistencia — Detalle Curso** | `GET /AdminHome/AsistenciaCurso?id=11A` | `Views/AdminHome/AsistenciaCurso.cshtml` ✅ NUEVO |
| **Asistencia — Detalle Estudiante** | `GET /AdminHome/AsistenciaEstudiante?id=MAT-2023-01&curso=10B` | `Views/AdminHome/AsistenciaEstudiante.cshtml` ✅ NUEVO |
| Gestión de Estudiantes | `GET /Students/Index` | `Views/Students/Index.cshtml` |
| Gestión de Profesores | `GET /Teachers/Index` | `Views/Teachers/Index.cshtml` |
| Gestión de Cursos | `GET /Courses/Index` | `Views/Courses/Index.cshtml` |
| Horarios | `GET /Schedules/Index` | `Views/Schedules/Index.cshtml` |
| Votaciones | `GET /Voting/Index` | `Views/Voting/Index.cshtml` |
| Configuración | `GET /Settings/Index` | `Views/Settings/Index.cshtml` |
| Login / Salir | `GET /Account/Login` | `Views/Account/Login.cshtml` |

---

### ROL: PROFESOR
> **Layout:** `Views/Shared/_DashboardLayout.cshtml`  
> **ViewStart:** `Views/Dashboard/_ViewStart.cshtml` → `Layout = "_DashboardLayout"`

| Módulo | Acción/Ruta URL | Archivo de Vista |
|--------|----------------|-----------------|
| Inicio / Perfil Profesor | `GET /Dashboard/Profesor` | `Views/Dashboard/Profesor.cshtml` |
| Calificaciones (Planilla) | `GET /Dashboard/Calificaciones` | `Views/Dashboard/Calificaciones.cshtml` |
| Mis Cursos | `GET /Dashboard/Cursos` | `Views/Dashboard/Cursos.cshtml` |
| **Asistencia — Mis Cursos** | `GET /Dashboard/Asistencia` | `Views/Dashboard/Asistencia.cshtml` ✅ NUEVO |
| **Asistencia — Registro Diario** | `GET /Dashboard/AsistenciaRegistro?curso=11-A` | `Views/Dashboard/AsistenciaRegistro.cshtml` ✅ NUEVO |
| Mis Estudiantes | `GET /Dashboard/Estudiantes` | `Views/Dashboard/Estudiantes.cshtml` |
| Boletines | `GET /Dashboard/Boletines` | `Views/Dashboard/Boletines.cshtml` |
| Mi Perfil | `GET /Dashboard/Perfil` | `Views/Dashboard/Perfil.cshtml` |
| Panel Admin (prototipo) | `GET /Dashboard/Admin` | `Views/Dashboard/Admin.cshtml` |

---

### ROL: ESTUDIANTE
> **Layout:** `Views/Shared/_StudentLayout.cshtml`  
> **ViewStart:** `Views/StudentHome/_ViewStart.cshtml` (si existe)

| Módulo | Acción/Ruta URL | Archivo de Vista |
|--------|----------------|-----------------|
| Inicio Estudiante | `GET /Dashboard/Estudiante` | `Views/Dashboard/Estudiante.cshtml` |
| Otras vistas de estudiante | `Views/StudentHome/` | `Views/StudentHome/*.cshtml` |

---

### RUTAS GENERALES DEL SISTEMA

| Módulo | Acción/Ruta URL | Archivo de Vista |
|--------|----------------|-----------------|
| Página de inicio (login) | `GET /Home/Index` | `Views/Home/Index.cshtml` |
| Login | `GET /Account/Login` | `Views/Account/Login.cshtml` |
| Horarios (shared) | `GET /Horario/*` | `Views/Horario/*.cshtml` |
| Asistencia (shared) | `GET /Asistencia/*` | `Views/Asistencia/*.cshtml` |
| Elecciones (shared) | `GET /Elecciones/*` | `Views/Elecciones/*.cshtml` |
| Perfil (shared) | `GET /Perfil/*` | `Views/Perfil/*.cshtml` |
| Academico (shared) | `GET /Academico/*` | `Views/Academico/*.cshtml` |
