using System;
using System.Collections.Generic;

namespace FerremasProductos.Models;

public partial class IpProducto
{
    public int IdProducto { get; set; }

    public string? CodigoProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Marca { get; set; }

    public string? Codigo { get; set; }

    public virtual ICollection<IpPrecio> IdPrecios { get; set; } = new List<IpPrecio>();
}
