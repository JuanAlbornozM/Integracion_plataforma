# Gestión API

Este es el controlador para la gestión de usuarios en la API. Proporciona endpoints para crear, leer, actualizar y eliminar usuarios.

## Endpoints

### Obtener todos los usuarios

- **URL:** `/api/Gestion`
- **Método:** `GET`
- **Descripción:** Devuelve una lista de todos los usuarios.

#### Respuesta
- **Código 200:** Devuelve un array de usuarios.

### Obtener usuario por ID

- **URL:** `/api/Gestion/ByUsuario`
- **Método:** `GET`
- **Parámetros:**
    - `id_usuario` (query): ID del usuario a buscar.
- **Descripción:** Devuelve un usuario específico por su ID.

#### Respuesta
- **Código 200:** Devuelve el usuario.
- **Código 404:** Usuario no encontrado.

### Obtener usuario por Email

- **URL:** `/api/Gestion/byEmail`
- **Método:** `GET`
- **Parámetros:**
    - `email` (query): Email del usuario a buscar.
- **Descripción:** Devuelve un usuario específico por su email.

#### Respuesta
- **Código 200:** Devuelve el usuario.
- **Código 404:** Usuario no encontrado.

### Crear un nuevo usuario

- **URL:** `/api/Gestion/CreateUser`
- **Método:** `POST`
- **Cuerpo de la solicitud:** 
    ```json
    {
        "UsuarioID": int,
        "Nombre": "string",
        "Email": "string",
        "OtrosCampos": "..."
    }
    ```
- **Descripción:** Crea un nuevo usuario.

#### Respuesta
- **Código 200:** Usuario creado exitosamente.
- **Código 400:** Datos del usuario no válidos.
- **Código 409:** Usuario ya existe.

### Actualizar un usuario existente

- **URL:** `/api/Gestion/UpdateUser`
- **Método:** `PUT`
- **Cuerpo de la solicitud:** 
    ```json
    {
        "UsuarioID": int,
        "Nombre": "string",
        "Email": "string",
        "OtrosCampos": "..."
    }
    ```
- **Descripción:** Actualiza los datos de un usuario existente.

#### Respuesta
- **Código 200:** Usuario actualizado exitosamente.
- **Código 400:** Datos del usuario no válidos.
- **Código 409:** Usuario no existe.

### Eliminar un usuario

- **URL:** `/api/Gestion/{id_usuario}`
- **Método:** `DELETE`
- **Parámetros:**
    - `id_usuario` (route): ID del usuario a eliminar.
- **Descripción:** Elimina un usuario específico por su ID.

#### Respuesta
- **Código 200:** Usuario eliminado exitosamente.
- **Código 409:** Usuario no existe.

### Ejemplos de Uso

#### Obtener todos los usuarios

Solicitud:

```http
GET /api/Gestion HTTP/1.1
Host: example.com
```

Respuesta:

```json
[
    {
        "UsuarioID": 1,
        "Nombre": "Juan Pérez",
        "Email": "juan.perez@example.com"
    },
    ...
]
```

#### Obtener usuario por ID

Solicitud:

```http
GET /api/Gestion/ByUsuario?id_usuario=1 HTTP/1.1
Host: example.com
```

Respuesta:

```json
{
    "UsuarioID": 1,
    "Nombre": "Juan Pérez",
    "Email": "juan.perez@example.com"
}
```

#### Obtener usuario por Email

Solicitud:

```http
GET /api/Gestion/byEmail?email=juan.perez@example.com HTTP/1.1
Host: example.com
```

Respuesta:

```json
{
    "UsuarioID": 1,
    "Nombre": "Juan Pérez",
    "Email": "juan.perez@example.com"
}
```

#### Crear un nuevo usuario

Solicitud:

```http
POST /api/Gestion/CreateUser HTTP/1.1
Host: example.com
Content-Type: application/json

{
    "UsuarioID": 2,
    "Nombre": "María Gómez",
    "Email": "maria.gomez@example.com"
}
```

Respuesta:

```http
HTTP/1.1 200 OK
```

#### Actualizar un usuario existente

Solicitud:

```http
PUT /api/Gestion/UpdateUser HTTP/1.1
Host: example.com
Content-Type: application/json

{
    "UsuarioID": 1,
    "Nombre": "Juan Pérez Modificado",
    "Email": "juan.perez@example.com"
}
```

Respuesta:

```http
HTTP/1.1 200 OK
```

#### Eliminar un usuario

Solicitud:

```http
DELETE /api/Gestion/1 HTTP/1.1
Host: example.com
```

Respuesta:

```http
HTTP/1.1 200 OK
```