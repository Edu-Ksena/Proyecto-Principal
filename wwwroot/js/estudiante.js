// ============================================================
//  SITE.JS — Lógica global del portal estudiantil
//  Colegio Educativo San Luis
// ============================================================

document.addEventListener('DOMContentLoaded', function () {

    // ----------------------------------------------------------
    // CAMBIO DE PESTAÑAS (TABS)
    // Cuando el usuario hace clic en una pestaña, se activa esa
    // pestaña dentro del grupo de pestañas al que pertenece.
    // ----------------------------------------------------------
    document.querySelectorAll('.tab').forEach(function (tab) {
        tab.addEventListener('click', function () {
            // Quitar la clase activa de todas las pestañas del mismo grupo
            this.closest('.tabs').querySelectorAll('.tab').forEach(function (t) {
                t.classList.remove('active');
            });
            // Activar la pestaña que se hizo clic
            this.classList.add('active');
        });
    });


    // ----------------------------------------------------------
    // SIDEBAR EN MOVIL — BOTON HAMBURGUESA
    // En pantallas pequeñas, el sidebar está oculto por defecto.
    // El botón hamburguesa lo muestra u oculta con una transición.
    // El overlay cierra el sidebar al hacer clic fuera de él.
    // ----------------------------------------------------------

    // Elementos involucrados en la navegación móvil
    var sidebar         = document.getElementById('sidebar');
    var overlay         = document.getElementById('sidebar-overlay');
    var btnHamburguesa  = document.getElementById('btn-hamburguesa');

    // Verificar que los elementos existen antes de agregar eventos
    if (sidebar && overlay && btnHamburguesa) {

        /**
         * abrirSidebar — agrega la clase .abierto al sidebar y muestra el overlay.
         * El CSS maneja la transición de transform: translateX(-100%) a translateX(0).
         */
        function abrirSidebar() {
            sidebar.classList.add('abierto');
            overlay.classList.add('activo');
            // Prevenir el scroll del body mientras el sidebar está abierto
            document.body.style.overflow = 'hidden';
        }

        /**
         * cerrarSidebar — quita la clase .abierto y oculta el overlay.
         * El CSS hace la transición de regreso fuera de pantalla.
         */
        function cerrarSidebar() {
            sidebar.classList.remove('abierto');
            overlay.classList.remove('activo');
            // Restaurar el scroll del body
            document.body.style.overflow = '';
        }

        // Clic en el botón hamburguesa: alterna el estado del sidebar
        btnHamburguesa.addEventListener('click', function () {
            if (sidebar.classList.contains('abierto')) {
                cerrarSidebar();
            } else {
                abrirSidebar();
            }
        });

        // Clic en el overlay: cierra el sidebar
        overlay.addEventListener('click', function () {
            cerrarSidebar();
        });

        // Tecla Escape: cierra el sidebar (accesibilidad)
        document.addEventListener('keydown', function (evento) {
            if (evento.key === 'Escape' && sidebar.classList.contains('abierto')) {
                cerrarSidebar();
            }
        });

        // Si se cambia el tamaño de ventana a escritorio, asegurar que el sidebar
        // quede limpio (sin clases de móvil que puedan interferir)
        window.addEventListener('resize', function () {
            if (window.innerWidth > 768) {
                sidebar.classList.remove('abierto');
                overlay.classList.remove('activo');
                document.body.style.overflow = '';
            }
        });
    }

    // ----------------------------------------------------------
    // FECHA HOY DINÁMICA
    // Busca elementos con la clase .js-fecha-hoy y reemplaza su texto
    // por la fecha actual formateada en español colombiano (es-CO).
    // Uso de Date nativo y toLocaleDateString; no se usan librerías.
    // ----------------------------------------------------------
    (function actualizarFechaHoy() {
        const nodos = document.querySelectorAll('.js-fecha-hoy');
        if (!nodos || nodos.length === 0) return;

        const hoy = new Date();
        const opciones = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
        const fechaFormateada = hoy.toLocaleDateString('es-CO', opciones);
        // Capitalizar la primera letra para presentación: "viernes..." → "Viernes..."
        const fechaCapitalizada = fechaFormateada.charAt(0).toUpperCase() + fechaFormateada.slice(1);

        nodos.forEach(el => {
            // Reemplazamos el contenido textual del nodo
            el.textContent = fechaCapitalizada;
        });
    })();

});
