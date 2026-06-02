// ==========================================================================
// EDUK PORTAL JAVASCRIPT
// Micro-interactions, Modals and Password Toggles
// ==========================================================================

document.addEventListener("DOMContentLoaded", function () {
    console.log("EDUK Portal ready.");
    
    // Auto-desvanecer alertas de éxito después de 4 segundos
    const alerts = document.querySelectorAll(".alert");
    alerts.forEach(function (alert) {
        setTimeout(function () {
            alert.style.transition = "opacity 0.5s ease";
            alert.style.opacity = "0";
            setTimeout(function () {
                alert.remove();
            }, 500);
        }, 4000);
    });
});

// --- GESTIÓN DE VENTANAS MODALES GENERALES ---

// Abrir modal de añadir
function openAddModal() {
    const modal = document.getElementById("addModal");
    if (modal) {
        modal.classList.remove("hidden");
        // Enfocar primer input del modal
        const firstInput = modal.querySelector("input");
        if (firstInput) firstInput.focus();
    }
}

// Cerrar modal de añadir
function closeAddModal() {
    const modal = document.getElementById("addModal");
    if (modal) {
        modal.classList.add("hidden");
    }
}

// Cerrar modal de editar
function closeEditModal() {
    const modal = document.getElementById("editModal");
    if (modal) {
        modal.classList.add("hidden");
    }
}

// Cerrar modal de eliminar
function closeDeleteModal() {
    const modal = document.getElementById("deleteModal");
    if (modal) {
        modal.classList.add("hidden");
    }
}

// --- CONFIGURACIÓN DE MODALES ESPECÍFICOS ---

// Modal Editar Profesor
function openEditTeacherModal(id, name, subject, phone) {
    document.getElementById("editId").value = id;
    document.getElementById("editName").value = name;
    document.getElementById("editSubject").value = subject;
    document.getElementById("editPhone").value = phone;
    
    const modal = document.getElementById("editModal");
    if (modal) {
        modal.classList.remove("hidden");
    }
}

// Modal Editar Estudiante
function openEditStudentModal(id, name, grade, email, status) {
    document.getElementById("editId").value = id;
    document.getElementById("editName").value = name;
    document.getElementById("editGrade").value = grade;
    document.getElementById("editEmail").value = email;
    
    const statusSelect = document.getElementById("editStatus");
    if (statusSelect) {
        statusSelect.value = status;
    }
    
    const modal = document.getElementById("editModal");
    if (modal) {
        modal.classList.remove("hidden");
    }
}

// Modal Editar Curso
function openEditCourseModal(id, name, teacherId, studentsCount) {
    document.getElementById("editId").value = id;
    document.getElementById("editName").value = name;
    document.getElementById("editTeacher").value = teacherId;
    document.getElementById("editStudentsCount").value = studentsCount;
    
    const modal = document.getElementById("editModal");
    if (modal) {
        modal.classList.remove("hidden");
    }
}

// Modal Eliminar (Común para profesores, estudiantes y cursos)
function openDeleteModal(id, targetName) {
    document.getElementById("deleteId").value = id;
    const targetSpan = document.getElementById("deleteTargetName");
    if (targetSpan) {
        targetSpan.textContent = targetName;
    }
    
    const modal = document.getElementById("deleteModal");
    if (modal) {
        modal.classList.remove("hidden");
    }
}

// Cerrar modales si se hace clic fuera del modal-card
window.onclick = function (event) {
    if (event.target.classList.contains("modal-backdrop")) {
        event.target.classList.add("hidden");
    }
};

// --- VISIBILIDAD DE CONTRASEÑAS ---

function togglePasswordVisibility(inputId) {
    const input = document.getElementById(inputId);
    if (!input) return;
    
    const type = input.getAttribute("type") === "password" ? "text" : "password";
    input.setAttribute("type", type);
    
    // Cambiar opacidad del icono del botón correspondiente para dar retroalimentación visual
    const button = input.nextElementSibling;
    if (button && button.classList.contains("toggle-password-btn")) {
        const svg = button.querySelector("svg");
        if (svg) {
            if (type === "text") {
                svg.style.color = "#0077F6"; // Resaltar azul cuando sea visible
            } else {
                svg.style.color = ""; // Volver al color por defecto
            }
        }
    }
}

// --- GESTIÓN DE VOTACIONES Y MENÚ MÓVIL ---

function openModal(modalId) {
    const modal = document.getElementById(modalId);
    if (modal) {
        modal.classList.remove("hidden");
    }
}

function closeModal(modalId) {
    const modal = document.getElementById(modalId);
    if (modal) {
        modal.classList.add("hidden");
    }
}

function openAddCandidateModal(eventId, eventTitle) {
    document.getElementById("VotingEventId").value = eventId;
    document.getElementById("candidateModalEventTitle").textContent = "Evento: " + eventTitle;
    openModal("addCandidateModal");
}

document.addEventListener("DOMContentLoaded", function () {
    const mobileMenuBtn = document.getElementById("mobile-menu-btn");
    const sidebar = document.querySelector(".sidebar");
    
    if (mobileMenuBtn && sidebar) {
        mobileMenuBtn.addEventListener("click", function(e) {
            e.stopPropagation();
            sidebar.classList.toggle("sidebar-open");
        });
        
        // Cerrar sidebar al hacer clic fuera
        document.addEventListener("click", function(e) {
            if (window.innerWidth <= 768 && sidebar.classList.contains("sidebar-open")) {
                if (!sidebar.contains(e.target) && e.target !== mobileMenuBtn) {
                    sidebar.classList.remove("sidebar-open");
                }
            }
        });
    }
});
