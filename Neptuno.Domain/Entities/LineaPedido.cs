using System;
using System.Collections.Generic;

namespace Neptuno.Domain.Entities
{
    public class LineaPedido : BaseEntity<int>
    {
        public LineaPedido() : base() { }

        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioUnidad { get; set; }
        public short Cantidad { get; set; }
        public float Descuento { get; set; }

        public Pedido PedidoEnt { get; set; }
        public Producto ProductoEnt { get; set; }
    }
}
