// loadNav.js
document.addEventListener('DOMContentLoaded', function() {
    fetch('Nav.html')
        .then(response => response.text())
        .then(data => {
            document.getElementById('nav-placeholder').innerHTML = data;
        })
        .catch(error => console.error('Error loading nav:', error));
    
    // Cargar productos después de cargar el nav
    cargarProductos();
});