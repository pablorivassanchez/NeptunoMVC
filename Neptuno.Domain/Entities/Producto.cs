using System;
using System.Collections.Generic;

namespace Neptuno.Domain.Entities
{
    public class Producto : BaseEntity<int>
    {
        public Producto() : base()
        {
            LineasPedido = new HashSet<LineaPedido>();
        }

        public string NombreProducto { get; set; }
        public int? IdProveedor { get; set; }
        public int? IdCategoria { get; set; }
        public string CantidadPorUnidad { get; set; }
        public decimal? PrecioUnidad { get; set; }
        public short? UnidadesEnExistencia { get; set; }
        public short? UnidadesEnPedido { get; set; }
        public int? NivelNuevoPedido { get; set; }
        public bool Suspendido { get; set; }

        public Categoria CategoriaEnt { get; set; }
        public Proveedor ProveedorEnt { get; set; }
        public ICollection<LineaPedido> LineasPedido { get; set; }
    }
}
