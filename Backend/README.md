# FerremasProductos API

Esta es una API para gestionar productos y sus precios en FerremasProductos.

## Endpoints

### Obtener todos los productos

- **URL:** `GET /api/producto/AllProduct`
- **Descripción:** Obtiene una lista de todos los productos.
- **Respuesta:**
    ```json
    [
        {
            "idProducto": 1,
            "codigoProducto": "12345",
            "nombre": "Producto A",
            "marca": "Marca X",
            "codigo": "A123",
            "precios": [
                {
                    "fecha": "2023-06-18T00:00:00",
                    "monto": 100.0
                }
            ]
        }
    ]
    ```

### Obtener producto por ID

- **URL:** `GET /api/producto/ByProduct?id_producto={id}`
- **Descripción:** Obtiene un producto por su ID.
- **Parámetros de consulta:**
    - `id_producto` (int): El ID del producto.
- **Respuesta:**
    ```json
    {
        "idProducto": 1,
        "codigoProducto": "12345",
        "nombre": "Producto A",
        "marca": "Marca X",
        "codigo": "A123",
        "precios": [
            {
                "fecha": "2023-06-18T00:00:00",
                "monto": 100.0
            }
        ]
    }
    ```
- **Errores posibles:**
    - `404`: Producto con ID no encontrado.

### Obtener producto por código

- **URL:** `GET /api/producto/ByCode?codigo={codigo}`
- **Descripción:** Obtiene un producto por su código.
- **Parámetros de consulta:**
    - `codigo` (string): El código del producto.
- **Respuesta:**
    ```json
    {
        "idProducto": 1,
        "codigoProducto": "12345",
        "nombre": "Producto A",
        "marca": "Marca X",
        "codigo": "A123",
        "precios": [
            {
                "fecha": "2023-06-18T00:00:00",
                "monto": 100.0
            }
        ]
    }
    ```
- **Errores posibles:**
    - `404`: Producto con código no encontrado.

### Obtener producto por código de producto

- **URL:** `GET /api/producto/ByProductCode?codigoProducto={codigoProducto}`
- **Descripción:** Obtiene un producto por su código de producto.
- **Parámetros de consulta:**
    - `codigoProducto` (string): El código del producto.
- **Respuesta:**
    ```json
    {
        "idProducto": 1,
        "codigoProducto": "12345",
        "nombre": "Producto A",
        "marca": "Marca X",
        "codigo": "A123",
        "precios": [
            {
                "fecha": "2023-06-18T00:00:00",
                "monto": 100.0
            }
        ]
    }
    ```
- **Errores posibles:**
    - `404`: Producto con código de producto no encontrado.

### Crear un nuevo producto

- **URL:** `POST /api/producto/CreateProduct`
- **Descripción:** Crea un nuevo producto.
- **Cuerpo de la solicitud:**
    ```json
    {
        "codigoProducto": "12345",
        "nombre": "Producto A",
        "marca": "Marca X",
        "codigo": "A123",
        "fecha": "2023-06-18T00:00:00",
        "monto": 100.0
    }
    ```
- **Respuesta:**
    - `200`: Producto creado exitosamente.
- **Errores posibles:**
    - `400`: Datos inválidos.

### Actualizar un producto

- **URL:** `PUT /api/producto/UpdateProduct`
- **Descripción:** Actualiza un producto existente.
- **Cuerpo de la solicitud:**
    ```json
    {
        "codigoProducto": "12345",
        "nombre": "Producto A",
        "marca": "Marca X",
        "codigo": "A123",
        "fecha": "2023-06-18T00:00:00",
        "monto": 100.0
    }
    ```
- **Respuesta:**
    - `200`: Producto actualizado exitosamente.
- **Errores posibles:**
    - `400`: Datos inválidos.
    - `404`: Producto con código no encontrado.

## Modelos

### CreateProduct

- **Descripción:** Modelo utilizado para crear o actualizar un producto.
- **Propiedades:**
    - `codigoProducto` (string): Código del producto.
    - `nombre` (string): Nombre del producto.
    - `marca` (string): Marca del producto.
    - `codigo` (string): Código del producto.
    - `fecha` (DateTime): Fecha del precio.
    - `monto` (decimal): Monto del precio.

### IpProducto

- **Descripción:** Modelo del producto.
- **Propiedades:**
    - `idProducto` (int): ID del producto.
    - `codigoProducto` (string): Código del producto.
    - `nombre` (string): Nombre del producto.
    - `marca` (string): Marca del producto.
    - `codigo` (string): Código del producto.
    - `precios` (List<IpPrecio>): Lista de precios del producto.

### IpPrecio

- **Descripción:** Modelo del precio del producto.
- **Propiedades:**
    - `fecha` (DateTime): Fecha del precio.
    - `monto` (decimal): Monto del precio.