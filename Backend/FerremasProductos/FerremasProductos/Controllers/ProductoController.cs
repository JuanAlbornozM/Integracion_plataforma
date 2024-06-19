using Microsoft.AspNetCore.Mvc;
using FerremasProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace FerremasProductos.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController: ControllerBase
    {
        private readonly DucogymContext _productoContext;
        public ProductoController(DucogymContext productoContext)
        {
            _productoContext = productoContext;
        }

        [HttpGet("AllProduct")]
        [ActionName("GetProducts")]
        public async Task<ActionResult<IEnumerable<IpProducto>>> GetProducts()
        {
            var productos = await _productoContext.IpProductos
                .Include(p => p.IdPrecios)
                .ToListAsync();

            if (productos == null || productos.Count == 0)
            {
                return NotFound(new { Message = "No existen productos" });
            }
            var result = productos.Select(p => DatosProducto(p)).ToList();
            return Ok(result);
        }


        [HttpGet("ByProduct")]
        [ActionName("GetById")]
        public async Task<ActionResult<IpProducto>> GetById(int id_producto)
        {
            var productos = await _productoContext.IpProductos
                .Include(p => p.IdPrecios)
                .Where(p => p.IdProducto == id_producto)
                .FirstOrDefaultAsync();

            if (productos == null)
            {
                return NotFound(new { Message = $"Producto con ID {id_producto} no encontrado." });
            }

            var viewModel = DatosProducto(productos);

            return Ok(viewModel);
        }

        [HttpGet("ByCode")]
        [ActionName("GetByCode")]
        public async Task<ActionResult<IpProducto>> GetByCode(string codigo)
        {
            var productos = await _productoContext.IpProductos
                .Include(p => p.IdPrecios)
                .Where(p => p.Codigo == codigo)
                .FirstOrDefaultAsync();

            if (productos == null)
            {
                return NotFound(new { Message = $"Producto con código {codigo} no encontrado." });
            }

            var viewModel = DatosProducto(productos);

            return Ok(viewModel);
        }

        [HttpGet("ByProductCode")]
        [ActionName("GetByProductCode")]
        public async Task<ActionResult<IpProducto>> GetByProductCode(string codigoProducto)
        {
            var productos = await _productoContext.IpProductos
                .Include(p => p.IdPrecios)
                .Where(p => p.CodigoProducto == codigoProducto)
                .FirstOrDefaultAsync();

            if (productos == null)
            {
                return NotFound(new { Message = $"Producto con código {codigoProducto} no encontrado." });
            }

            var viewModel = DatosProducto(productos);

            return Ok(viewModel);
        }

        [HttpPost("CreateProduct")]
        [ActionName("Create")]
        public async Task<ActionResult> Create(CreateProduct createProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var producto = new IpProducto
            {
                CodigoProducto = createProduct.CodigoProducto,
                Nombre = createProduct.Nombre,
                Marca = createProduct.Marca,
                Codigo = createProduct.Codigo
            };

            var precio = new IpPrecio
            {
                Fecha = createProduct.Fecha,
                Monto = createProduct.Monto
            };

            producto.IdPrecios.Add(precio);

            await _productoContext.IpProductos.AddAsync(producto);
            await _productoContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("UpdateProduct")]
        [ActionName("Update")]
        public async Task<ActionResult> Update(CreateProduct product )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var producto = await _productoContext.IpProductos
                .Include(p => p.IdPrecios)
                .Where(p => p.Codigo == product.Codigo)
                .FirstOrDefaultAsync();

            if (producto == null)
            {
                return NotFound(new { Message = $"Producto con código {product.Codigo} no encontrado." });
            }

            producto.CodigoProducto = product.CodigoProducto;
            producto.Nombre = product.Nombre;
            producto.Marca = product.Marca;

            var precio = new IpPrecio
            {
                Fecha = product.Fecha,
                Monto = product.Monto
            };

            producto.IdPrecios.Add(precio);

            await _productoContext.SaveChangesAsync();

            return Ok();            
            
        }

        private object DatosProducto(IpProducto producto)
        {
            return new
            {
                producto.IdProducto,
                producto.CodigoProducto,
                producto.Nombre,
                producto.Marca,
                producto.Codigo,
                Precios = producto.IdPrecios.Select(precio => new
                {
                    precio.Fecha,
                    precio.Monto,
                    
                })
            };
          
        }
    }
}
