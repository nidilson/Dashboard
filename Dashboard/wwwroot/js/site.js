document.addEventListener("DOMContentLoaded", () => {
    let menuButton = document.getElementById("menu");

    menuButton.addEventListener("click", () => {
        openSideMenu(menuButton);
    })
});

/**
 * Función que abre el menú lateral
 * @param {any} menuButton - Botón que abre el menú
 */
function openSideMenu(menuButton) {
    let sidebar = document.getElementById("sidebar");
    let container = document.getElementById("container");
    if (menuButton.classList.contains("active")) {
        menuButton.classList.remove("active");
        sidebar.classList.add("hidden");
        container.classList.add("sidebar-hidden");
    } else {
        menuButton.classList.add("active");
        sidebar.classList.remove("hidden");
        container.classList.remove("sidebar-hidden");
    }
}