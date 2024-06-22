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
            "PerfilID":2
        })
    })
    .then(response => {
        if (response.ok) {
            alert("Usuario registrado");
        } else {
            // Si la respuesta no es OK, devuelve una promesa rechazada con la respuesta
            return response;
        }
    })
    .catch(error => {
        if (error instanceof SyntaxError) {
            // Error al analizar la respuesta JSON, puede no haber datos JSON en la respuesta
            console.error("Error al analizar la respuesta JSON:", error);
        } else {
            // Otro tipo de error, como un error en la solicitud HTTP
            console.error("Error al enviar la solicitud a la API:", error);
        }
    });
});