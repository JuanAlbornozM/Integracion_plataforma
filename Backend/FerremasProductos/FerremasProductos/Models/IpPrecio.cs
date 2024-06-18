using System;
using System.Collections.Generic;

namespace FerremasProductos.Models;

public partial class IpPrecio
{
    public int IdPrecio { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ICollection<IpProducto> IdProductos { get; set; } = new List<IpProducto>();
}
