document.addEventListener('DOMContentLoaded', function() {
    cargarProductos();
});

function cargarProductos() {
    fetch('https://localhost:7206/api/Producto/AllProduct')
        .then(response => response.json())
        .then(data => {
            const productosContainer = document.getElementById('productos-container');
            productosContainer.innerHTML = '';
            data.forEach(producto => {
                const productoElement = document.createElement('div');
                productoElement.className = 'producto';

                const formatoPrecio = new Intl.NumberFormat('es-CL', {
                    style: 'currency',
                    currency: 'CLP'
                });

                const monto = producto.precios.length > 0 ? formatoPrecio.format(producto.precios[0].monto) : 'No disponible';
                productoElement.innerHTML = `
                    <img src="../imagenes/${producto.nombre}.png" alt="${producto.nombre}">
                    <h3>${producto.nombre}</h3>
                    <p>Marca: ${producto.marca}</p>
                    <p>Codgigo de Producto: ${producto.codigoProducto}</p>
                    <p>Codigo: ${producto.codigo}</p>
                    <p>Tipo de Producto: ${producto.tipoProducto}</p>
                    <p>Precio: ${monto}</p>
                `;
                console.log(producto);
                productosContainer.appendChild(productoElement);
            });
        });
}