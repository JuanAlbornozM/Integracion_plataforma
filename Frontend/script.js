document.addEventListener("DOMContentLoaded", function() {
    // Carrusel
    let currentIndex = 0;
    const slides = document.querySelectorAll(".carousel-slide");

    function showSlide(index) {
        const totalSlides = slides.length;
        slides.forEach((slide, i) => {
            slide.style.transform = `translateX(${100 * (i - index)}%)`;
        });
    }

    function nextSlide() {
        currentIndex = (currentIndex + 1) % slides.length;
        showSlide(currentIndex);
    }

    setInterval(nextSlide, 3000);
    showSlide(currentIndex);

    // Función para obtener y mostrar productos
    function cargarProductos() {
        fetch('https://api.ejemplo.com/productos')
            .then(response => response.json())
            .then(data => {
                const productosContainer = document.getElementById('productos-container');
                productosContainer.innerHTML = '';
                data.forEach(producto => {
                    const productoElement = document.createElement('div');
                    productoElement.className = 'producto';
                    productoElement.innerHTML = `
                        <img src="${producto.imagen}" alt="${producto.nombre}">
                        <h3>${producto.nombre}</h3>
                        <p>${producto.descripcion}</p>
                        <p>Precio: ${producto.precio}</p>
                    `;
                    productosContainer.appendChild(productoElement);
                });
            });
    }

    // Función para manejar el login
    document.getElementById('login-form').addEventListener('submit', function(event) {
        event.preventDefault();
        const email = document.getElementById('login-email').value;
        const password = document.getElementById('login-password').value;
        
        fetch('http://localhost:5142/api/login/byCredentials', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ 
                "Email":email, 
                "Password":password 
            })
        })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            if (data.status == 404 || data.status == 400) {
              alert("Usuario o contraseña incorrectos");
            } else {
              console.log("token", data.token);
              alert("Login exitoso")
            }
          })
        .catch(() => {
            alert('Error en login');
        });
    });

    // Función para manejar el registro
    document.getElementById('registro-form').addEventListener('submit', function(event) {
        event.preventDefault();
        const nombre = document.getElementById('registro-nombre').value;
        const apellido = document.getElementById('registro-apellido').value;
        const email = document.getElementById('registro-email').value;
        const telefono = document.getElementById('registro-telefono').value;
        const password = document.getElementById('registro-password').value;
        const perfil = 2;
        
        fetch('http://localhost:5142/api/gestion/CreateUser', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ 
                "Nombre":nombre, 
                "Apellido":apellido,
                "Email":email, 
                "Telefono":telefono,
                "Password":password,
                "Perfil":perfil
            })
        })
        .then(response => response.json())
        .then(data => {
            alert('Registro exitoso');
        })
        .catch(error => {
            alert('Error en registro');
        });
    });

    // Cargar productos si estamos en la página de productos
    if (document.getElementById('productos-container')) {
        cargarProductos();
    }
});
